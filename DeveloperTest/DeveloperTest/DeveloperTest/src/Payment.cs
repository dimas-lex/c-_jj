using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTest
{
    public class Payment: INotifyPropertyChanged
    {
        decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    RaisePropertyChanged("Amount");
                }
            }

        }
        #region NotifyProperty Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
    
}
