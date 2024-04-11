using Calculator.Domain.Extensions;
using Calculator.Infrastructure.Extensions;

var argsConfiguration = new ConfigurationBuilder().AddCommandLine(args)
    .Build();

// Add services to the container.
try
{
    var knownEnv = new List<string>() { "Localhost", "Development", "Uat", "Production" };
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDomain();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        


        var app = builder.Build();

        app.UseCors(builders => builders.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        

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
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error occured {Environment.NewLine} :  {ex.Message}.{Environment.NewLine}{ex.Message} Stack Trace: {Environment.NewLine}{ex.StackTrace}");
}