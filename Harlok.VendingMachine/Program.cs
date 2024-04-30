using Harlok.Core.Extensions;
using Harlok.VendingMachine.Application;
using Harlok.VendingMachine.Application.Repositories;
using Harlok.VendingMachine.Configurations;
using Harlok.VendingMachine.Extensions;
using Harlok.VendingMachine.Infrastructure;
using Harlok.VendingMachine.Infrastructure.DAL.UoW;
using Harlok.VendingMachine.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMapper<MappingProfile>();

builder.Services.AddCorsWithOptions(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(builder.Configuration.GetSection("Cors").Get<CorsConfig>()?.PolicyName!);

app.MapControllers();

await app.RunAsync();