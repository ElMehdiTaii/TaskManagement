



using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TaskManagement.Business.Interfaces;
using TaskManagement.Host.Api.Extensions;
using TaskManagement.Services.EF;
using TaskManagement.Services.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigurePersistence(builder.Configuration);

builder.Services.ConfigureNewtonsoftJson();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDistributedMemoryCache();



builder.Services.AddMemoryCache();

builder.Services.AddControllers();
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
else
{
    app.UseExceptionHandler(builder =>
    {
        builder.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = context.Features.Get<IExceptionHandlerFeature>();

            if (error != null)
            {
                context.Response.ConfigureApplicationError(error.Error.Message);
                await context.Response.WriteAsync(error.Error.Message);
            }
        });
    });

}


app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
