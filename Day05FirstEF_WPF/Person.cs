﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05FirstEF_WPF
{
    public class Person
    {
        // [Key]
        public int Id { get; set; }

        [Required] // means non-null
        [StringLength(50)] // nvarchar(50)
        public string Name { get; set; }

        [Required]
        [Index] // not uniqe, speeds up lookup operations
        public int Age { get; set; }

        // TODO: find out how to setup a unique index

        /*
        [NotMapped] // in memory only (e.g. computed), not in database
        public string Comment { get; set; }

        [EnumDataType(typeof(GenderEnum))]
        public GenderEnum Gender { get; set; }
        public enum GenderEnum { Male = 1, Female = 2, Other = 4, NA = 3}
        */
    }
}
