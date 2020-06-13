using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplos.Models
{
   public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        public ICollection<Student> Students { get; set; }

        public Grade()
        {
            GradeId = 0;
            GradeName = string.Empty;
 
        }
    }
}
