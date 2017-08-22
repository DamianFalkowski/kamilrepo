using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ScheduleApp.Extensions;
using ScheduleDataModel.Model;

namespace ScheduleApp.ViewModel
{
    public class MainWindow : ViewModelBase
    {
        public ObservableCollection<Schedule> Schedules
        {
            get
            {
                return _schedules;
            }
            set
            {
                _schedules = value;
                RaisePropertyChanged("Schedules");
            }
        }
        private ObservableCollection<Schedule> _schedules;

        public ObservableCollection<ScheduleDayOfWeek> DaysOfWeek
        {
            get
            {
                return _daysOfWeek;
            }
            set
            {
                _daysOfWeek = value;
                RaisePropertyChanged("DaysOfWeek");
            }
        }
        private ObservableCollection<ScheduleDayOfWeek> _daysOfWeek;

        public RelayCommand WindowLoadedCommand { get; private set; }
        public RelayCommand<Schedule> ScheduleSelectedCommand { get; private set; }

        public MainWindow()
        {
              WindowLoadedCommand = new RelayCommand(WindowLoaded);
              ScheduleSelectedCommand = new RelayCommand<Schedule>(ScheduleSelected);  
        }

        private void WindowLoaded()
        {
            Schedule plan = ScheduleReader.Tools.XlsReader.Instance.GetSchedule(@"C:\Source\kamilrepo\data\plan_dzien.xls");
            //Schedule plan = ScheduleReader.Tools.XlsReader.Instance.GetSchedule(@"C:\Users\lenovo\Desktop\kamilrepo\plan_dzien.xls");

            ObservableCollection<Schedule> data = new ObservableCollection<Schedule>() { };
            data.Add(plan);
            data.Add(plan);
            data.Add(plan);
            Schedules = data;
        }

        private void ScheduleSelected(Schedule schedule)
        {
            DaysOfWeek = schedule.DaysOfWeek.ToObservableCollection();
        }
    }
}