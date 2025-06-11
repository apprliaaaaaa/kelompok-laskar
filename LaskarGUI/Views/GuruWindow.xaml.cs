using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Laskar.Shared.Models;
using Laskar.CLI.Services;

namespace LaskarGUI.Views
{
    public partial class GuruWindow : Window
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5077/") };

        public GuruWindow()
        {
            InitializeComponent();
        }

        private async void Simpan_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NamaSiswaBox.Text) ||
                string.IsNullOrWhiteSpace(NomorIndukBox.Text) ||
                string.IsNullOrWhiteSpace(KelasBox.Text) ||
                string.IsNullOrWhiteSpace(SemesterBox.Text) ||
                string.IsNullOrWhiteSpace(TahunAjaranBox.Text))
            {
                MessageBox.Show("Semua data wajib diisi.");
                return;
            }

            if (!int.TryParse(SemesterBox.Text, out int semester) ||
                !int.TryParse(TahunAjaranBox.Text, out int tahun))
            {
                MessageBox.Show("Semester dan Tahun Ajaran harus berupa angka.");
                return;
            }

            var dto = new InputPerkembanganDto
            {
                NamaSiswa = NamaSiswaBox.Text,
                NomorInduk = NomorIndukBox.Text,
                Kelas = KelasBox.Text,
                Semester = semester,
                TahunAjaran = tahun,
                Kategori = new KategoriPerkembangan
                {
                    NilaiAgama = AgamaBox.Text,
                    JatiDiri = JatiDiriBox.Text,
                    LiterasiDanSTEM = LiterasiBox.Text,
                    ProyekPenguatanPancasila = P5Box.Text
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            try
            {
                var res = await client.PostAsync("api/perkembangan", content);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("✅ Catatan perkembangan berhasil ditambahkan!\n\n", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message);
            }
            NamaSiswaBox.Text = "";
            NomorIndukBox.Text = "";
            KelasBox.Text = "";
            AgamaBox.Text = "";
            JatiDiriBox.Text = "";
            LiterasiBox.Text = "";
            P5Box.Text = "";


        }

        private void LihatSemua_Click(object sender, RoutedEventArgs e)
        {
            var listWindow = new PerkembanganListWindow();
            listWindow.ShowDialog();
        }



        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.PostAsync("api/logout", null); // ⬅️ Reset backend state
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Gagal logout dari server: " + ex.Message);
            }

            this.Close(); // tutup window, LoginWindow akan muncul lagi
        }

    }
}
