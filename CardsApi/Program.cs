using CardsApi;
using CardsApi.Authentication;
using CardsApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CardsDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.RegisterMappers();
builder.RegisterRepositories();
builder.RegisterServices();
builder.RegisterValidators();

builder.Services.AddAuthentication(BasicAuthenticationOptions.Scheme)
    .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>
    (BasicAuthenticationOptions.Scheme, options => { });

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
