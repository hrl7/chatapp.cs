using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Room Room { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}
