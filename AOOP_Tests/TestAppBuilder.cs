using AOOP_Homework2.Tests;
using Avalonia;
using Avalonia.Headless;
using Avalonia.Markup.Xaml;


[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}
