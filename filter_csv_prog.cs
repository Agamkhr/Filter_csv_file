using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using readcsvlib;

namespace readcsv
{
    class filtercsv
    {
        static void Main(string[] args)
        {
            List<Employee> csvfile = File.ReadAllLines(@"C:\100.csv")
                                    .Skip(1)
                                    .Select(Employee.FromCsv)
                                    .ToList();
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("\nEnter the filter method");
                Console.WriteLine("1. location  2. DOB  3.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        filter_by_loc();
                        break;
                    case 2:
                        filter_by_dateofbirth();
                        break;
                    case 3:
                        flag = false;
                        break;
                }
            }
            void filter_by_loc()
            {
                Console.WriteLine("\nEnter the location");
                string Filter_Location = Console.ReadLine();
                var filter_data = csvfile.Where(e => e.Location == Filter_Location).ToList();
                foreach (var item in filter_data)
                {
                    Console.WriteLine("\nEmployee_id: " + item.Emp_id);
                    Console.WriteLine("Name : " + item.First_name + " " + item.Last_name);
                    Console.WriteLine("DOB : " + item.Dob);
                    Console.WriteLine("Location: " + item.Location);
                }
            }
            void filter_by_dateofbirth()
            {
                Console.WriteLine("\nEnter the date of birth");
                DateTime Dateofbirth = DateTime.Parse(Console.ReadLine());
                var filter_data = csvfile.Where(e => (DateTime.Parse(e.Dob)) > Dateofbirth)
                                  .Select(e => e);
                foreach (var item in filter_data)
                {
                    Console.WriteLine("\nEmployee_id: " + item.Emp_id);
                    Console.WriteLine("Name : " + item.First_name + " " + item.Last_name);
                    string date = String.Format("{0:MM/dd/yyyy}", item.Dob);
                    Console.WriteLine("DOB : " + date);
                    Console.WriteLine("Location: " + item.Location);
                }
            }
        }
    }
}