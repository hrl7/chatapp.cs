﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Models
{
   
    public class Room
    {
        
   
        public int Id { get; set; }
   
        public string Name { get; set; }

        [Required]
        [DefaultValue("CURRENT_TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        public List<Message> Messages { get; set; }
    }
}
