namespace amazen_server.Models
{
    public class Wishlist
    {
        public string Name {get;set;}
        public Profile Creator {get;set;}
        public string CreatorId {get;set;}
        public int Id {get;set;}
        // public bool IsPublic {get;set;}
    }
}