using User.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();

//dbcontext database
#region database
string connectionString = Configuration.GetConnectionString("specialCustomerDB");
UserBootestrapper.Configuration(builder.Services, connectionString);
#endregion

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
