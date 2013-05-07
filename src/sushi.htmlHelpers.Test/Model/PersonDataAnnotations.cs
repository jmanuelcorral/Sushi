using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace sushi.htmlHelpers.Test.Model
{
    public class PersonDataAnnotations
    {
        [Display(Name="Código")]
        public Int32 Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Apellido 1")]
        public string FirstSurname { get; set; }
        [Display(Name = "Apellido 2")]
        public string SecondSurname { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        public DateTime BornDate { get; set; }
        [Display(Name = "Fecha Registro")]
        public DateTime Register { get; set; } 
    }
}
