using Blazored.FluentValidation;
using Client.BusinessComponents.Requests.Identity;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BeMyGuest.Client.Pages.Authentication
{
    public partial class Register
    {
        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated {
            get
            {
                var validator = _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
                return validator;
            }
        } 

        IList<IBrowserFile> _imageToUpload = new List<IBrowserFile>();

        private RegisterRequest _registerRequest = new();
        public Register() { }

        private void UploadFiles(InputFileChangeEventArgs e)
        {
            Clear();
            _imageToUpload.Add(e.GetMultipleFiles().First());
            //TODO upload the files to the server onSubmit
        }
        private async Task SubmitAsync()
        {
        }

        private async Task Clear()
        {
            _imageToUpload.Clear();
            await Task.Delay(100);
        }

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
    }
}
