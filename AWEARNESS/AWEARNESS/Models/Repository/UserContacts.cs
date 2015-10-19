using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace AWEARNESS.Models.Repository
{
   public class UserContacts
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column("ContactUserId", Order = 1)]
        public string ContactUserId { get; set; }


        public string Relationship { get; set; }
        [ScriptIgnore(ApplyToOverrides = true)]

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
