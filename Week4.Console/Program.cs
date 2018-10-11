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
                // Get the current assembly
                Assembly assembly = Assembly.GetExecutingAssembly();
                // Assembly name and resource stored in assembly
                string resourceName = "Week4.Console.Courses.csv";
                // Get the embedded resource from the assembly
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {   // create a stream reader
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        // create a csv reader dor the stream
                        CsvReader csvReader = new CsvReader(reader);
                        csvReader.Configuration.HasHeaderRecord = false;
                        programmes = csvReader.GetRecords<Programme>().ToList();
                        // Read the records into the desired collection of that type
                        // and iterate over the collection
                        foreach (var item in programmes)
                        {
                            System.Console.WriteLine("{0}", item.ToString());
                        }
                        System.Console.ReadKey();
                    }
                }
        }
    }
}
