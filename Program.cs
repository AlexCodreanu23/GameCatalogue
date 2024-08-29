using GameCatalogue;
using GameCatalogue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure Identity services
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed data: add a test user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Ensure the database is created
    await services.GetRequiredService<ApplicationDbContext>().Database.EnsureCreatedAsync();

    // Create a role if it doesn't exist
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Create a user if it doesn't exist
    var testUser = await userManager.FindByEmailAsync("testuser@example.com");
    if (testUser == null)
    {
        testUser = new User
        {
            UserName = "testuser@example.com",
            Email = "testuser@example.com",
            FirstName = "Test",
            LastName = "User"
        };
        var result = await userManager.CreateAsync(testUser, "Test@1234");
        if (result.Succeeded)
        {
            // Add user to the Admin role
            await userManager.AddToRoleAsync(testUser, "Admin");
        }
        else
        {
            // Log errors
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
        }
    }
}

app.MapControllers();
app.Run();
