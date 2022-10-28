using CustomMiddlewareConvention.Middleware;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IMessageWriter, LoggingMessageWriter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.Use(async (context, next) =>
//{
//    var cultureQuery = context.Request.Query["culture"];
//    if (!string.IsNullOrWhiteSpace(cultureQuery))
//    {
//        var culture = new CultureInfo(cultureQuery);

//        CultureInfo.CurrentCulture = culture;
//		CultureInfo.CurrentUICulture = culture;
//    }

//    // Call the next delegate/middleware in the pipeline.
//    await next(context);
//});

//app.UseRequestCulture();

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync(
//        $"CurrentCulture.DisplayName: {CultureInfo.CurrentCulture.DisplayName}");
//});


app.UseMyCustomMiddleware();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
