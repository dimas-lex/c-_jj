using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTest
{
    public class Address : INotifyPropertyChanged
    {
        string _address1;
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (_address1 != value)
                {
                    _address1 = value;
                    RaisePropertyChanged("Address1");
                }
            }
        }

        string _zipcode;
        public string Zipcode
        {
            get { return _zipcode; }
            set
            {
                if (_zipcode != value)
                {
                    _zipcode = value;
                    RaisePropertyChanged("Zipcode");
                }
            }
        }

        string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    RaisePropertyChanged("City");
                }
            }
        }

        string _state;
        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged("State");
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
