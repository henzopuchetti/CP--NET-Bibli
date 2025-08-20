using Biblioteca.Mvc.Services; // ajuste o namespace conforme seu projeto
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Adiciona HttpClient para BibliotecaService (Biblioteca.Api)
builder.Services.AddHttpClient<BibliotecaService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/"); // endereço da Biblioteca.Api
});

// Adiciona HttpClient genérico para controllers que vão consumir APIs diretamente
builder.Services.AddHttpClient(); // permite injetar IHttpClientFactory nos controllers

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // serve arquivos wwwroot

app.UseRouting();

app.UseAuthorization();

// Configura rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
