using Ejemplos.DAL;
using Ejemplos.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                context.Grade.Add(auxGrade);
                bool save = context.SaveChanges() > 0;

                if (save)
                    Console.WriteLine("The Grade was sucessfully saved!!");
                else
                    Console.WriteLine("We cant save the grade..");
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

                context.Student.Add(auxStudent);
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

            const string NAME = "David";
            Context context = new Context();
            try
            {
                var StudentsName = context.Student.Where(s => s.Name == NAME).ToList();
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

        public static void UpdatingData()
        {
            //En este ejemplo modificamos el nombre del primer estudiante
            Context context = new Context();

            try
            {
                var student = context.Student.First<Student>();
                student.Name = "Juan";
                bool modified = context.SaveChanges() > 0;

                if (modified)
                    Console.WriteLine("Student modified..");
                else
                    Console.WriteLine("We cant modify the student..");

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

        public static void DeletingData()
        {
            //Deleting first Student

           Context context = new Context();

            try
            {
                var std = context.Student.First<Student>();
                context.Student.Remove(std);
                bool deleted = context.SaveChanges() > 0;

                if (deleted)
                    Console.WriteLine("Student deleted..");
                else
                    Console.WriteLine("We cant delete the student..");

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

        public static void UpdatingOnDisconnectedScenario()
        {
            //Updating First Student 

            Context context = new Context();
            try
            {
                var modifiedStudent = new Student()
                {
                    StudentId = 1,
                    Name = "Robert",
                    GradeId = 1
                };

                List<Student> modifiedStudents = new List<Student>()
                {
                    modifiedStudent
                };

                context.UpdateRange(modifiedStudents);
                bool modified = context.SaveChanges() > 0;
                if (modified)
                    Console.WriteLine("Modified");

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

        public static void ChangeTracker()
        {
            

            Context db = new Context();
            try
            {
                var student = db.Student.First();
                student.Name = "Name was Changed";
                ShowStates(db.ChangeTracker.Entries());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

        }

        private static void ShowStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: { entry.State.ToString()}");
            }
        }


    }



}
