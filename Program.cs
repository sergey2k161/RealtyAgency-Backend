using RealtyAgency.Persistence.Configurations;
using RealtyAgency.Web.Helpers;
using RealtyAgency.Web.Properties;

var builder = WebApplication.CreateBuilder(args);

//Сервисы
StartupHelpers.RegisterDomainServices(builder, builder);

// Добавление Swagger, JWT tokens, CORS 
SwaggerJwtConfigurator.StartupConfigurator(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MakeVolunteerGreatAgain API V1");
        //c.InjectStylesheet("/swagger-ui/dark-theme.css");
    });
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

// Инициализация ролей
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleInitializer = services.GetRequiredService<RoleInitializer>();
    await roleInitializer.InitializeAsync();
}

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
