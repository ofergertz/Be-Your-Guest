namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface ILoginRequest
    {
        string Email { get; set; }

        string Password { get; set; }
    }
}