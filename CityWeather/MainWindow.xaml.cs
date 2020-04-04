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

namespace CityWeather
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<CityForecast> forecasts = new List<CityForecast>();
        List<CityCurrentWeather> cityCurrentWeathers = new List<CityCurrentWeather>();
        List<string> watchedCities = new List<string>();

        ApiService apiService = new ApiService();

        public MainWindow()
        {
            InitializeComponent();

            // uzytkownik to bedzie dodawac w formularzu i te dane beda trzymane w bazie danych
            watchedCities.Add("Wroclaw");
            watchedCities.Add("Poznan");

            // Obslugiwac bledy tutaj bo sie wywala na razie program jak nie ma np. polaczenia z internetem
            /*
            Task.Run(async() => {
                foreach (string city in watchedCities) {
                    CityForecast cityForecast = await apiService.GetCityForecast(city, 3);
                    Console.WriteLine(cityForecast.CityName);
                    Console.WriteLine(cityForecast.Data[0].Temp);
                    forecasts.Add(cityForecast);
                }
            }).Wait();
            */

            Task.Run(async () => {
                foreach (string city in watchedCities)
                {
                    CityCurrentWeather cityCurrentWeather = await apiService.GetCityCurrentWeather(city);
                    cityCurrentWeathers.Add(cityCurrentWeather);
                }
            }).Wait();

            //citiesList.ItemsSource = forecasts;
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
