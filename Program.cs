var builder = WebApplication.CreateBuilder(args);

// Register services the app needs - controllers + swagger for API docs
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI only shows up locally while developing, not in production
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Sets up the app: Enforce https, serve static files, check authenticator, route requests to controllers, then start listening
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
