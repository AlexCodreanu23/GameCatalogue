using GameCatalogue;
using GameCatalogue.Models;
using GameCatalogue.Repositories;
using GameCatalogue.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISystemRequirementRepository, SystemRequirementRepository>();
builder.Services.AddScoped<ISystemRequirementService, SystemRequirementService>();
builder.Services.AddScoped<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseCors("AllowReactApp");

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var dbContext = services.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.EnsureCreatedAsync();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }

    var adminUser = await userManager.FindByEmailAsync("admin@example.com");
    if (adminUser == null)
    {
        adminUser = new User
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            FirstName = "Admin",
            LastName = "User"
        };
        var result = await userManager.CreateAsync(adminUser, "Admin@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
        }
    }

    var regularUser = await userManager.FindByEmailAsync("user@example.com");
    if (regularUser == null)
    {
        regularUser = new User
        {
            UserName = "user@example.com",
            Email = "user@example.com",
            FirstName = "Regular",
            LastName = "User"
        };
        var result = await userManager.CreateAsync(regularUser, "User@1234");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(regularUser, "User");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
        }
    }
}

app.Run();
