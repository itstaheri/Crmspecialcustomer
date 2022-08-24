using Area.Configuration;
using Frameworkes.Auth;
using Frameworks;
using Hofre.HostFrameworks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var mvcbuilder = builder.Services.AddMvc();

//dbcontext database
#region database
string connectionString = Configuration.GetConnectionString("specialCustomerDB");
UserBootestrapper.Configuration(builder.Services, connectionString);
AreaBootstrapper.Configuration(builder.Services, connectionString);
#endregion


//Authentication , Authorization
#region identity

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CookiePolicyOptions>(option =>
{
    option.CheckConsentNeeded = context => true;
    option.MinimumSameSitePolicy = SameSiteMode.Lax;


});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, q =>
    {
        q.LoginPath = new PathString("/Account");
        q.LogoutPath = new PathString("/Account");
        q.AccessDeniedPath = new PathString("/AccessDenied");
    });
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("AdminArea", builder => builder.RequireClaim("RoleName", new List<string> { "Manager", "Admin" }));
});



#endregion

//register frameworks
#region frameworks
builder.Services.AddTransient<IAuth, Auth>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IFileHelper, FileHelper>();

#endregion




//RunTimeCompiler
mvcbuilder.AddRazorRuntimeCompilation();

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

//authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();


app.MapControllerRoute("areaRoute",
    "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");



app.Run();
