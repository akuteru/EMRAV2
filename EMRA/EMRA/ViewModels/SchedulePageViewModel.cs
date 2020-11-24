using EMRA.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using XF.Material.Forms.Models;

namespace EMRA.ViewModels
{
    public class SchedulePageViewModel : ViewModelBase
    {
        public ObservableCollection<Schedule> ScheduleList { get; set; }
        public List<string> MenuChoices { get; set; }
        public Command<MaterialMenuResult> MenuCommand { get; set; }
        private readonly INavigationService _navigationService;
        private bool _isExecutable;
        public bool IsExecutable
        {
            get { return _isExecutable; }
            set { SetProperty(ref _isExecutable, value);  }
        }
        public DelegateCommand CreateAppointment { get; private set; }
        public SchedulePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            ScheduleList = new ObservableCollection<Schedule>();
            ScheduleList.Add(CreateSchedule(1, DateTime.Parse("11-23-2020"), "Medical Alarm 1", "Take paracetamol"));
            ScheduleList.Add(CreateSchedule(2, DateTime.Parse("11-23-2020"), "Medical Alarm 1-2", "Take paracetamol"));
            ScheduleList.Add(CreateSchedule(3, DateTime.Parse("11-23-2020"), "Medical Alarm 2", "Take paracetamol"));
            ScheduleList.Add(CreateSchedule(4, DateTime.Parse("11-23-2020"), "Medical Alarm 2-1", "Take paracetamol"));

            MenuChoices = new List<string>()
            {
                "Turn off",
                "Edit",
                "Remove"
            };
            CreateAppointment = new DelegateCommand(SetAppointment);
        }
        async void SetAppointment()
        {
            try
            {
                await _navigationService.NavigateAsync("NavigationPage/AddAppointment");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        private Schedule CreateSchedule(long id, DateTime scheduleDate, string title, string remarks)
        {
            Schedule model = new Schedule()
            {
                ID = id,
                ScheduleDate = scheduleDate,
                Title = title,
                Description = remarks
            };
            return model;
        }
    }
}
