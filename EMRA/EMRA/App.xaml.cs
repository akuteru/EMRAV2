using Prism;
using Prism.Ioc;
using EMRA.ViewModels;
using EMRA.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using EMRA.Models;

namespace EMRA
{
    public partial class App
    {
        public static SocialLoginData SocialData { get; set; }
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU2NzUwQDMxMzgyZTMzMmUzMFdTL2dMUUQvODdwOWpJZ0FRd2tNRXBOYk10UTBXalo2Y2FURyt3L29KOHM9");
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainBottomTabbedPage, MainBottomTabbedPageViewModel>("MainTabbed");
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<SchedulePage, SchedulePageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPage, NotificationPageViewModel>();
            containerRegistry.RegisterForNavigation<UserMasterDetailPage, UserMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<UserMenuPage, UserMenuPageViewModel>();
            containerRegistry.RegisterForNavigation<DoctorProfilePage, DoctorProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<AddAppointment, AddAppointmentViewModel>();
        }
    }
}
