using System.ComponentModel.DataAnnotations;

namespace LegendariumWorld
{
    public class Player
    {
        public int Id { get; set; }
        
        [Required]        
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        public int Score { get; set; }
        public int Power { get; set; }
        public int Vision { get; set; }        
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime Birthday { get; set; }
        
        //Navigation Property
        //public List<Player_Location> Player_Locations { get; set; }

    }
}