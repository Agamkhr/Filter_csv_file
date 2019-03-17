using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
namespace readcsvlib
{
    public class Employee
    {
        public string Emp_id;
        public string First_name;
        public string Last_name;
        public string Location;
        public string Dob;
        public static Employee FromCsv(string line)
        {
            var file_atrributes = line.Split(',');
            return new Employee
            {
                Emp_id = file_atrributes[0],
                First_name = file_atrributes[2],
                Last_name = file_atrributes[4],
                Location = file_atrributes[31],
                Dob = file_atrributes[10]
            };
        }
    }
}