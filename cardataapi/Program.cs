namespace cardataapi;
using CARDataLib;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        string? cardatadb = builder.Configuration.GetConnectionString("Default");
        if(cardatadb == null)
        {
            throw new Exception("Databasefejl");
        }
        builder.Services.AddSingleton<CarDataRepository>(new CarDataRepository(cardatadb));

        // builder.WebHost.UseUrls("https://0.0.0.0:5000");

        builder.Services.AddCors(options =>
                {
                options.AddPolicy("AllowOnlyGetPost",
                        builder => builder.AllowAnyOrigin()
                        .WithMethods("GET", "POST")
                        .AllowAnyHeader());
                });
        var app = builder.Build();
        app.UseCors("AllowOnlyGetPost");

        app.UseHttpsRedirection();
        app.MapControllers();

        // app.Run();        

        app.Run("https://0.0.0.0:5001");
    }
}
