using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    public class Person
    {
        // [key]
        public int Id { get; set; }
        // not null
        [Required]
        // nvarchar(50)
        [StringLength(50)]
        public string Name { get; set; }    

        public int Age { get; set; }




    }
}
