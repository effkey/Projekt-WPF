

using System.Text.Json;
using System.Windows.Input;
using ToDoList.Core.ViewModels.Helper;

namespace ToDoList.Core.ViewModels.Windows
{
    public class LogInWindowViewModel : User
    {
        public bool IsLogInSuccess { get; set; }
        public string? ErrorResponse { get; set; }
        public ICommand? LogInCommand { get; set; }

        public event EventHandler<bool>? LogInCompleted;

        public LogInWindowViewModel()
        {
            LogInCommand = new RelayCommand(LogInIntoApp);
        }
        private void LogInIntoApp()
        {
            Console.WriteLine("Odpalasie ");
            var logInUserData = new
            {
                username = Username,
                password = Password,
            };
            Console.WriteLine(logInUserData);
            var logInHandler = new ApiHelper("http://kubpi.pythonanywhere.com/");
            var logInDataInJson = JsonSerializer.Serialize(logInUserData);
            var logInResponse = logInHandler.SendPostRequest(logInDataInJson, "login");
            try
            {

                var deserializedResponseData = JsonSerializer.Deserialize<LogInWindowViewModel>(logInResponse) ?? throw new ArgumentException(); ;
                Console.WriteLine("Token logged user: " + deserializedResponseData.Token); 
                Console.WriteLine("Response: " + logInResponse);
                SaveLogInSession(deserializedResponseData);
                IsLogInSuccess = true;
                LogInCompleted?.Invoke(this, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Response: " + logInResponse);
                Console.WriteLine("Blad");
                IsLogInSuccess = false;
                ErrorResponse = logInResponse;
                LogInCompleted?.Invoke(this, false);
            }
        }

        public void SaveLogInSession(User deserializedResponseData)
        {
            var session = new
            {
                deserializedResponseData.Username,
                deserializedResponseData.Token,
            };
            string sessionInJsonFormat = JsonSerializer.Serialize(session);
            File.WriteAllText("logInSession.json", sessionInJsonFormat);
        }
    }
}
