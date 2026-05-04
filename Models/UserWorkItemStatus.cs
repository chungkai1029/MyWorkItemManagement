using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWorkItemManagement.Models
{
    public class UserWorkItemStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkItemId { get; set; }
        public bool IsConfirmed { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(WorkItemId))]
        public WorkItem WorkItem { get; set; }
    }
}
