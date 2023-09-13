namespace SVLT.InventaryAPI.EndPoints
{
    public static class CategoryProductEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddCategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/category", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/category", (string type, string name, int stock) =>
            {
                data.Add(new { type, name , stock});
                return Results.Ok();
            }).RequireAuthorization();
        }
    }
}
