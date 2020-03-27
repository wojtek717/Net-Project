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
using System.Windows.Shapes;

namespace CityWeather
{
    /// <summary>
    /// Logika interakcji dla klasy ManageCitiesWindow.xaml
    /// </summary>
    public partial class ManageCitiesWindow : Window
    {
        public ManageCitiesWindow()
        {
            InitializeComponent();

            Person person1 = new Person("Wojciech", "Konury", 22);
            Person person2 = new Person("Michalina", "Kmieciak", 21);

            person1.Name = "Puperek";
            Console.WriteLine(person1.Name);

            List<Person> persons = new List<Person>();
            persons.Add(person1);
            persons.Add(person2);

            watchedCitiesList .ItemsSource = persons;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
