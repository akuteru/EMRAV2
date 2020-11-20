using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMRA.ViewModels
{
    public class MainBottomTabbedPageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        public MainBottomTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
