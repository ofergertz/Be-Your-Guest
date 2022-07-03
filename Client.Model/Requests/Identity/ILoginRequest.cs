namespace Client.Model.Requests.Identity
{
    public interface ILoginRequest
    {
        string Email { get; set; }

        string Password { get; set; }
    }
}