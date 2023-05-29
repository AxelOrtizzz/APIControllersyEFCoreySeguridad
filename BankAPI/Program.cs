using BankAPI.Data;
using BankAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBContext
builder.Services.AddSqlServer<BankContext>(builder.Configuration.GetConnectionString("BankConnection"));

//Service layer
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountTypeService>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBeare(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigninKey = true,
                IssuerSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

builder.Services.AddAuthorization(option =>{
    options.AddPolicy("SuperAdmin", policy => policy.RequireClaim("AdminType", "Super"));
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
app.UseAuthorization();

app.MapControllers();

app.Run();