using Plugin.FacebookClient;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using EMRA.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;

namespace EMRA.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private bool _isExecutable;
        public bool IsExecutable
        {
            get { return _isExecutable; }
            set { SetProperty(ref _isExecutable, value); }
        }
        IFacebookClient _facebookService = CrossFacebookClient.Current;
        private readonly INavigationService _navigationService;
        public DelegateCommand FacebookLogin { get; private set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            FacebookLogin = new DelegateCommand(ExecuteFacebookLogin, CanSubmit);
        }
        bool CanSubmit()
        {
            return true;
        }
        async void ExecuteFacebookLogin()
        {
            try
            {
                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }
                EventHandler<FBEventArgs<string>> userDataDelegate = null;
                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;
                    switch (e.Status)
                    {
                        case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            var socialLoginData = new SocialLoginData
                            {
                                Id = facebookProfile.Id,
                                Email = facebookProfile.Email,
                                Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}",
                                ProfilePicture = facebookProfile.Picture

                            };
                            App.SocialData = socialLoginData;
                            await _navigationService.NavigateAsync("/MainTabbed");
                            break;
                        case FacebookActionStatus.Canceled:
                            break;
                    }
                    _facebookService.OnUserData -= userDataDelegate;
                };
                _facebookService.OnUserData += userDataDelegate;
                string[] fbRequestFields = { "email", "first_name", "last_name", "gender", "picture" };
                string[] fbPermissions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermissions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
