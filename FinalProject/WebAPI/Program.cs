using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//IOC Container
//Arkaplanda referans oluşturur, yani bizim yerimize newler
//aşağıdaki kod IProductService bağımlılığı varsa ProductManager oluşturur.
//Singleton tüm bellekte 1 tane productmanager oluşturur, client sayısı fark etmeksizin hepsine aynı referansı verir böylece
//performans artışı sağlar. Her client için yeni new productmanager oluşturmamış olursun.
//Singleton içinde data tutulmuyorsa kullanılır aksi halde sorun oluşur.
//builder.Services.AddSingleton<IProductService, ProductManager>();

////ProductManager IProductDala ihtiyaç duyguğu için ProductManager newlendiğinde ProductManager(new EfProductDal) yapısı oluşması
////için aşağıdaki kodu ekledik. IProductDal talep edildiğinde EfProductDal instance' ı oluşturur.
//builder.Services.AddSingleton<IProductDal, EfProductDal>();

//Autofac aktif etmek için eklenecek kodlar;
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
