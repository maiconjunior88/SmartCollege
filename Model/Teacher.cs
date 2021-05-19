using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
    }
}
