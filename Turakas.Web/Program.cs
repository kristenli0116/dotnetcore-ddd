using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Turakas.Common;
using Turakas.Identity.Common;
using Turakas.Identity.Extensions;
using Turakas.Infrastructure.Data;

namespace Turakas.Identity;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
        );
        
        // 自定义身份认证
        builder.Services.AddCustomAuthentication(builder.Configuration);

        builder.Services.AddAuthorization();

        // 注册服务
        builder.Services.ConfigureServices(builder.Configuration);


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHttpsRedirection();

        // 认证中间件
        app.UseAuthentication();

        // 授权中间件
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}