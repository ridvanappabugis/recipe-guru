namespace recipe_guru.Model
{
    public enum Role
    {
        ADMIN, VISITOR, USER
    }
    public partial class Uloga
    {
        public int Id { get; set; }
        public Role Naziv { get; set; }
    }
}