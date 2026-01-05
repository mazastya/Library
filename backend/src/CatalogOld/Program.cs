using CatalogOld.Catalog.Domain.Books;
using CatalogOld.CatalogOld.Application.Books;
using CatalogOld.CatalogOld.Domain.Books;
using CatalogOld.CatalogOld.Infrastructure.Books;
using CatalogOld.CatalogOld.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Регистрируем DbContext (InMemory для простоты)
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseInMemoryDatabase("CatalogDb"));

// 2. Регистрируем остальные сервисы
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<BookService>();

// 3. Swagger и контроллеры
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Создаем тестовые данные при запуске
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

    // Добавляем тестовые книги
    if (!dbContext.Books.Any())
    {
        dbContext.Books.AddRange(
            new BookEntity
                { Id = Guid.NewGuid(), Title = "Книга 1", Author = "Автор 1", BookStatus = BookStatus.Available },
            new BookEntity
                { Id = Guid.NewGuid(), Title = "Книга 2", Author = "Автор 2", BookStatus = BookStatus.Available }
        );
        dbContext.SaveChanges();
    }
}

// 5. Настройка приложения
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();