


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


WebApplication app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}


app.MapControllers();

app.Run("http://localhost:8080");
