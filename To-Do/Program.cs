using To_Do.Filters;
using To_Do.Interfaces;
using To_Do.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// serilog config
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()

    // removin .net logs
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)

    //  App logs
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/todo-log.txt",
        rollingInterval: RollingInterval.Day)

    .CreateLogger();


builder.Host.UseSerilog();



builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<SessionManagerService>();
builder.Services.AddScoped<ThemeFilter>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ThemeFilter>();
}); // global filter

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todo}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
