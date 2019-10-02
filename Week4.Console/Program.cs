using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Programme> programmes = new List<Programme>();
            List<Student> students = new List<Student>();
            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
                // Assembly name and resource stored in assembly
                string courseResourceName = "Week4.Console.Courses.csv";
                programmes = Get<Programme>(courseResourceName);
            string studentResourceName = "Week4.Console.StudentList1.csv";
            students = Get<Student>(studentResourceName);

            // Get the embedded resource from the assembly
            foreach (var item in programmes)
                System.Console.WriteLine("{0}", item.ToString());

            foreach(var item in students)
                System.Console.WriteLine("{0}", String.Concat(new string[] {item.StudentID," ",item.FirstName," ", item.SecondName  }));

            System.Console.ReadKey();

        }


        public static List<T> Get<T>(string resourceName)
        {
            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {   // create a stream reader
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // create a csv reader dor the stream
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    return csvReader.GetRecords<T>().ToList();
                }
            }
        }
    }

        
}
