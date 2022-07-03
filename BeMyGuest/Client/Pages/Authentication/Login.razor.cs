using Client.BusinessComponents.Requests.Identity;
using Client.Model.Requests;
using MudBlazor;

namespace BeMyGuest.Client.Pages.Authentication
{
    public partial class Login
    {
        private LoginRequest _loginRequest = new();
        public Login() { }

        private bool _passwordVisibility;
        private InputType _passwordInput = InputType.Password;
        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            if (_passwordVisibility)
            {
                _passwordVisibility = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _passwordVisibility = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }
        //public Login(ILoginRequest loginRequest)
        //{
        //    _loginRequest = loginRequest;
        //}
    }
}
