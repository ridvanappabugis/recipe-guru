using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public partial class Uloge
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
