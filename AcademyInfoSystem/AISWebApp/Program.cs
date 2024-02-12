using AIS.WebApp.Common;
using AIS.Infrastructure.Common;
using AIS.Application.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation(builder.Configuration)
                .AddApplication()
                .AddInfrastructure();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllers();
app.MapRazorPages();

app.MapControllerRoute(
   name: "default",
   pattern: "{area:exists}/{controller=Authenticate}/{action=Login}/{id?}"
);
app.MapControllerRoute(
   name: "controller",
   pattern: "{controller=Authenticate}/{action=Login}/{id?}"
);

app.Run();
