using ApexCharts;
using EnterpriseApp.Domain.Services;
using EnterpriseAppFluxor.Components;
using EnterpriseAppFluxor.Features.Dropdowns.Store;
using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MudBlazor.Services;

namespace EnterpriseAppFluxor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddMudServices();
            builder.Services.AddApexCharts(); // Register Blazor-ApexCharts
            builder.Services.AddFluxor(options =>
            {
                options.ScanAssemblies(typeof(Program).Assembly);
                options.UseReduxDevTools();
            });

            builder.Services.AddScoped<IBatchService, FakeBatchService>();
            builder.Services.AddScoped<IComplexObjectService, ComplexObjectService>();

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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
