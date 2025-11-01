using Practice_Api.Bussiness;
using Practice_Api.Controllers;
using Practice_Api.DAL;
using Practice_Api.Model;

var MyAllowSpecificOrigns = "MyAllowSpecificOrigns";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataEntryBussiness>();
builder.Services.AddScoped<DataEntryDAL>();
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddScoped<ForgotPasswordDAL>();
builder.Services.AddScoped<ForgotPasswordBusiness>();
builder.Services.AddScoped<ReportDAL>();
builder.Services.AddScoped<AdminBussiness>();
builder.Services.AddScoped<AdminDAL>();
builder.Services.AddScoped<DepartmentMasterBussiness>();
builder.Services.AddScoped<DepartmentMasterDAL>();
builder.Services.AddScoped<LeadGenerationBussiness>();
builder.Services.AddScoped<LeadGenerationDAL>();
builder.Services.AddScoped<RegionBussiness>();
builder.Services.AddScoped<RegionDAl>();
builder.Services.AddScoped<TLMasterBussiness>();
builder.Services.AddScoped<TLMasterDAL>();
builder.Services.AddScoped<LeadConversionBussiness>();
builder.Services.AddScoped<LeadConversionDAL>();



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigns, builder =>
    {
        builder.WithOrigins("http://localhost", "https://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice_Api v1");
    });
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyAllowSpecificOrigns");
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
