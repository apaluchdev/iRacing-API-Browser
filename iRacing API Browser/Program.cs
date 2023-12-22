using Aydsko.iRacingData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIRacingDataApi(options =>
{
    options.UserAgentProductName = "irsint";
    options.UserAgentProductVersion = new Version(1, 0);
    options.Username = builder.Configuration.GetValue<string>("iRacingCredentials:Username");
    options.Password = builder.Configuration.GetValue<string>("iRacingCredentials:Password");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
