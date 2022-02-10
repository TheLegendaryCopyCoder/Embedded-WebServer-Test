using WebApi.Controllers;

namespace WebApi
{
    public class WebServer
    {
        public async Task Start(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                ContentRootPath = AppContext.BaseDirectory,
                Args = args
            });
            builder.WebHost.UseUrls(new string[] { "https://localhost:7001", "http://localhost:7000" });
            // Add services to the container.

            IMvcBuilder mvcBuilder = builder.Services.AddControllers();

            // NOTE: This is the workaround.
            // Uncomment in order to make controller discoverable when running from another .NET CORE app.
            //mvcBuilder.AddApplicationPart(typeof(WeatherForecastController).Assembly);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
