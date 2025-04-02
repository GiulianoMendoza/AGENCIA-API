using Application.Interfaces;
using Application.Mapper;
using Application.UseCase;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Query;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Swagger Authentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Ingrese el token JWT sin el prefijo 'Bearer'. Ejemplo: {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x => {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(connectionString));
//Moto
builder.Services.AddScoped<IMotoService, MotoService>();
builder.Services.AddScoped<IMotoCommand, MotoCommand>();
builder.Services.AddScoped<IMotoQuery, MotoQuery>();
builder.Services.AddScoped<IMotoMapper, MotoMapper>();
//sale
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleCommand, SaleCommand>();
builder.Services.AddScoped<ISaleQuery, SaleQuery>();
builder.Services.AddScoped<ISaleMapper, SaleMapper>();
//salemoto
builder.Services.AddScoped<ISaleMotoService, SaleMotoService>();
builder.Services.AddScoped<ISaleMotoCommand, SaleMotoCommand>();
//client
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddScoped<IClienteMapper, ClientMapper>();
//tech
builder.Services.AddScoped<ITechnService, TechnService>();
builder.Services.AddScoped<ITechnQuery, TechnQuery>();
builder.Services.AddScoped<ITechnCommand, TechnCommand>();
builder.Services.AddScoped<ITechnMapper, TechnMapper>();
//seller
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<ISellerQuery, SellerQuery>();
builder.Services.AddScoped<ISellerCommand, SellerCommand>();
builder.Services.AddScoped<ISellerMapper, SellerMapper>();
//Turn
builder.Services.AddScoped<ITurnService, TurnService>();
builder.Services.AddScoped<ITurnQuery, TurnQuery>();
builder.Services.AddScoped<ITurnCommand, TurnCommand>();
builder.Services.AddScoped<ITurnMapper, TurnMapper>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
