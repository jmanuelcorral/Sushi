using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sushi.htmlHelpers.Test.Model
{
    public static class ModelFactories
    {
        public static List<Person> GetPeople10Collection()
        {
            var peoplelist = new List<Person>(10);
            peoplelist.Add(new Person() { Id = 1, Name = "Jose Manuel", FirstSurname = "La Mar", SecondSurname = "De Majo", BornDate = new DateTime(1983, 09, 20), Register = DateTime.Now.AddMonths(-1) });
            peoplelist.Add(new Person() { Id = 2, Name = "Victor", FirstSurname = "Pez", SecondSurname = "Volador", BornDate = new DateTime(1982, 05, 22), Register = DateTime.Now.AddMonths(-2) });
            peoplelist.Add(new Person() { Id = 3, Name = "Jordi", FirstSurname = "Tigre", SecondSurname = "Fiero", BornDate = new DateTime(1981, 12, 21), Register = DateTime.Now.AddMonths(-10) });
            peoplelist.Add(new Person() { Id = 4, Name = "David", FirstSurname = "Leon", SecondSurname = "Peludo", BornDate = new DateTime(1977, 1, 30), Register = DateTime.Now.AddMonths(-121) });
            peoplelist.Add(new Person() { Id = 5, Name = "Marc", FirstSurname = "Jirafa", SecondSurname = "Cuellolargo", BornDate = new DateTime(1975, 06, 1), Register = DateTime.Now.AddMonths(-185) });
            peoplelist.Add(new Person() { Id = 6, Name = "Juan", FirstSurname = "Avion", SecondSurname = "Pesado", BornDate = new DateTime(1956, 05, 12), Register = DateTime.Now.AddMonths(-191) });
            peoplelist.Add(new Person() { Id = 7, Name = "Maria", FirstSurname = "Barco", SecondSurname = "Ligero", BornDate = new DateTime(1963, 06, 23), Register = DateTime.Now.AddMonths(-51) });
            peoplelist.Add(new Person() { Id = 8, Name = "Andres", FirstSurname = "Tren", SecondSurname = "Lento", BornDate = new DateTime(1988, 11, 14), Register = DateTime.Now.AddMonths(-51) });
            peoplelist.Add(new Person() { Id = 9, Name = "Jose Luis", FirstSurname = "Metro", SecondSurname = "Azul", BornDate = new DateTime(1995, 08, 12), Register = DateTime.Now.AddMonths(-1) });
            peoplelist.Add(new Person() { Id = 10, Name = "Ivan", FirstSurname = "Zoo", SecondSurname = "Abandonado", BornDate = new DateTime(2000, 05, 19), Register = DateTime.Now.AddMonths(-1) });
            return peoplelist;
        }
    }
}
