using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using Laskar.Shared.Models;

namespace LaskarGUI.Views
{
    public partial class LoginWindow : Window
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5011/") };
        public string Role { get; private set; } = "";

        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Role = "";

            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Username dan Password wajib diisi.", "Validasi Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var loginData = new
            {
                Username = UsernameBox.Text,
                Password = PasswordBox.Password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("api/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<LoginResponse>(resultJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    string rawState = result?.State?.ToLower() ?? "";

                    this.Hide();

                    if (rawState.Contains("admin"))
                    {
                        Role = "admin";
                        var win = new AdminWindow();
                        win.ShowDialog();
                    }
                    else if (rawState.Contains("guru"))
                    {
                        Role = "guru";
                        var win = new GuruWindow();
                        win.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show($"Role tidak dikenali: {result?.State}", "Login Gagal", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    this.Show(); // tampilkan kembali login window setelah window utama ditutup
                }
                else
                {
                    MessageBox.Show("Login gagal. Username atau password salah.", "Login Gagal", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat login: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Activated(object? sender, EventArgs e)
        {
            UsernameBox.Text = string.Empty;
            PasswordBox.Password = string.Empty;
        }



    }
}
