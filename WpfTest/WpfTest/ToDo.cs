using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    public class ToDo
    {
        // [key] primery key
        public int Id { get; set; }
        // not null
        [Required]
        // nvarchar(100)
        [StringLength(100)]
        public string Task { get; set; }
        [Required]
        public int Difficulty { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        public enum enumStatus { Pending, Done, Delegated }

        public string Status { get; set; }


}
}
