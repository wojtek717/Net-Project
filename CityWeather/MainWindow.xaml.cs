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

namespace CityWeather
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CityCurrentWeather> cityCurrentWeathers = new List<CityCurrentWeather>();
        List<string> watchedCities = new List<string>();

        ApiService apiService = new ApiService();

        public MainWindow()
        {
            InitializeComponent();

            // uzytkownik to bedzie dodawac w formularzu i te dane beda trzymane w bazie danych
            watchedCities.Add("Wroclaw");
            watchedCities.Add("Poznan");

            // DB testing
            using (var db = new CityWeatherContext())
            {
            // Create and save a new Blog
            var name = "Warsaw";

            var city = new CityDB { Name = name };
            db.Cities.Add(city);
            db.SaveChanges();

            // Display all Blogs from the database
            var query = from b in db.Cities
                        orderby b.Name
                        select b;

            Console.WriteLine("All cities in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            }


            // Obsługiwanie błędy przy połączeniu z API #4
            Task.Run(async () => {
                foreach (string city in watchedCities)
                {
                    CityCurrentWeather cityCurrentWeather = await apiService.GetCityCurrentWeather(city);
                    cityCurrentWeathers.Add(cityCurrentWeather);
                }
            }).Wait();

            citiesList.ItemsSource = cityCurrentWeathers;
        }

        private void addCityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void downloadNewDataButton_Click(object sender, RoutedEventArgs e)
        {

        }


        private void addCityTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Console.WriteLine(textBox.Text);
            }
        }
    }
}
