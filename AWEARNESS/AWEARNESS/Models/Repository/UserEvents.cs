using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AWEARNESS.Models.Repository
{
    public class UserEvents
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string EventId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}