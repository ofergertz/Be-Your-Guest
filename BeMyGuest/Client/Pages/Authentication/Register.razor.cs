using BeMyGuest.Shared.Model.DAL.Conectivity.Roles;
using Blazored.FluentValidation;
using Client.BusinessComponents.Requests.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MudBlazor;
using System.Security.Cryptography;

namespace BeMyGuest.Client.Pages.Authentication
{
    public partial class Register
    {
        private FluentValidationValidator _fluentValidationValidator;
        private bool userProfessional { get; set; } = false;
        private List<string> ListOfProffesionals { get; set; }=null;

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

        private void SaveChoose(IEnumerable<string> e)
        {
            _registerRequest.Proffesion = e.ToList();
        }

        private void UploadFiles(InputFileChangeEventArgs e)
        {
            Clear();
            _imageToUpload.Add(e.GetMultipleFiles().First());
        }
        private async Task SubmitAsync()
        {
            //hash password
            _registerRequest.ProfilePicture = await SerializeProfilePicture();
            //_registerRequest.ConfirmPassword = null;
            var result = await _authenticationManager.Register(_registerRequest);
            if (result.Succeeded)
                _navigationManager.NavigateTo("/");
        }

        private async Task<string> SerializeProfilePicture()
        {
            if (!_imageToUpload.Any())
                return string.Empty;

            var image = _imageToUpload.First();
            var format = "image/png";
            var resizedImage = await image.RequestImageFileAsync(format, 200, 200);
            var buffer = new byte[resizedImage.Size];
            await resizedImage.OpenReadStream().ReadAsync(buffer);
            return $"data:{format};base64,{Convert.ToBase64String(buffer)}";
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

        protected override async Task OnInitializedAsync()
        {
            var roles = await _rolesManager.GetAllRoles();
            ListOfProffesionals = roles.Data;
        }
    }
}
