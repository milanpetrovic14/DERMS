using DermsUI.MediatorPattern;
using DermsUI.Resources;
using DermsUI.View;
using DermsUI.ViewModel.PointViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DermsUI.ViewModel
{
    internal class AlarmsViewModel:BindableBase
    {
        public ObservableCollection<BasePointItem> Points { get; set; }
        private BasePointItem selectedDataItem;
        public BasePointItem SelectedDataItem
        {
            get
            {
                return selectedDataItem;
            }
            set
            {
                selectedDataItem = value;
                //Poziv pROZORA
            }
        }

        public bool CanExecute { get { return true; } }

        private ICommand _selectedPointCommand;
        public ICommand SelectedPointCommand { get { return _selectedPointCommand ?? (_selectedPointCommand = new CommandHandler(() => ShowCommanding(), () => CanExecute)); } }

        public void ShowCommanding()
        {
            CommandingWindow commandingWindow = new CommandingWindow();
            commandingWindow.DataContext = new CommandingWindowViewModel(SelectedDataItem);
            commandingWindow.ShowDialog();
        }

        public AlarmsViewModel()
        {
            Mediator.Register("AlarmSignalUpdate", OnChange);
            Mediator.NotifyColleagues("GetAlarmSignals",true);
        }

        public void OnChange(object parameter)
        {
            Console.Beep();

        }
    }
}
