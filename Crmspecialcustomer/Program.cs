using Area.Configuration;
using Crmspecialcustomer.Chat;
using Crmspecialcustomer.HostFrameworks.Permission;
using Frameworkes.Auth;
using Frameworkes.Message;
using Frameworkes.Message.Sms;
using Frameworks;
using Hofre.HostFrameworks;
using Intermediary.Implement;
using Intermediary.Repository;
using Message.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Order.Configuration;
using Request.Configuration;
using Service.Configuration;
using System.Security.Claims;
using System.Text;
using User.Application.Common;
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
ServiceBootstrapper.Configuration(builder.Services,connectionString);
RequestBootestrapper.Configuration(builder.Services, connectionString);
OrderBootestrapper.Configuration(builder.Services, connectionString);
MessageBootestrapper.Configuration(builder.Services, connectionString);
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
        q.AccessDeniedPath = new PathString("/403.html");
    });
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("AdminAccess", builder => builder.RequireRole( new List<string> { "3" }));
    option.AddPolicy("RequestCreatorAccess", builder => builder.RequireRole( new List<string> { "3","4" }));
    option.AddPolicy("NetworkManagerAccess", builder => builder.RequireRole( new List<string> { "3","5" }));
    option.AddPolicy("MaterialCreatorAccess", builder => builder.RequireRole( new List<string> { "3","6" }));
    option.AddPolicy("OrderExpertAccess", builder => builder.RequireRole( new List<string> { "3","7" }));
    option.AddPolicy("AllAccess", builder => builder.RequireRole( new List<string> { "3","4","5","6","7" }));
    option.AddPolicy("OrderCreate", builder => builder.RequireClaim(ClaimTypes.AuthorizationDecision, "Permission.Order.Create"));


   
});



#endregion

//register frameworks
#region frameworks
builder.Services.AddTransient<IAuth, Auth>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IFileHelper, FileHelper>();
builder.Services.AddTransient<SmsMessage>();
builder.Services.AddTransient<IMessage<SmsDetail>,SmsMessage>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();

#endregion

//register Intermediary
#region Intermediary
builder.Services.AddTransient<IRequestToAreaRepository, RequestToAreaRepository>();
builder.Services.AddTransient<IOrderToMaterialRepository, OrderToMaterialRepository>();
builder.Services.AddTransient<IOrderToRequestRepository, OrderToRequestRepository>();
builder.Services.AddTransient<IMessageToUserRepository, MessageToUserRepository>();
#endregion

builder.Services.AddSignalR();

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

app.MapHub<ChatHub>("/chathub");

app.Run();
