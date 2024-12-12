using ReactiveUI;
using System.Reactive;

namespace RoleGameAndroid.AuthorizationPage;

public class AuthorizationViewModel
{
    public AuthorizationPageViewModel Parent { get; set; }

    public ReactiveCommand<Unit, Unit> SwitchPageCommand { get; }

    public AuthorizationViewModel()
    {
        SwitchPageCommand = ReactiveCommand.Create(SwitchPage);
    }

    private void SwitchPage()
    {
        Parent?.SwitchPage();
    }
}