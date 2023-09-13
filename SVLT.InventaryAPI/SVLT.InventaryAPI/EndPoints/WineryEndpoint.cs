using SVLT.InventaryAPI.Models;

namespace SVLT.InventaryAPI.EndPoints
{
    public static class WineryEndpoint
    {
        static List<WareHouse> data = new List<WareHouse>();

        public static void AddWineryEndpoints(this WebApplication app)
        {
            app.MapGet("/bodega/{id}", (int id) =>
            {
                var bodega = data.FirstOrDefault(b => b.Id == id);
                if (bodega == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(bodega);
                }
            }).RequireAuthorization();

            app.MapPost("/bodega", (int id, string room, string type, string employe) =>
            {
                var newWareHouse = new WareHouse
                {
                    Id = id,
                    Room = room,
                    Type = type,
                    Employe = employe
                };

                data.Add(newWareHouse);
                return Results.Ok();
            }).RequireAuthorization();

            app.MapPut("/bodega/{id}", (int id, int idMod, string room, string type, string employe) =>
            {
                var updatedBodega = new WareHouse
                {
                    Id = idMod,
                    Room = room,
                    Type = type,
                    Employe = employe
                };

                var existingBodega = data.FirstOrDefault(b => b.Id == id);
                if (existingBodega == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    existingBodega.Id = updatedBodega.Id;
                    existingBodega.Room = updatedBodega.Room;
                    existingBodega.Type = updatedBodega.Type;
                    existingBodega.Employe = updatedBodega.Employe;
                }
                return Results.Ok(existingBodega);
            }).RequireAuthorization();
        }
    }
}