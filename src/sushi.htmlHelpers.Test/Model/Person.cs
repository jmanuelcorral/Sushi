using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sushi.htmlHelpers.Test.Model
{
    public class Person
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime Register { get; set; } 
    }
}
