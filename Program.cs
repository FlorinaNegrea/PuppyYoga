using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PuppyYoga.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PuppyYogaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PuppyYogaContext") ?? throw new InvalidOperationException("Connection string 'PuppyYogaContext' not found.")));

builder.Services.AddDbContext<PuppyYogaIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PuppyYogaContext") ??
throw new InvalidOperationException("Connection string 'PuppyYogaContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() 
    .AddEntityFrameworkStores<PuppyYogaIdentityContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});
builder.Services.AddRazorPages(options =>
{
options.Conventions.AuthorizeFolder("/YogaClasses");
options.Conventions.AllowAnonymousToPage("/YogaClasses/Index");
options.Conventions.AllowAnonymousToPage("/YogaClasses/Details");
options.Conventions.AuthorizeFolder("/Users", "AdminPolicy");
options.Conventions.AuthorizeFolder("/Enrollments");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
