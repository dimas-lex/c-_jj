using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DeveloperTest.Src
{
    public class Customer : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }

        }

        string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }

        }

        string _email;
        public string EmailAddress
        {
            get { return _email; }
            set
            { 
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged("EmailAddress");
                }
            }
        }

        Address _homeAddress;
        public Address HomeAddress
        {
            get { return _homeAddress; }
            set
            {
                if (_homeAddress != value)
                {
                    _homeAddress = value;
                    RaisePropertyChanged("HomeAddress");
                }
            }
        }

        Address _mailingAddress;
        public Address MailingAddress
        {
            get { return _mailingAddress; }
            set
            {
                if (_mailingAddress != value)
                {
                    _mailingAddress = value;
                    RaisePropertyChanged("MailingAddress");
                }
            }
        }

        bool _isActive;
        public bool isActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    RaisePropertyChanged("isActive");
                }
            }
        }

        ObservableCollection<Payment> _payments;
        public ObservableCollection<Payment> Payments
        {
            get { return _payments; }
            set
            {
                if (_payments != value)
                {
                    _payments = value;
                    RaisePropertyChanged("Payments");
                }
            }
        }

        ObservableCollection<Invoice> _invoices;
        public ObservableCollection<Invoice> Invoices
        {
            get { return _invoices; }
            set
            {
                if (_invoices != value)
                {
                    _invoices = value;
                    RaisePropertyChanged("Invoices");
                }
            }
        }

        public Customer()
        {
            isActive = true;
        }

 
        public Customer(string firstName, string lastName, string email, bool isActive)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            this.isActive = isActive;
        }

        decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    RaisePropertyChanged("Balance");
                }
            }

        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName) || FirstName.Length < 3)
                        result = "Please enter a valid First Name";
                }
                if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName) || LastName.Length < 3)
                        result = "Please enter a valid Last Name";
                }
                if (columnName == "EmailAddress")
                {
                    if (string.IsNullOrEmpty(EmailAddress) || !(new RegexUtilities().IsValidEmail(EmailAddress)))
                        result = "Please enter a valid Email Address";
                }
                return result;
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

        public object Clone()
        {
            Customer newCustomer = new Customer(this.FirstName, this.LastName, this.EmailAddress, true);

            return newCustomer;
        }
        private void IsValidEmail (Customer c)
        {
            
        }
        #endregion
    }
}
