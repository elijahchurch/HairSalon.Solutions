namespace HairSalon.Models
{
    public class Client
    {
        public int ClientId { get; set;}
        public string First_Name { get; set;}
        public string Last_Name { get; set;}
        public string Phone_Number { get; set;}
        public string Email { get; set;}
        public int StylistId { get; set;}
        public Stylist Stylist {get; set;}
    }
}