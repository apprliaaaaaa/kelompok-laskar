using System;
using System.IO;
using Laskar.Shared.Models;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using Laskar.Shared.Models;

namespace Laskar.CLI.Services
{
    public class PdfGenerator
    {
        public static bool GenerateReport(PerkembanganSiswa data, string filePath)
        {
            try
            {
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = $"Laporan Perkembangan - {data.NamaSiswa}";

                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont titleFont = new XFont("Times New Roman", 16);
                XFont labelFont = new XFont("Times New Roman", 12);
                XFont textFont = new XFont("Times New Roman", 12);
                XTextFormatter tf = new XTextFormatter(gfx);

                double y = 40;

                void DrawLabelValue(string label, string value)
                {
                    gfx.DrawString(label, labelFont, XBrushes.Black, 40, y);
                    gfx.DrawString($": {value}", textFont, XBrushes.Black, 150, y);
                    y += 20;
                }

                void DrawSection(string title, string content)
                {
                    gfx.DrawString(title, labelFont, XBrushes.Black, 40, y);
                    y += 20;
                    tf.DrawString(content, textFont, XBrushes.Black, new XRect(40, y, page.Width - 80, 100), XStringFormats.TopLeft);
                    y += 110;
                }

                // Isi PDF
                gfx.DrawString("Laporan Perkembangan Siswa", titleFont, XBrushes.Black, new XRect(0, y, page.Width, 30), XStringFormats.TopCenter);
                y += 50;

                // Data Siswa
                DrawLabelValue("Nama Siswa", data.NamaSiswa);
                DrawLabelValue("Nomor Induk", data.NomorInduk);
                DrawLabelValue("Kelas", data.Kelas);
                DrawLabelValue("Semester", data.Semester.ToString());
                DrawLabelValue("Tahun Ajaran", data.TahunAjaran.ToString());
                DrawLabelValue("Tanggal Cetak", data.Tanggal.ToString("dd MMM yyyy"));

                y += 20;
                gfx.DrawString("Catatan Perkembangan:", labelFont, XBrushes.Black, new XRect(40, y, page.Width - 80, 20), XStringFormats.TopLeft);
                y += 30;

                foreach (var catatan in data.CatatanPerKategori)
                {
                    gfx.DrawString("• " + catatan.Key.ToString(), labelFont, XBrushes.Black, new XRect(60, y, page.Width - 100, 20), XStringFormats.TopLeft);
                    y += 20;
                    gfx.DrawString(catatan.Value, labelFont, XBrushes.Black, new XRect(80, y, page.Width - 120, 60), XStringFormats.TopLeft);
                    y += 70;
                }
                string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string fileName = $"Laporan_Perkembangan_{data.NamaSiswa.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                filePath = Path.Combine(downloadsPath, fileName);
                doc.Save(filePath);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Gagal mencetak PDF: " + ex.Message);
                return false;
            }

        }
    }
}