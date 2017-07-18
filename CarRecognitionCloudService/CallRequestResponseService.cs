using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp.CPlusPlus;

namespace CarRecognitionCloudService
{
	static class CallRequestResponseService
	{
		const string ApiKey = "sN9xBaAYblWQCiVTTvoC2MsHZ3YyCbXXv7qn2Daag4pi8dcLWfsyDh+VQ08SaEj0t9hThLxt/MLWVUDV6nRdWQ=="; // Replace this with the API key for the web service

		public static TextBox ConsoleTextbox;

		public static async void Invoke(Mat mat)
		{
			ConsoleTextbox.Clear();
			await InvokeRequestResponseService(mat);
		}

		static Dictionary<string, List<Dictionary<string, string>>> GetInputs(Mat mat)
		{
			var inputs = new Dictionary<string, List<Dictionary<string, string>>>()
			{
				{
					"input1",
					new List<Dictionary<string, string>>()
					{
						new Dictionary<string, string>()
						{
							{
								"Col1", ""
							},
						}
					}
				},
			};

			List<Dictionary<string, string>> input = null;
			var gotValue = inputs.TryGetValue("input1", out input);

			if(gotValue)
			{
				for(int x = 0; x < mat.Rows; x++)
				{
					for(int y = 0; y < mat.Cols; y++)
					{
						var index = mat.Cols * x + y;
						var pixel = mat.At<Vec3b>(x, y);

						input[0].Add($"Col{index + 2}", pixel.Item1.ToString());
					}

				}
			}

			return inputs;
		}

		static async Task InvokeRequestResponseService(Mat mat)
		{
			using(var client = new HttpClient())
			{
				var scoreRequest = new
				{
					Inputs = GetInputs(mat),

					GlobalParameters = new Dictionary<string, string>()
					{
					}
				};

				var requestUri = new Uri("https://ussouthcentral.services.azureml.net");

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
				client.BaseAddress = requestUri;

				// WARNING: The 'await' statement below can result in a deadlock
				// if you are calling this code from the UI thread of an ASP.Net application.
				// One way to address this would be to call ConfigureAwait(false)
				// so that the execution does not attempt to resume on the original context.
				// For instance, replace code such as:
				//      result = await DoSomeTask()
				// with the following:
				//      result = await DoSomeTask().ConfigureAwait(false)

				var response = await client
					.PostAsJsonAsync("/workspaces/7053cd6a6204422f9e40b0d2f7ffbfeb/services/dc1964b6101543429df9361adcc321f6/execute?api-version=2.0&format=swagger", scoreRequest)
					.ConfigureAwait(continueOnCapturedContext: false);

				MethodInvoker mi = new MethodInvoker(async () =>
				{
					if(response.IsSuccessStatusCode)
					{
						var responseStr = await response
							.Content
							.ReadAsStringAsync();

						var regex = new Regex(pattern: @"\w*Scored\w*", options: RegexOptions.Compiled);
						var match = regex.Match(responseStr);

						var result = responseStr
							.Substring(match.Index)
							.Split(new char[] { '\"', '}', ']', '[', '{', ':', ','}, StringSplitOptions.RemoveEmptyEntries);

						if(ConsoleTextbox != null)
						{
							var formatInfo = new NumberFormatInfo();
							formatInfo.NumberDecimalSeparator = ".";

							var resultStr = $"Car: \t{ double.Parse(result[2], formatInfo) * 100} %" + Environment.NewLine;
							resultStr += $"Not a car: { double.Parse(result[5], formatInfo) * 100} %";

							ConsoleTextbox.Text = resultStr + Environment.NewLine;
						}
					}
					else
					{
						if(ConsoleTextbox != null)
						{
							ConsoleTextbox.Text = $"The request failed with status code: {response.StatusCode}" + Environment.NewLine;

							// Print the headers - they include the requert ID and the timestamp,
							// which are useful for debugging the failure
							ConsoleTextbox.Text += response.Headers.ToString() + Environment.NewLine;

							var responseContent = await response
								.Content
								.ReadAsStringAsync();

							ConsoleTextbox.Text += responseContent + Environment.NewLine;
						}
					}
				});

				if(ConsoleTextbox.InvokeRequired)
				{
					ConsoleTextbox.BeginInvoke(mi);
				}
				else
				{
					mi();
				}
			}
		}
	}
}
