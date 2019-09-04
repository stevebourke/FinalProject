using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }


        [Required]
        public int MessageTime { get; set; }


        [Required]
        public int SenderID { get; set; }


        [Required]
        public int RecipientID { get; set; }


        [Required]
        public string MessageBody { get; set; }
    }
}
