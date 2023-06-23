using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web_Api.AddAuthentication;
using Web_Api.CustomerMiddleware;
using Web_Api.Data;
using Web_Api.Tool.Jwt;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(builder.Configuration["MySQL:ConnectionString"], new MySqlServerVersion(builder.Configuration["MySQL:Version"])));
builder.Services.AddSingleton<JwtTool>();
builder.Services.AddSingleton<CacheHelper>();
builder.Services.AddControllers();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseMiddleware<CaseSensitiveRoutingMiddleware>();
app.UseAuthentication();
app.UseMiddleware<MyAuthenrizationMiddleware>();
app.MapControllers();
app.Run();