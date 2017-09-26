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

        public ObservableCollection<StudentGroup> StudentGroups
        {
            get
            {
                return _studentGroups;
            }
            set
            {
                _studentGroups = value;
                RaisePropertyChanged("StudentGroups");
            }
        }
        private ObservableCollection<StudentGroup> _studentGroups;

        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                RaisePropertyChanged("Subjects");
            }
        }
        private ObservableCollection<Subject> _subjects;

        public Schedule selectedSchedule { get; set; }
        public ScheduleDayOfWeek selectedDay { get; set; }
        public StudentGroup selectedGroup { get; set; }

        public RelayCommand WindowLoadedCommand { get; private set; }
        public RelayCommand<Schedule> ScheduleSelectedCommand { get; private set; }
        public RelayCommand<ScheduleDayOfWeek> DaySelectedCommand { get; private set; }
        public RelayCommand<StudentGroup> GroupSelectedCommand { get; private set; }

        public MainWindow()
        {
            WindowLoadedCommand = new RelayCommand(WindowLoaded);
            ScheduleSelectedCommand = new RelayCommand<Schedule>(ScheduleSelected);  
            DaySelectedCommand = new RelayCommand<ScheduleDayOfWeek>(DaySelected);
            GroupSelectedCommand = new RelayCommand<StudentGroup>(GroupSelected);
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
            if (selectedSchedule != null && selectedDay!=null)
                DaySelected(schedule.DaysOfWeek.Where(x => x.Day == selectedDay.Day).First());
            selectedSchedule = schedule;
        }

        private void DaySelected(ScheduleDayOfWeek day)
        {
            StudentGroups = day.StudentGroups.ToObservableCollection();
            if (selectedGroup!=null)
                GroupSelected(day.StudentGroups.Where(x=>x.Name==selectedGroup.Name).First());
            selectedDay = day;
        }

        private void GroupSelected(StudentGroup group)
        {
            Subjects = group.Subjects.ToObservableCollection();
            selectedGroup = group;
        }
    }
}