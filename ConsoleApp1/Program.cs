﻿using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    class Program
    {
        static int InsertedId;

        static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                db.Database.Log = Console.WriteLine;

                //var department = db.Department.Include(x => x.Course);

                //foreach (var dept in department)
                //{
                //    Console.WriteLine(dept.Name);

                //    foreach (var item in dept.Course)
                //    {
                //        Console.WriteLine("\t" + item.Title);
                //    }
                //}

                var d = db.Department.Find(25);
                d.Name = "John" + DateTime.Now;
                Console.ReadLine();
                db.SaveChanges();

                //var d = db.Department.Find(1);

                //d.Name += "!";

                //db.SaveChanges();

                //QueryCourse(db);

                //InsertDepartment(db);

                //UpdateDepartment(db);

                //RemoveDepartment(db);
            }
        }

        private static void InsertDepartment(ContosoUniversityEntities db)
        {
            var dept = new Department()
            {
                Name = "Jed",
                Budget = 100,
                StartDate = DateTime.Now,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            };

            db.Department.Add(dept);
            db.SaveChanges();

            InsertedId = dept.DepartmentID;
        }

        private static void UpdateDepartment(ContosoUniversityEntities db)
        {
            var dept = db.Department.Find(InsertedId);
            dept.Name = "John";
            db.SaveChanges();
        }

        private static void RemoveDepartment(ContosoUniversityEntities db)
        {
            db.Department.Remove(db.Department.Find(InsertedId));
            db.SaveChanges();
        }

        private static void QueryCourse(ContosoUniversityEntities db)
        {
            var data = from p in db.Course select p;

            foreach (var item in data)
            {
                Console.WriteLine(item.CourseID);
                Console.WriteLine(item.Title);
                Console.WriteLine();
            }
        }
    }
}
