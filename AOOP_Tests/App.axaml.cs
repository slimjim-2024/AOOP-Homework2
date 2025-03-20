using Avalonia;
using Avalonia.Headless;
using Avalonia.Markup.Xaml;

namespace AOOP_Homework2.Tests;
public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}