using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Veylib.ICLI;

namespace AnorexiaMassReporter__PRIVATE_.Components
{
    public class Anorexia
    {
        public static async Task MassReportMessage(string token, string channelID, string messageID, int amount)
        {
            ulong absolute_reports = 0;
            List<Task> tasks = new List<Task>();

            var json = new
            {
                version = "1.0",
                variant = "3",
                language = "en",
                breadcrumbs = new[] { 3, 11, 35 },
                elements = new { },
                name = "message",
                channel_id = channelID,
                message_id = messageID
            };

            for (int i = 0; i < amount; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Add("Authorization", token);

                            var jsonContent = JsonConvert.SerializeObject(json);
                            var jsonToString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                            var response = await client.PostAsync("https://discord.com/api/v9/reporting/message", jsonToString);
                            var responseStr = await response.Content.ReadAsStringAsync();
                            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseStr);

                            if (response.IsSuccessStatusCode)
                            {
                                absolute_reports++;
                                CLI.WriteLine($"\u001b[32mSent {absolute_reports} reports \u001b[0m? \u001b[33m{responseJson["report_id"]}");
                            }
                            else if ((int)response.StatusCode == 429)
                            {
                                float retryAfter = (float)responseJson["retry_after"] / 1000; // Convert to seconds
                                CLI.WriteLine($"\u001b[31mRate limited, waiting {retryAfter} seconds...\u001b[0m");
                                await Task.Delay(TimeSpan.FromSeconds(retryAfter));
                            }
                            else
                            {
                                CLI.WriteLine($"\u001b[31mFailed a report => [{response.StatusCode}]");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex + "");
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }
    }
}
