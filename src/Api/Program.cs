using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Encryptor, CaesarEncryptor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/encrypt", (CryptoRequest req, Encryptor encryptor) =>
{
    var result = encryptor.Encrypt(req.Text, req.Shift);
    return Results.Ok(new CryptoResponse(result));
});

//added text here to test deploy

app.MapPost("/decrypt", (CryptoRequest req, Encryptor encryptor) =>
{
    var result = encryptor.Decrypt(req.Text, req.Shift);
    return Results.Ok(new CryptoResponse(result));
});

app.Run();

public sealed record CryptoRequest(string Text, int Shift);
public sealed record CryptoResponse(string Result);

