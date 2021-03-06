﻿using System;
using System.Collections.Generic;

namespace recipe_guru.Model.Requests
{
    public class ReceptSearchRequest
    {
        public string Naziv { get; set; }

        public int DuzinaPripreme { get; set; }

        public RatingMark? AverageRating { get; set; }

        public int KategorijaId { get; set; }

        public int KnjigaRecepataId { get; set; }
    }
}
