namespace SVLT.InventaryAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string userName);
    }
}
