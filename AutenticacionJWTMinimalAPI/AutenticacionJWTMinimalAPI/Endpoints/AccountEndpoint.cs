using AutenticacionJWTMinimalAPI.Auth;


namespace AutenticacionJWTMinimalAPI.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authhService) =>
            {
                if (login == "admin" && password == "12345")
                {
                    var token = authhService.Authenticate(login);

                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });
        }
    }
}
