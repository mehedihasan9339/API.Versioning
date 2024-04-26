using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


#region Database
builder.Services.AddDbContext<databaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

#endregion

#region Services
builder.Services.AddScoped<API.Versioning.Services.v1.Interfaces.IDriver, API.Versioning.Services.v1.DriverService>();
builder.Services.AddScoped<API.Versioning.Services.v1.Interfaces.IAchivement, API.Versioning.Services.v1.AchivementService>();
builder.Services.AddScoped<API.Versioning.Services.v2.Interfaces.IAchivement, API.Versioning.Services.v2.AchivementService>();
#endregion

#region Versioning
builder.Services.AddApiVersioning(opt =>
{
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = ApiVersion.Default;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new UrlSegmentApiVersionReader()
    );
}).AddVersionedApiExplorer(opt =>
{
    // Configure API Explorer options here
    opt.GroupNameFormat = "'v'VVV";
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.SubstituteApiVersionInUrl = true;
});
#endregion



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
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
