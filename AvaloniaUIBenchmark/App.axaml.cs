using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaUIBenchmark.ViewModels;
using AvaloniaUIBenchmark.Views;
using System;
using Avalonia.Controls;
using Avalonia.Styling;

namespace AvaloniaUIBenchmark;

public partial class App : Application
{    
    public const string Version = "1.2";
    private static App? _instance;

    public override void Initialize()
    {
        _instance = this;
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    public static void SwitchTheme()
        => _instance?.SwitchThemeInternal();

    private void SwitchThemeInternal()
    {
        if(RequestedThemeVariant == ThemeVariant.Dark)
        {
            RequestedThemeVariant = ThemeVariant.Light;
            return;
        }

        RequestedThemeVariant = ThemeVariant.Dark;
    }

}