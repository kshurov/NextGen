﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskZero.ReadStack
{
    public class Dto {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id
        { get; set; }
    }
}
