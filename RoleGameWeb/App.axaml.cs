using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using RoleGameWeb.Main;
using System.ComponentModel;
using Avalonia.Styling;

namespace RoleGameWeb;

public partial class App : Application
{
    private ThemeVariant _currentTheme = ThemeVariant.Light;

    public event PropertyChangedEventHandler? PropertyChanged;
    public ThemeVariant CurrentTheme
    {
        get => _currentTheme;
        set
        {
            if (_currentTheme != value)
            {
                _currentTheme = value;
                OnPropertyChanged(nameof(CurrentTheme));
            }
        }
    }

    public void ChangeCurrentTheme(string theme)
    {
        switch (theme)
        {
            case "Dark":
                CurrentTheme = ThemeVariant.Dark;
                break;
            case "Light":
                CurrentTheme = ThemeVariant.Light;
                break;
            default:
                break;
        }
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
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

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
