
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Input;
using ToDoList.Core.ViewModels.Helper;

namespace ToDoList.Core.ViewModels.Windows
{
    public class ResetPasswordWindowViewModel : User
    {
        public bool IsResetSuccess { get; set; }

        public string? ResetEmail { get; set; }

        public event EventHandler<bool>? ResetInCompleted;
        public ICommand? ResetPasswordCommend { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
        public ResetPasswordWindowViewModel()
        {
            ResetPasswordCommend = new RelayCommand(ResetPassword);
        }

        public void ResetPassword()
        {
            var UserData = new
            {
                email = ResetEmail,
            };
            var resetPasswordHandler = new ApiHelper("http://kubpi.pythonanywhere.com/");
            var userDataInJson = JsonSerializer.Serialize(UserData);
            var resetPasswordResponse = resetPasswordHandler.SendPostRequest(userDataInJson, "send-password-reset-token");
            Console.WriteLine("Response: " + resetPasswordResponse);
            Message = resetPasswordResponse;
            try
            {
                var deserializedResponseData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(resetPasswordResponse) ?? throw new ArgumentException(); ;
                List<string> values = deserializedResponseData.Values.FirstOrDefault() ?? throw new ArgumentException();
                Message = String.Join(" ", values);
                Console.WriteLine("Response: " + Message);
                IsResetSuccess = true;
                ResetInCompleted?.Invoke(this, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Response: " + Message);
                Console.WriteLine("Blad");
                IsResetSuccess = false;
                ResetInCompleted?.Invoke(this, false);
            }
        }
    }
}
