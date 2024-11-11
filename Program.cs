using E_commerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(60);
            }
            );

            builder.Services.AddDbContext<DBcontext>(options =>
            {
                string Connectionstring = builder.Configuration.GetConnectionString("DefaultConnection")!;

                options.UseSqlServer(Connectionstring);
            });

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
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
