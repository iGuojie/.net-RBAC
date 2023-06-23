using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Web_Api.AddAuthentication;
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


var app = builder.Build();
app.UseMiddleware<ExceptionHandlerMiddleware>();
// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseMiddleware<MyAuthenrizationMiddleware>();
app.MapControllers();
app.Run();

// using System;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Web_Api.Data;
//
// using MyDbContext context = new MyDbContext();
// var users =
//     (from product in context.Users
//         select product)
//     .Include(u => u.Roles)
//     .ThenInclude(r => r.Resources);
//     
// foreach (var user in users)
// {
//     Console.WriteLine($"{user.Id}");
//     Console.WriteLine($"{user.NickName}");
//     Console.WriteLine($"{user.Password}");
//     foreach (var role in user.Roles)
//     {
//         Console.WriteLine($"{role.Name}");
//         Console.WriteLine("拥有权限如下");
//         foreach (var resource in role.Resources)
//         {
//             Console.WriteLine($"{resource.Url}");
//             
//         }
//     }
//     Console.WriteLine(new string('-', 25));
// }