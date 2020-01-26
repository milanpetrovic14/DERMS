using DERMSCommon.SCADACommon;
using DermsUI.Resources;
using DermsUI.ViewModel.PointViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DermsUI.ViewModel
{
    internal class CommandingWindowViewModel:BindableBase
    {
        private DataPoint item;
        public DataPoint Item { get { return item; } set { item = value; } }
        public ushort CommandedValue { get; set; }

        public CommandingWindowViewModel()
        {

        }

        public CommandingWindowViewModel(DataPoint selectedItem)
        {
            Item = selectedItem;
        }

        private ICommand _writeCommand;
        public ICommand WriteCommand { get { return _writeCommand ?? (_writeCommand = new CommandHandler(() => Write(), () => CanExecute)); } }

        public void Write()
        {
            Console.Beep();
        }

        public bool CanExecute { get { return true; } }
    }
}
