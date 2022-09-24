namespace servingApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                 builder =>builder.WithOrigins("http://localhost:4200")
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.MapGet("/characters", (HttpContext httpContext) =>
            {

                string fileContent = File.ReadAllText("StarWars.json");
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Character>>(fileContent);

                return items;
            })
            .WithName("GetCharacters");

            app.Run();
        }
    }
}