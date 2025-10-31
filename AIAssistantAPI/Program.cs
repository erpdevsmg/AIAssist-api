using AIAssistantAPI.Common.Permission;
using AIAssistantAPI.DataAccess;
using AIAssistantAPI.DataAccess.Model;
using AIAssistantAPI.Service.Interface;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AIAssistantAPI.Common.Permission;
using AIAssistantAPI.DataAccess;
using AIAssistantAPI.DataAccess.Model;
using AIAssistantAPI.Service.Interface;
using AIAssistantAPI.Service.Service;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
builder.Services.AddSingleton(jwtSettings);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LocalDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.Configure<EnvironmentData>(
    builder.Configuration.GetSection("Environment"));

var globalConfig = builder.Configuration.Get<EnvironmentData>();
builder.Services.AddSingleton(globalConfig);
//builder.Services.AddSignalR();

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.MaximumReceiveMessageSize = 1024 * 1024; // 1MB
});

builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

// Register rate limiting services
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();


builder.Services.AddInMemoryRateLimiting(); // Registers default in-memory policy/counter stores

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IDeskService, DeskService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key!))
        };
        // Enable JWT for SignalR by checking query string
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // Check if the request is for our SignalR hub
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/interviewHub"))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    });
// Register CORS policy
builder.Services.AddCors(options =>
{
    //options.AddPolicy("AllowSpecificOrigin", policy =>
    //{
    //    policy.WithOrigins("https://exam.nautixsuite.com") // Add your frontend URL here
    //          .AllowAnyHeader()
    //          .AllowAnyMethod()
    //            .AllowCredentials();
    //});
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:5174", "http://localhost:5175", "http://172.16.1.145:5173", "https://exam.stanford-marine.com", "https://exam.nautixsuite.com") // Add your frontend URL here
              .AllowAnyHeader()
              .AllowAnyMethod()
                .AllowCredentials();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
