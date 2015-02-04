using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DokterBerre.Library
{
    public class Pdf
    {
        public static void PrintPdf(string fileName, string printerName)
        {
            string gsArguments;
            string gsLocation;
            ProcessStartInfo gsProcessInfo;
            Process gsProcess;

            gsArguments = string.Format("-ghostscript \"gswin32.exe\" -grey -noquery -printer \"{1}\" \"{0}\"",
                fileName, printerName);
            gsLocation = @"gsprint.exe";

            gsProcessInfo = new ProcessStartInfo();
            gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gsProcessInfo.FileName = gsLocation;
            gsProcessInfo.Arguments = gsArguments;

            gsProcess = Process.Start(gsProcessInfo);

            gsProcess.WaitForExit();
        }

        public static string CreatePdf(string naam)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Paging " + naam;

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            gfx.DrawString("Dag " + naam, font, XBrushes.Black,
                            new XRect(0, 0, page.Width, page.Height),
                            XStringFormats.Center);

            string filename = Path.GetTempFileName();

            document.Save(filename);

            return filename;
        }
    }
}
