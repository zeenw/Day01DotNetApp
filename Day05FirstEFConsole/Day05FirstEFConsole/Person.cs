using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05FirstEFConsole
{
    public class Person
    {
        // [Key] primery key
        public int Id { get; set; }
        [Required] // not null
        [StringLength(50)] // nvarchar(50)
        public string Name { get; set; }
        [Required]
        [Index] // not uniqe
        public int Age { get; set; }
        [NotMapped]
        public string Comment { get; set; }


    }
}
