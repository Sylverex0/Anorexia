using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Veylib.ICLI;
using AnorexiaMassReporter__PRIVATE_.Components;
using System.Net.Http;

namespace AnorexiaMassReporter__PRIVATE_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 1000;

            Console.Clear();
            CLI.Start(Settings.startupProperties);

            string token = CLI.ReadLine("Enter Token > ");
            CLI.Clear();
            string amount = CLI.ReadLine("Enter Amount Of Reports > ");
            CLI.Clear();
            string Channel = CLI.ReadLine("Enter ChannelID > ");
            CLI.Clear();
            string Message = CLI.ReadLine("Enter MessageID > ");
            CLI.Clear();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    HttpResponseMessage response = await client.GetAsync("https://discord.com/api/users/@me");

                    if (response.IsSuccessStatusCode)
                    {
                        await Anorexia.MassReportMessage(token, Channel, Message, Convert.ToInt32(amount));
                    }
                    else
                    {
                        CLI.WriteLine("\u001b[31mIncorrent User Token.");
                        CLI.Delay(2500);
                        Environment.Exit(0);
                    }
                }
            }
            catch
            {
                CLI.WriteLine("\u001b[31mError Parsing Input.");
                CLI.Delay(2500);
                Environment.Exit(0);
            }
        }
    }
}
