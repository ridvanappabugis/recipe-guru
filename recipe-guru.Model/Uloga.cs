﻿namespace recipe_guru.Model
{
    public enum Role
    {
        ADMIN, VISITOR, RESTAURANT_OWNER
    }
    public partial class Uloga
    {
        public int Id { get; set; }

        public Role Naziv { get; set; }
    }
}