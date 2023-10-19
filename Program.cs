
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    config.SetBasePath(context.HostingEnvironment.ContentRootPath);
    config.AddEnvironmentVariables();
    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Access-Control-Allow-Origin",
        builder =>
        {
            builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddRazorPages();

builder.Services.AddHealthChecks();


var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors("Access-Control-Allow-Origin");

app.UseAuthorization();

app.MapRazorPages();

app.Run();
