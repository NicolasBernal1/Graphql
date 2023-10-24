var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();
app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.MapGet("/", () => "Hello World!");

app.Run();

public record Book(string Title, Author Author, Publish_date Publish_Date);
public record Author(string Name);
public record Publish_date(int Year);


public record Student(string Name);

public class Query
{
    readonly List<Book> _books = new()
    {
        new Book("Libro1", new Author("Autor1"), new Publish_date(2015)),
        new Book("Libro2", new Author("Autor2"),new Publish_date(2016)),
        new Book("Libro3", new Author("Autor3"), new Publish_date(2015))
    };
    public List<Book> GetBooks() => _books;

    public Book? GetBook(string Title) => _books.FirstOrDefault(x => x?.Title == Title);
     
    
}

public class Query2
{
    readonly List<Student> _student = new()
    {
        new Student("Estudiante1"),
        new Student("Estudiante2"),
        new Student("Estudiante3")
    };
    public List<Student> GetXXX() => _student;
    public Student? GetStudent(string Name) => _student.FirstOrDefault(x => x?.Name == Name);
}
