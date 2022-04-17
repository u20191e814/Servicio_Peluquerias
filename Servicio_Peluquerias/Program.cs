using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Title = "Servicios peluqueria" 

    });

     
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // options.DescribeAllParametersInCamelCase();

    options.IncludeXmlComments(xmlPath);
});

 
builder.Services.AddAuthorization();



var app = builder.Build();

 


app.UseSwagger();
app.UseSwaggerUI(x =>
{

    x.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
});

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();