using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
