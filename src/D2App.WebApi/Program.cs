try
{
    SerilogApplicationExtensions.AddBootStrapsBootStrap();
    Log.Information("Starting the application...");

    var builder = WebApplication.CreateBuilder(args);
    
    builder.AddSerilogServices();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseSerilogMiddleware();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();
    
    app.MapGet("/", () => new { message = "Hello World!"});
    
    app.Run();
}
catch (Exception ex)
{
    // Log the exception  
    Log.Fatal(ex, "An unhandled exception occurred during bootstrapping the application.");
    throw;
}
finally
{
    Log.Information("Application has shut down.");
    Log.CloseAndFlush();
}


/* 
   TODO:
   - Add Logging
   - Add Cors support
   - Add Health Checks
   - Add Contexts
   - Add HTTPClient
   - Add API Versioning
    - Add EF Core DbContext
      - Add MSSQL Server
      - Add SQLite
      - Add PostgreSQL
    - Add Dapper Support
      - Add MSSQL Server
      - Add SQLite
      - Add PostgreSQL
   - Add Authentication
   - Add Authorization
*/