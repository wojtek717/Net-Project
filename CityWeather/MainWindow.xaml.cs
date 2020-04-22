using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.ComponentModel;

namespace CityWeather
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CityCurrentWeather> cityCurrentWeathers = new List<CityCurrentWeather>();
        CityForecast cityForecast = new CityForecast();

        ApiService apiService = new ApiService();
        CityWeatherContext db = new CityWeatherContext();

        String enteredCityName = "";
        String selectedCity = "";

        public MainWindow()
        {
            InitializeComponent();
            cityCurrentWeathers = createListToDisplayCurrentWeather(getAllCitiesInDBQuery());

            citiesList.ItemsSource = cityCurrentWeathers;
        }

        private List<CityCurrentWeather> createListToDisplayCurrentWeather(IOrderedQueryable<CityDB> query) {
            var cityCurrentWeathers = new List<CityCurrentWeather>();

            Task.Run(async () => {
                foreach (var item in query)
                {
                    var city = item.Name;
                    CityCurrentWeather cityCurrentWeather = await apiService.GetCityCurrentWeather(city);
                    cityCurrentWeathers.Add(cityCurrentWeather);
                }
            }).Wait();

            return cityCurrentWeathers;
        }

        private CityForecast createForecastToDisplay(String city, int forDays)
        {
            Task.Run(async () => {
                cityForecast = await apiService.GetCityForecast(city, forDays);
            }).Wait();

            return cityForecast;
        }

        private IOrderedQueryable<CityDB> getAllCitiesInDBQuery() {
            var query = from b in db.Cities
                        orderby b.Name
                        select b;
            return query;
        }

        private void refreshCurrentWeather() {
            cityCurrentWeathers = createListToDisplayCurrentWeather(getAllCitiesInDBQuery());
            citiesList.ItemsSource = cityCurrentWeathers;
            ICollectionView view = CollectionViewSource.GetDefaultView(cityCurrentWeathers);
            view.Refresh();
        }

        private void addCityButton_Click(object sender, RoutedEventArgs e)
        {
            var name = enteredCityName;
            Console.WriteLine(name);
            var city = new CityDB { Name = name };
            db.Cities.Add(city);
            db.SaveChanges();

            refreshCurrentWeather();
        }

        private void downloadNewDataButton_Click(object sender, RoutedEventArgs e)
        {
            refreshCurrentWeather();
        }


        private void addCityTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Console.WriteLine(textBox.Text);
                enteredCityName = textBox.Text;
            }
        }
        /// <summary>
        /// Function updates user interface wich display selected city's forecast.
        /// Function provides binding items source to take data from.
        /// </summary>
        /// <param name="forecastData">
        /// CityForecast obiect that provides forecast data for city.
        /// </param>
        private void updateForecastUI(CityForecast forecastData) {
            cityForecastName.Text = forecastData.CityName;
            cityForecastList.ItemsSource = forecastData.Data;
        }

        private void citiesList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                // Get selected city name
                CityCurrentWeather context = (CityCurrentWeather)item.DataContext;
                selectedCity = context.Data[0].CityName;

                // Ask API for forecast for that city
                cityForecast = createForecastToDisplay(selectedCity, 3);

                updateForecastUI(cityForecast);
            }
        }
    }
}
