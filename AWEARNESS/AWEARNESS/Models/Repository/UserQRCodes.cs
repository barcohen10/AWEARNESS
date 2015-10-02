using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AWEARNESS.Models.Repository
{
    public class UserQRCodes
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string QRCodeId { get; set; }

        [ScriptIgnore(ApplyToOverrides = true)]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
