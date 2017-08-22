using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
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
    }
}