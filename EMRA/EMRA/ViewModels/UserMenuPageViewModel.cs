using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMRA.ViewModels
{
    public class UserMenuPageViewModel : ViewModelBase
    {
        public string UserFullName;
        private readonly INavigationService _navigationService;
        public UserMenuPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            UserFullName = "John Vince Azares";
        }
    }
}
