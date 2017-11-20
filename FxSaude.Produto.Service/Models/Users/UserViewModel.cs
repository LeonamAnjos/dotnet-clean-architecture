namespace FxSaude.Produto.Service.Models.Users
{
    public class UserViewModel
    {
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nickname} - {Name}";
        }
    }
}