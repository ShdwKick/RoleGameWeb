using System.Reactive;
using Avalonia.Controls;
using ReactiveUI;

namespace RoleGameAndroid.AuthorizationPage;

public class AuthorizationPageViewModel : ReactiveObject
{
    private UserControl _authControl;
    private UserControl _regControl;
    private UserControl _currentControl;

    public UserControl CurrentControl
    {
        get => _currentControl;
        set => this.RaiseAndSetIfChanged(ref _currentControl, value);
    }


    public AuthorizationPageViewModel()
    {
        var authVM = new AuthorizationViewModel(){Parent = this};
        var regVM = new RegistrationViewModel() { Parent = this };
        _authControl = new AuthorizationView()
        {
            DataContext = authVM,
        };
        _regControl = new RegistrationView()
        {
            DataContext = regVM,
        };

        CurrentControl = _authControl;
    }

    public void SwitchPage()
    {
        if (CurrentControl == null)
            return;

        CurrentControl = CurrentControl == _authControl ? _regControl : _authControl;
    }
}