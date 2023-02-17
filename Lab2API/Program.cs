using Newtonsoft.Json;
using Lab2API.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var currentUrl = builder.Configuration.GetValue("AnimeListUrl", "");
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", context =>
{
	context.Response.Redirect("/swagger");
	return Task.CompletedTask;
});

app.MapGet("/animeList", async () => 
{
	using (var client = new HttpClient())
	{
		var response = await client.GetAsync(currentUrl + "/animelist");
		var data = await response.Content.ReadFromJsonAsync<List<addanime>>();
		return data;
	}
});

app.MapPost("/addanime", async (addanime data) =>
{
	using (var client = new HttpClient())
	{
		var response = await client.PostAsJsonAsync<addanime>(currentUrl + "/addanime" , data);
		return Results.Ok();
	}
});

app.MapDelete("/delete/{Id}", async (int id) =>
{
	using (var client = new HttpClient())
	{
		var response = await client.DeleteAsync(currentUrl + "/animelist/" + id);
		var respData = await response.Content.ReadFromJsonAsync<addanime>();
		return respData;
	}
});

app.Run();

