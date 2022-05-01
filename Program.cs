using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(authenticationScheme =>
{
    authenticationScheme.RequireHttpsMetadata = false;// https gerekli de�il
    authenticationScheme.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer ="http://localhost",
        ValidAudience ="http://localhost",
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("alperalbostansa!5054774994")),//jwt sitesindeki �ifre
        ValidateIssuerSigningKey =true, 
        ValidateLifetime =true,
        ClockSkew =TimeSpan.Zero //saat fark� olu�mamas� i�in

    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();//�st k�s�mda olacak
app.UseAuthorization();

app.MapControllers();

app.Run();
