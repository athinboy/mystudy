using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
//builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    });

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapPost("/posttest", (context) => { return Task.Run(() => { }); });
app.MapPost("/posttest2", new RequestDelegate(async (context) => {   await Task.Run(() => { }); }));

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "My API V1");
});
app.UseSwagger();


app.Run();
