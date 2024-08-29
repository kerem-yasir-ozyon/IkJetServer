using IkJet.BLL.Managers.Concrete;
using IkJet.Common.EmailServices;
using IkJet.DAL.Data;
using IkJet.DAL.Profiles;
using IkJet.DAL.Repositories.Concrete;
using IkJet.DAL.Services.Concrete;
using IkJet.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

builder.Services.AddDbContext<IkJetDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("IkJetConStr"));
}, ServiceLifetime.Scoped);




builder.Services.AddTransient<UserService>();  // veya AddScoped, AddSingleton ihtiyaca göre
builder.Services.AddTransient<EmailService>();


//ilave
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(opt =>
     opt.TokenValidationParameters = new TokenValidationParameters()
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,

         ValidIssuer = builder.Configuration["JwtTokenSettings:Issuer"],
         ValidAudience = builder.Configuration["JwtTokenSettings:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtTokenSettings:Key"]))

     });



//ilave

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authentication",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "IkJet",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
         new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }

        },
         new string[] { }
    }


};


var contact = new OpenApiContact()
{
    Name = "IkJet Human Resources",
    Email = "ikjet@bilgeadam.com",
    Url = new Uri("https://www.bilgeadam.com")
};

var license = new OpenApiLicense()
{
    Name = "Free",
    Url = new Uri("https://www.bilgeadam.com")
};

var info = new OpenApiInfo()
{
    Version = "1.0",
    Title = "IkJet Human Resources",
    Description = "IkJet ",
    TermsOfService = new Uri("https://www.bilgeadam.com"),
    Contact = contact,
    License = license,
};








builder.Services.AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<IkJetDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();




builder.Services.AddAutoMapper(typeof(AppUserProfile).Assembly);



builder.Services.AddScoped<ExpenseRepo>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<ExpenseManager>();
//----------------------------------------------
builder.Services.AddScoped<PrepaymentRepo>();
builder.Services.AddScoped<PrepaymentService>();
builder.Services.AddScoped<PrepaymentManager>();
//----------------------------------------------
builder.Services.AddScoped<WorkOffRepo>();
builder.Services.AddScoped<WorkOffService>();
builder.Services.AddScoped<WorkOffManager>();
//----------------------------------------------
builder.Services.AddScoped<CompanyRepo>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<CompanyManager>();





// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();


//ilave
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", info);
    opt.AddSecurityDefinition("Bearer", securityScheme);
    opt.AddSecurityRequirement(securityReq);

});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
