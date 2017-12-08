using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedUTCDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedUTCDate { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; }

    }
}
