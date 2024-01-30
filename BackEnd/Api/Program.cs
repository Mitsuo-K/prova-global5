using Api.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MaterialsModelView>();
builder.Services.AddTransient<SupplierModelView>();
builder.Services.AddTransient<StockModelView>();
builder.Services.AddTransient<DDLCentralModelView>();
builder.Services.AddScoped<ConnManager>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

ConnectionStringConfig connectionStringConfig = builder.Configuration.GetSection("ConnectionStringConfig").Get<ConnectionStringConfig>();

builder.Services.AddSingleton(connectionStringConfig);

var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
