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
            var profilePath = @"C:\Users\jack.chen\AppData\Local\Google\Chrome\User Data\Profile 1";

            var browserContext = await playwright.Chromium.LaunchPersistentContextAsync(profilePath,
                new BrowserTypeLaunchPersistentContextOptions
                {
                    ExecutablePath = chromePath,
                    Headless = false,
                }
            );

            var page = browserContext.Pages.First();
            await page.GotoAsync("https://www.google.com");
            await page.PauseAsync();
        }

    }

}
