using dCom.Configuration;
using DERMSCommon.SCADACommon;
using DermsUI.MediatorPattern;
using DermsUI.Resources;
using DermsUI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace DermsUI.ViewModel
{
    public class SCADAViewModel:BindableBase
    {
        private ConnectionState connectionState;
        public ObservableCollection<DataPoint> Points { get; set; }
        private DataPoint selectedDataItem;
        public DataPoint SelectedDataItem
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
        public ICommand SelectedPointCommand { get { return _selectedPointCommand ?? (_selectedPointCommand = new CommandHandler(() => ShowCommanding(), () => CanExecute)); }  }

        public void ShowCommanding()
        {
            CommandingWindow commandingWindow = new CommandingWindow();
            commandingWindow.DataContext = new CommandingWindowViewModel(SelectedDataItem);
            commandingWindow.ShowDialog();
        }

        #region Properties
        public ConnectionState ConnectionState
        {
            get
            {
                return connectionState;
            }

            set
            {
                connectionState = value;
                OnPropertyChanged("ConnectionState");
            }
        }

        #endregion Properties

        public SCADAViewModel()
        {
            Points = new ObservableCollection<DataPoint>();
            Mediator.Register("AllSignalUpdate", OnChange);
            Mediator.NotifyColleagues("GetAllSignals", true);
            ConnectionState = ConnectionState.DISCONNECTED;
        }

        public void OnChange(object parameter)
        {
            List<DataPoint> newPoints = (List<DataPoint>)parameter;

            foreach (DataPoint dataPointItem in newPoints)
            {
                DataPoint item = Points.Where(x => x.Gid == dataPointItem.Gid).FirstOrDefault();

                if (item == null)
                {
                    Points.Add(dataPointItem);
                }
                else
                {
                    Points.Remove(item);
                    Points.Add(dataPointItem);
                }
            }

            Console.Beep();
        }
    }
}
