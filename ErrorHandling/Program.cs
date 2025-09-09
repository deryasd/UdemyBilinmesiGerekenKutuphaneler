using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //1.yol
    app.UseDeveloperExceptionPage();
    //2.yol
    app.UseStatusCodePages("text/plain", "Bir hata var. Durum kodu :{0}");
    //3.yol,
    
    app.UseStatusCodePages(async context =>
    {
        context.HttpContext.Response.ContentType = "text/plain";
        await context.HttpContext.Response.WriteAsync(
            "Bir hata oluþtu. Durum kodu : " +
            context.HttpContext.Response.StatusCode);
    });
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseExceptionHandler(context =>
//{
//    context.Run(async context =>
//    {
//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "text/html";
//        await context.Response.WriteAsync($"<html><head><h1>Hata var : {context.Response.StatusCode}</h1></head></html>").ConfigureAwait(false);

//    });
//});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
