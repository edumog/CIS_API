namespace CIS.Models
{
    public partial class ClientDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<string> PhoneNumber { get; set; }
        public IList<string> Addresses { get; set; }
    }
}
