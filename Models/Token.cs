using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWorkItemManagement.Models
{
    public class Token
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        [Column("Token")]
        public string TokenValue { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool IsLogout { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
