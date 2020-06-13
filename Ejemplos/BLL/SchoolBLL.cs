using Ejemplos.DAL;
using Ejemplos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejemplos.BLL
{
    public class SchoolBLL
    {
        public static void SaveGradeDB()
        {
            //Ejemplo de guardar en DB
           Context context = new Context();

            try
            {
                var auxGrade = new Grade()
                {
                    GradeId = 0,
                    GradeName = "A"

                };
                context.Grades.Add(auxGrade);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("The Student was sucessfully saved!!");
                else
                    Console.WriteLine("We cant save the student..");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void SaveStudentDB()
        {
            //Ejemplo de guardar en DB
            Context context = new Context();

            try
            {
                var auxStudent = new Student()
                {
                    StudentId = 0,
                    Name = "David",
                    GradeId = 1

                };

                context.Students.Add(auxStudent);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("The Student was sucessfully saved!!");
                else
                    Console.WriteLine("We cant save the student..");
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }

        }

        public static void SimpleQuerying()
        {
            //Ejemplo del Querying
            const string NAME = "Michael";
            Context context = new Context();
            try
            {
                var StudentsName = context.Students.Where(s => s.Name == NAME).ToList();
                if (StudentsName != null)
                    Console.WriteLine(StudentsName.Find(s => s.Name == NAME).Name);
                else
                    Console.WriteLine("We cant find the student!!");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                context.Dispose();
            }
        }


    }
}
