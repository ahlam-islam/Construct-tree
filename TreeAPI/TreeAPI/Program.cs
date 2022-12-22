using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TreeAPI.Model;
using TreeAPI.Services;



var builder = WebApplication.CreateBuilder(args);

#region cors
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
#endregion


//dependency injection
builder.Services.Configure<TreeDatabaseSettings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<ITreeDatabaseSettings>(sp =>
   (ITreeDatabaseSettings)sp.GetRequiredService<IOptions<TreeDatabaseSettings>>().Value);


builder.Services.AddSingleton<IMongoClient>(options =>
    new MongoClient(builder.Configuration.GetValue<string>("ConnectionStrings:ConntionString")));

builder.Services.AddScoped<INodeServices, NodeServices>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

#region Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion