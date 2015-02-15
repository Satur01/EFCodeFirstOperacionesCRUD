using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using EFCodeFirstOperacionesCRUD.Annotations;
using EFCodeFirstOperacionesCRUD.EntityFramework.Context;
using EFCodeFirstOperacionesCRUD.EntityFramework.Entities;

namespace EFCodeFirstOperacionesCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Fields

        private Customer _currentCustomer;
        private ObservableCollection<Customer> _customers;

        #endregion

        #region Properties

        public Customer CurrentCustomer
        {
            get { return _currentCustomer ?? (_currentCustomer = new Customer()); }
            set
            {
                _currentCustomer = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Init();
            this.DataContext = this;
        }

        #region Methods

        public void Init()
        {
            using (var context = new OperationsContext())
            {
                Customers = new ObservableCollection<Customer>(context.Customers);
            }
        }

        #endregion

        #region Event handlers

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new OperationsContext())
            {
                if (CurrentCustomer.CustomerId == 0)
                {
                    context.Customers.Add(CurrentCustomer);
                }
                else
                {
                    var selectedCustomer =
                        context.Customers
                        .FirstOrDefault(pre => pre.CustomerId == CurrentCustomer.CustomerId);
                    if (selectedCustomer != null)
                    {
                        selectedCustomer.FirstName = CurrentCustomer.FirstName;
                        selectedCustomer.LastName = CurrentCustomer.LastName;
                    }
                }
                context.SaveChanges();
                Customers = new ObservableCollection<Customer>(context.Customers);
            }
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new OperationsContext())
            {
                var selectedCustomer =
                                context.Customers
                                .FirstOrDefault(pre => pre.CustomerId == CurrentCustomer.CustomerId);
                if (selectedCustomer != null)
                {
                    context.Customers.Remove(selectedCustomer);
                }
                context.SaveChanges();
                Customers = new ObservableCollection<Customer>(context.Customers);
            }
        }

        #endregion

        #region INotifyPropertyChanged Elements

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
