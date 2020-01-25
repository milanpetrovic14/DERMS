using dCom.Configuration;
using DERMSCommon.SCADACommon;
using DermsUI.Resources;
using DermsUI.View;
using DermsUI.ViewModel.PointViewModel;
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
    internal class SCADAViewModel:BindableBase,IDisposable,IStateUpdater
    {
        //UMESTO LOGOVA EVENT SUMMARY - DA SE UBACUJE STA SI URADIO
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
        public ICommand SelectedPointCommand { get { return _selectedPointCommand ?? (_selectedPointCommand = new CommandHandler(() => ShowCommanding(), () => CanExecute)); }  }

        public void ShowCommanding()
        {
            CommandingWindow commandingWindow = new CommandingWindow();
            commandingWindow.DataContext = new CommandingWindowViewModel(SelectedDataItem);
            commandingWindow.ShowDialog();
        }

        #region Fields

        private object lockObject = new object();
        private Thread timerWorker;
        private ConnectionState connectionState;
      //  private Modbus.Acquisition.Acquisitor acquisitor;
        private AutoResetEvent acquisitionTrigger = new AutoResetEvent(false);
        private TimeSpan elapsedTime = new TimeSpan();
        private Dispatcher dispather = Dispatcher.CurrentDispatcher;
        private string logText;
        private StringBuilder logBuilder;
        private DateTime currentTime;
        private IFunctionExecutor commandExecutor;
        private bool timerThreadStopSignal = true;
        private bool disposed = false;
        IConfiguration configuration;
        #endregion Fields

        #region Properties

        public DateTime CurrentTime
        {
            get
            {
                return currentTime;
            }

            set
            {
                currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

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

        public string LogText
        {
            get
            {
                return logText;
            }

            set
            {
                logText = value;
                OnPropertyChanged("LogText");
            }
        }

        public TimeSpan ElapsedTime
        {
            get
            {
                return elapsedTime;
            }

            set
            {
                elapsedTime = value;
                OnPropertyChanged("ElapsedTime");
            }
        }

        #endregion Properties

        public SCADAViewModel()
        {
            configuration = new ConfigReader();
         //   commandExecutor = new FunctionExecutor(this, configuration);
        //    this.acquisitor = new Acquisitor(acquisitionTrigger, this.commandExecutor, this, configuration);
            InitializePointCollection();
            InitializeAndStartThreads();
            logBuilder = new StringBuilder();
            ConnectionState = ConnectionState.DISCONNECTED;
            Thread.CurrentThread.Name = "Main Thread";
        }

        #region Private methods

        private void InitializePointCollection()
        {
            Points = new ObservableCollection<BasePointItem>();
            foreach (var c in configuration.GetConfigurationItems())
            {

                BasePointItem pi = CreatePoint(c, c.NumberOfRegisters, this.commandExecutor);
                if (pi != null)
                    Points.Add(pi);

            }
        }

        private BasePointItem CreatePoint(IConfigItem c, int i, IFunctionExecutor commandExecutor)
        {
            switch (c.RegistryType)
            {
                case PointType.DIGITAL_INPUT:
                    return new DigitalInput(c, commandExecutor, this, configuration, i);

                case PointType.DIGITAL_OUTPUT:
                    return new DigitalOutput(c, commandExecutor, this, configuration, i);

                case PointType.ANALOG_INPUT:
                    return new AnalaogInput(c, commandExecutor, this, configuration, i);

                case PointType.ANALOG_OUTPUT:
                    return new AnalogOutput(c, commandExecutor, this, configuration, i);

                default:
                    return null;
            }
        }

        private void InitializeAndStartThreads()
        {
            InitializeTimerThread();
            StartTimerThread();
        }

        private void InitializeTimerThread()
        {
            timerWorker = new Thread(TimerWorker_DoWork);
            timerWorker.Name = "Timer Thread";
        }

        private void StartTimerThread()
        {
            timerWorker.Start();
        }

        /// <summary>
        /// Timer thread:
        ///		Refreshes timers on UI and signalizes to acquisition thread that one second has elapsed
        /// </summary>
        private void TimerWorker_DoWork()
        {
            while (timerThreadStopSignal)
            {
                if (disposed)
                    return;

                CurrentTime = DateTime.Now;
                ElapsedTime = ElapsedTime.Add(new TimeSpan(0, 0, 1));
                acquisitionTrigger.Set();
                Thread.Sleep(1000);
            }
        }

        #endregion Private methods

        #region IStateUpdater implementation

        public void UpdateConnectionState(ConnectionState currentConnectionState)
        {
            dispather.Invoke((Action)(() =>
            {
                ConnectionState = currentConnectionState;
            }));
        }

        public void LogMessage(string message)
        {
            if (disposed)
                return;

            string threadName = Thread.CurrentThread.Name;

            dispather.Invoke((Action)(() =>
            {
                lock (lockObject)
                {
                    logBuilder.Append($"{DateTime.Now} [{threadName}]: {message}{Environment.NewLine}");
                    LogText = logBuilder.ToString();
                }
            }));
        }

        #endregion IStateUpdater implementation

        public void Dispose()
        {
            disposed = true;
            timerThreadStopSignal = false;
            (commandExecutor as IDisposable).Dispose();
          //  this.acquisitor.Dispose();
            acquisitionTrigger.Dispose();
        }
    }
}
