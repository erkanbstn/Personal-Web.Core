using Microsoft.EntityFrameworkCore;
using Personal.Core.Repository.DataAccess;
using PersonalUI.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);
var app = builder.Build();
app.ConfigureApp();
