using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace recipe_guru.Model.Requests
{
    public class ReceptUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }

        public long? BrojPregleda { get; set; } = 0;

        [Required(AllowEmptyStrings = false)]
        public string DuzinaPripreme { get; set; }

        public bool Public { get; set; } = true;

        [Required]
        public ImageResource GlavnaSlika { get; set; }

        [Required]
        public ICollection<string> PotrebniSastojci { get; set; }

        [Required]
        public long KnjigaRecepataId { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();

        [Required]
        public virtual ICollection<int> KategorijeId { get; set; }

        [Required]
        public virtual ICollection<ReceptKorak> ReceptKoraci { get; set; } 
    }
}
