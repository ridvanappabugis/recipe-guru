using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace recipe_guru.Model.Requests
{
    public class KategorijeSearchRequest
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
