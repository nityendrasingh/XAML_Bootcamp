using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XAML_Bootcamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private ObservableCollection<User> _taskList;
        public ObservableCollection<User> TaskList
        {
            set
            {
                if (_taskList != value)
                {
                    this._taskList = value;
                    this.NotifyPropertyChanged("TaskList");
                }
            }
            get
            {
                return _taskList;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public void GetInitialItems()
        {

            _taskList = new ObservableCollection<User>();
            _taskList.CollectionChanged += ContentCollectionChanged;
            _taskList.Add(new User() { Name = "Foo", Price = "100" });
            _taskList.Add(new User() { Name = "Bar", Price = "400" });
            NotifyPropertyChanged("TaskList");
            update_total_textbox();
        }
        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //This will get called when the collection is changed
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged += ItemPropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    ((INotifyPropertyChanged)item).PropertyChanged -= ItemPropertyChanged;
                }
            }
            NotifyPropertyChanged("TaskList");
        }
        public void ItemPropertyChanged(object sender, System.EventArgs e)
        {
            update_total_textbox();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var task = button.DataContext as User;
                task.Price = "0";
                ((ObservableCollection<User>)lvDataBinding.ItemsSource).Remove(task);
            }
            else
            {
                return;
            }
            //this.NotifyPropertyChanged("Total_message");
        }
        private void update_total_textbox()
        {
            total_block.Text = "Total : " + (User.total).ToString();
        }
        public MainPage()
        {
            User user_obj = new User();
            this.InitializeComponent();
            GetInitialItems();
        }

        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            _taskList.Add(new User() { Name = "", Price = "0" });
        }
    }
    public class User : INotifyPropertyChanged
    {
        public static int total = 0;
        private string _name = "";
        private int _price = 0;
        public string Name
        {
            set
            {
                if (_name != value)
                {
                    this._name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
            get
            {
                return _name;
            }
        }
        public string Price
        {
            set
            {
                if ((_price).ToString() != value)
                {
                    total = total - this._price;
                    this._price = Int32.Parse(value);
                    total = total + this._price;
                    this.NotifyPropertyChanged("Price");
                    this.NotifyPropertyChanged("FieldBackground");
                    this.NotifyPropertyChanged("NegValue");
                }
            }
            get
            {
                return _price.ToString();
            }
        }

        public bool FieldBackground
        {
            set
            {
            }
            get
            {
                return _price > 100;
            }
        }

        public bool NegValue
        {
            set
            {
            }
            get
            {
                return _price < 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
