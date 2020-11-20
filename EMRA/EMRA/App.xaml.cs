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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk1Mjc4QDMxMzgyZTMyMmUzMEJpUUVva0lzL0F1S2Z4QzRmYVRnMTF5a0tvalZVTlZhTzFNYWYrQ3lZdW89");
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            await NavigationService.NavigateAsync("MainBottomTabbedPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainBottomTabbedPage, MainBottomTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<SchedulePage, SchedulePageViewModel>();
            containerRegistry.RegisterForNavigation<NotificationPage, NotificationPageViewModel>();
            containerRegistry.RegisterForNavigation<UserMasterDetailPage, UserMasterDetailPageViewModel>();
        }
    }
}
