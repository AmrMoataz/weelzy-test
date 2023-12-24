using Weelzy.Test.ThirdPartyAPI.Clients;
using Weelzy.Test.ThirdPartyAPI.DelegationHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<RetryPolicyHttpDelegationHandler>();
builder.Services.AddTransient<ExceptionHandlerDelegationHandler>();
builder.Services.AddHttpClient<LotteryClient>((client) =>
{
	client.BaseAddress = new Uri("https://notrealapi.com/lottery/play");
})
.AddHttpMessageHandler<RetryPolicyHttpDelegationHandler>()
.AddHttpMessageHandler<ExceptionHandlerDelegationHandler>();

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
