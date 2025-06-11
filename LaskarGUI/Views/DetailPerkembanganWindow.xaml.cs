using System.Windows;
using LaskarGUI.ViewModels;
using Laskar.CLI.Services;
using System.Diagnostics;
using System.IO;
using Laskar.Shared.Models;

namespace LaskarGUI.Views
{

    public partial class DetailPerkembanganWindow : Window
    {
        public DetailPerkembanganWindow(PerkembanganViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void CetakPDF_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not PerkembanganViewModel vm)
            {
                MessageBox.Show("Data tidak valid.");
                return;
            }

            // Konversi ViewModel ke Model asli
            var data = new PerkembanganSiswa
            {
                Id = vm.Id,
                NamaSiswa = vm.NamaSiswa,
                NomorInduk = vm.NomorInduk,
                Kelas = vm.Kelas,
                Semester = vm.Semester,
                TahunAjaran = vm.TahunAjaran,
                Tanggal = vm.Tanggal,
                CatatanPerKategori = vm.CatatanPerKategori
            };

            string dummyPath = ""; // tidak perlu, karena PdfGenerator akan generate path sendiri
            bool success = PdfGenerator.GenerateReport(data, dummyPath);

            if (success)
            {
                string downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string filename = $"Laporan_Perkembangan_{vm.NamaSiswa.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = Path.Combine(downloads, filename);

                if (File.Exists(fullPath))
                {
                    Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                }

                MessageBox.Show("PDF berhasil dicetak dan disimpan di folder Downloads.", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Gagal mencetak laporan PDF.", "Gagal", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
