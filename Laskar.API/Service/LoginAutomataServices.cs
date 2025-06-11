using Laskar.Shared.Models;

namespace Laskar.API.Services
{
    public class LoginAutomataService
    {
        private LoginState currentState = LoginState.Start;
        private readonly Dictionary<string, User> userDatabase = new();
        private User? loggedInUser;

        public LoginAutomataService()
        {
            userDatabase["admin01"] = new User("admin01", "adminpass", UserRole.Admin);
            userDatabase["guru01"] = new User("guru01", "gurupass", UserRole.Guru);
        }

        public string Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username dan password tidak boleh kosong.");

            if (userDatabase.ContainsKey(username) && userDatabase[username].Password == password)
            {
                loggedInUser = userDatabase[username];
                currentState = LoginState.Authenticated;
                return Transition(loggedInUser.Role);
            }
            else
            {
                currentState = LoginState.Start;
                loggedInUser = null;
                return "Login gagal. Username atau password salah.";
            }
        }



        private string Transition(UserRole role)
        {
            return role switch
            {
                UserRole.Admin => (currentState = LoginState.AdminPanel, "Selamat datang Admin.").Item2,
                UserRole.Guru => (currentState = LoginState.GuruPanel, "Selamat datang Guru.").Item2,
                _ => "Role tidak dikenali."
            };
        }
        public void AddUser(User newUser)
        {
            if (!userDatabase.ContainsKey(newUser.Username))
            {
                userDatabase[newUser.Username] = newUser;
            }
        }


        public string Logout()
        {
            currentState = LoginState.End;
            loggedInUser = null;
            return "Anda telah logout.";
        }
        public string GetCurrentRole()
        {
            return currentState.ToString().Replace("LoggedIn", "");
        }


        public bool IsLoggedIn =>
           currentState == LoginState.Authenticated ||
           currentState == LoginState.AdminPanel ||
           currentState == LoginState.GuruPanel;

        public LoginState GetCurrentState() => currentState;
    }
}
