using System;
using System.Collections.Generic;

namespace recipe_guru.WebAPI.Database
{
    public enum Role
    {
        ADMIN, VISITOR, USER
    }
    public partial class Uloge
    {
        public int Id { get; set; }
        public Role Naziv { get; set; }
    }
}
