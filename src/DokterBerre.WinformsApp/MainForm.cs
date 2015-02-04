using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokterBerre.Library;
using DokterBerre.Library.Db;

namespace DokterBerre.WinformsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbPrinters.Items.Clear();

            foreach (var p in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbPrinters.Items.Add(p);
            }

            cmbDokters.Items.Clear();

            var repo = new Repository(ConfigurationManager.ConnectionStrings["dokterberre"].ConnectionString);
            repo.Setup();

            var dokters = repo.GetAllDokters();

            cmbDokters.Items.AddRange(dokters.Select(d => d.Naam).ToArray());

            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbDokters.Items.Count > 0 && cmbPrinters.Items.Count > 0
                && cmbDokters.SelectedIndex > -1 && cmbPrinters.SelectedIndex > -1)
            {
                var pdfFile = Pdf.CreatePdf(cmbDokters.SelectedItem.ToString());
                Pdf.PrintPdf(pdfFile, cmbPrinters.SelectedItem.ToString());
            }
            else
                MessageBox.Show("Peut. Computer says no.");
        }
    }
}
