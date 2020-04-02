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
        List<Person> persons = new List<Person>();
        List<CityForecast> forecasts = new List<CityForecast>();

        public MainWindow()
        {
            InitializeComponent();

            ApiService apiService = new ApiService();
            // Nie dziala nie printuje cityName


            Task.Run(async() => {
                var cityForecast = await apiService.GetCityForecast("Wroclaw", 3);
                Console.WriteLine(cityForecast.CityName);
            }).Wait();

            Person person1 = new Person("Wojciech", "Konury", 22);
            Person person2 = new Person("Michalina", "Kmieciak", 21);

            person1.Name = "Puperek";
            Console.WriteLine(person1.Name);


            persons.Add(person1);
            persons.Add(person2);

            citiesList.ItemsSource = persons;
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
