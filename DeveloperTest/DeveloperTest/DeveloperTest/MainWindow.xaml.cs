using DeveloperTest.Src;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeveloperTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _errors = 0;

        Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }

        Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged("SelectedCustomer");
                }
            }
        }

        ObservableCollection<Customer> _customerList;
        public ObservableCollection<Customer> CustomerList
        {
            get { return _customerList; }
            set
            {
                if (_customerList != value)
                {
                    _customerList = value;
                    RaisePropertyChanged("CustomerList");
                }
            }
        }

        public MainWindow()
        {
            this.Customer = new Customer();
            this.CustomerList = Src.dummy.Data.CreateCustomersList();
            this.CustomerList.CollectionChanged += (s, e) =>
            {
                foreach (var customer in CustomerList)
                {
                    customer.PropertyChanged += (ps, pe) =>
                    {
                        RaisePropertyChanged("CustomerList");
                    };
                }
                RaisePropertyChanged("CustomerList");
            };
            this.DataContext = this;
            InitializeComponent();

        }

        void CustomerList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.SelectedCustomer == null)
            {
                global::System.Windows.MessageBox.Show("Please Select a Customer");
            }
            else
            {
                this.SelectedCustomer.FirstName = Customer.FirstName;
                this.SelectedCustomer.LastName = Customer.LastName;
                this.SelectedCustomer.EmailAddress = Customer.EmailAddress;

                if (!(dgrCustomers.SelectedItem as Customer).isActive)
                {
                    global::System.Windows.MessageBox.Show("Customer is not Active");
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

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerList.Add(Customer.Clone() as Customer);

        }

        private void dgrCustomers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Customer = SelectedCustomer;
        }


        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;
        }
    }
}
