using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DokterBerre.Library;
using DokterBerre.Library.Db;

namespace DokterBerre.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            try
            {
                var repo = new Repository(ConfigurationManager.ConnectionStrings["dokterberre"].ConnectionString);
                repo.Setup();

                var dokter = repo.GetAllDokters().First();

                var pdfFile = Pdf.CreatePdf(dokter.Naam);
                Pdf.PrintPdf(pdfFile, dokter.Printer);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }

        
    }
}
