using MAUItestworkForRobotX.Authentification;
using System.Net;

namespace MAUItestworkForRobotX
{
    public partial class AuthentificationPage : ContentPage
    {

        public AuthentificationPage()
        {
            InitializeComponent();
        }


        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            HideKeyboard();
            
            _LoginResultLabel.Text = string.Empty;
            _LoginResultImage.Source = null;

            _waitingForResponceIndicator.IsRunning = true;
            HttpStatusCode statusCode = HttpStatusCode.BadGateway;

            try
            {
                statusCode = await Authentificate.GetAuth(_LoginEntry.Text, _PasswordEntry.Text);
            }
            catch(Exception ex) 
            {
                _LoginResultLabel.TextColor = new Color(255, 0, 0);
                _LoginResultLabel.Text = ex.Message;
                return;
            }
            finally
            {
                _waitingForResponceIndicator.IsRunning = false;
            }

            if (statusCode == HttpStatusCode.OK)
            {
                _LoginResultLabel.TextColor = new Color(0, 0, 0);
                var userName = Authentificate.AuthResponseData?.Client.FullName;
                _LoginResultLabel.Text = $"Добро пожаловать, {userName}!";
            }
            else
            {
                _LoginResultLabel.TextColor = new Color(255, 0, 0);
                _LoginResultLabel.Text = $"Ошибка авторизации!";
            }

            _PasswordEntry.Text = string.Empty;
            _PasswordEntry.Unfocus();
            _LoginResultImage.Source = ImageSource.FromUri(new Uri($"https://http.cat/{(int)statusCode}"));
        }

        private void _PasswordEntry_Completed(object sender, EventArgs e)
        {
            _PasswordEntry.Unfocus();
            LogInButton_Clicked(_LogInButton, new EventArgs());
        }

        private async void HideKeyboard()
        {
            if (_PasswordEntry.IsSoftInputShowing())
            {
                await _PasswordEntry.HideSoftInputAsync(CancellationToken.None);
            }
        }
    }

}
