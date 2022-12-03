var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RecordDemoDbContext>(optionsBuilder =>
{
    optionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// for Mapster
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(typeof(Program).Assembly);

// for AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RecordDemoDbContext>();
    if (dbContext is not null)
    {
        Console.WriteLine("Start to migrate database and seed data...");
        
        dbContext.Database.Migrate();
        await dbContext.SeedDataAsync();
    }
}

app.Run();
