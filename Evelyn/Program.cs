using System.Text.Json.Serialization;
using Evelyn.Application.Interfaces;
using Evelyn.Application.Services;
using Evelyn.Web.Configurations;
using Evelyn.Web.Extensions;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(Options=> Options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEvelynDbContext(builder.Configuration);
builder.Services.AddCustomSwagger();
builder.Services
        .AddScoped<IUserServices, UserServices>()
        .AddScoped<IProjectServices, ProjectServices>()
        .AddScoped<IAddressServices, AddressServices>()
        .AddScoped<IUserProjectServices, UserProjectServices>()
        .AddScoped<IProductServices, ProductServices>();

var app = builder.Build();

app.UseCustomSwagger();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();