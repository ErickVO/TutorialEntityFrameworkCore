using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ejemplos.Models
{
    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }

        public Student()
        {
            StudentId = 0;
            Name = string.Empty;
            GradeId = 0;
        }
    }
}
