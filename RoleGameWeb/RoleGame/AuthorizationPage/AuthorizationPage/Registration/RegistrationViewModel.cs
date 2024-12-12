using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;

namespace RoleGameAndroid.AuthorizationPage
{
	public class RegistrationViewModel : ReactiveObject
    {
        public AuthorizationPageViewModel Parent { get; set; }
        public ReactiveCommand<Unit, Unit> SwitchPageCommand { get; }

        public RegistrationViewModel()
        {
            SwitchPageCommand = ReactiveCommand.Create(SwitchPage);
        }

        private void SwitchPage()
        {
            Parent?.SwitchPage();
        }
    }
}