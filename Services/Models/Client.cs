namespace CIS.Models
{
    public partial class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IList<string> PhoneNumber { get; set; }
        public IList<string> Addresses { get; set; }
    }
}
