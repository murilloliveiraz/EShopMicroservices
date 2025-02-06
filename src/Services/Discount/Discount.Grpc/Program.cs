var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<DiscountContext>(opts =>
        opts.UseSqlite(builder.Configuration.GetConnectionString("SQLiteDb")));

var app = builder.Build();

app.UseMigration();
app.MapGrpcService<DiscountService>();

app.Run();
