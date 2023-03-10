var builder = WebApplication.CreateBuilder(args);


// RabbitMQ connection string (I use CloudAMQP as a RabbitMQ server).
// Remember to replace this connectionstring with your own.
string cloudAMQPConnectionString =
    "amqps://zjlttmfo:Ts2l_Dzn9eiUlKKTl6AELQbXO9c3nSzl@hawk.rmq.cloudamqp.com/zjlttmfo";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
