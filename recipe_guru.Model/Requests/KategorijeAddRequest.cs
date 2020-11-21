using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace recipe_guru.Model.Requests
{
    public class KategorijeAddRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}
