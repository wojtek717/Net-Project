using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CityWeather
{
    /// <summary>
    /// Interaction logic for ManageCities.xaml
    /// </summary>
    public partial class ManageCities : Window
    {
        DataService dataService = new DataService();

        List<CityDB> citiesInDataBase = new List<CityDB>();
        CityDB selectedCity;

        public ManageCities()
        {
            InitializeComponent();

            createListToDisplayCitiesInDataBase(dataService.getAllCitiesInDBQuery());

            dataBaseCities.ItemsSource = citiesInDataBase;
        }

        /// <summary>
        /// Function creates list of cities that user observe.
        /// </summary>
        /// <param name="query">
        /// Query that returns every city in database.
        /// </param>
        private void createListToDisplayCitiesInDataBase(IOrderedQueryable<CityDB> query)
        {
            List<CityDB> cities = new List<CityDB>();

            foreach (var item in query)
            {
                cities.Add(item);    
            }
            citiesInDataBase = cities;
        }

        private void dataBaseCities_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                selectedCity = (CityDB)item.DataContext;
            }
        }

        /// <summary>
        /// Function refreshes displayed list of cities after changes in database.
        /// </summary>
        private void refreshCurrentWeather()
        {
            createListToDisplayCitiesInDataBase(dataService.getAllCitiesInDBQuery());
            dataBaseCities.ItemsSource = citiesInDataBase;
            ICollectionView view = CollectionViewSource.GetDefaultView(citiesInDataBase);
            view.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCity == null) {
                Console.WriteLine("Selected city is null");
            }
            else {
                dataService.Db.Cities.Remove(selectedCity);
                dataService.Db.SaveChanges();
                refreshCurrentWeather();

                selectedCity = null;
                ((MainWindow)this.Owner).refreshCurrentWeather();
            }
        }
    }
}
