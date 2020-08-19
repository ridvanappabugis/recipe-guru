namespace recipe_guru.WebAPI.Database
{
    public enum Role
    {
        ADMIN, USER
    }
    public partial class Uloga
    {
        public int Id { get; set; }
        public Role Naziv { get; set; }
    }
}
