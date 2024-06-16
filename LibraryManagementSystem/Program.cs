using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string connectionString = "Server=WKS-1BN-13;Database=Biblioteka;Integrated Security=True;";

builder.Services.AddScoped<IBookRepository>(provider => new BookRepository(connectionString));
builder.Services.AddScoped<IAuthorRepository>(provider => new AuthorRepository(connectionString));
builder.Services.AddScoped<IMemberRepository>(provider => new MemberRepository(connectionString));
builder.Services.AddScoped<ILoanRepository>(provider => new LoanRepository(connectionString));
//kada nors padarysiu papildomus servisus
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ILoanService, LoanService>();

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
