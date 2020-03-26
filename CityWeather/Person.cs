using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityWeather
{
    public class Person
    {
        String name;
        String surName;
        int age;

        public Person(String name, String surName, int age) {
            this.Name = name;
            this.surName = surName;
            this.Age = age;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
