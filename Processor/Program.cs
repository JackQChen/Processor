using Microsoft.Playwright;

namespace Processor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

        static async Task Run()
        {
            using var playwright = await Playwright.CreateAsync();

            // chrome://version
            var chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            var profilePath = @"C:\Users\Administrator\AppData\Local\Google\Chrome\User Data\Default";

            var browserContext = await playwright.Chromium.LaunchPersistentContextAsync(profilePath,
                new BrowserTypeLaunchPersistentContextOptions
                {
                    ExecutablePath = chromePath,
                    Headless = false,
                }
            );

            var page = browserContext.Pages.First();
            await page.GotoAsync("https://www.douyin.com/");
            //await page.PauseAsync();
            // Click Record
            await page.GotoAsync("https://www.douyin.com/?recommend=1");
            await page.GotoAsync("https://www.douyin.com/follow/live/878652259214");
            while (true)
            {
                await page.Locator("#island_d3bbb div").First.ClickAsync();
                Thread.Sleep(new Random().Next(100, 300));
            }
        }

    }

}
