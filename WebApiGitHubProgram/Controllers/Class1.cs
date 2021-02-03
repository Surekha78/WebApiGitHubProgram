using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Controllers
{
    
    
		public class Program
		{
			public static void Main()
			{
			IList<Student> studentList = new List<Student>()
				{
			new Student() { StudentID = 1, StudentName = "priya", Age = 13 } ,
			new Student() { StudentID = 2, StudentName = "teena",  Age = 21 } ,
			new Student() { StudentID = 3, StudentName = "pooja",  Age = 18 } ,
			new Student() { StudentID = 4, StudentName = "Ram" , Age = 22} ,
			new Student() { StudentID = 5, StudentName = "srii" , Age = 27 }
		};
				
				var avgAge = studentList.Average(s => s.Age);
				var totalStudent = studentList.Count();
				var oldest = studentList.Max( s =>s.Age);
				var sumofAge = studentList.Sum( s =>s.Age);


				Console.WriteLine("Average Age of Student: {0}", avgAge);
				Console.WriteLine("Total Students: {0}", totalStudent);
				Console.WriteLine("Oldest Student Age: {0}", oldest);
				Console.WriteLine("sum of allStudent's Age: {0}", sumofAge);
			Console.ReadLine();


			}
		}

		public class Student
		{

			public int StudentID { get; set; }
			public string StudentName { get; set; }
			public int Age { get; set; }
		}
}
