var people = new List<string>() { "Tom", "Bob", "Sam" };

string firstPerson = people[0];
Console.WriteLine(people.Count);


var person = new Person("Anras", 18, "St");
var person1 = new Person("Danil", 18, "St");
var person2 = new Person("nikita", 19, "St");

person.PrintingPerson(person);
person1.PrintingPerson(person1);
person2.PrintingPerson(person2);


var book1 = new Book("Alhimik", "Paulo Koel", 2013);
book1.printTytleBook();
book1.printAuthorBook();
book1.printYearBook();

class Person
{
    private string _name;
    private int _age;
    private string _profession;
    public Person(string NAME,int AGE, string PROFESSION)
    {
        _name = NAME;
        _age = AGE;        
        _profession = PROFESSION;

    }

    public void PrintingPerson(Person person )
    {
        Console.WriteLine($"Name of Preson: {person._name} \n Age of Person: {person._age} \n Profession of Person{person._profession}");
    }
    
}

class Book
{
    private string _title;
    private string _author;
    private int _year;
    private List<Book> Bookk = new List<Book>();
    
    public Book(string Title, string Author, int Year)
    {
        _title = Title;
        _author = Author;
        _year = Year;
        Bookk.Add(this);
        Console.WriteLine("_______________BOOK_______________");
    }

    public void printTytleBook()
    {
        Console.WriteLine($"Tytle: {_title}");
        
    }
    public void printAuthorBook()
    {
        Console.WriteLine($"Author: {_author}");
        
    }
    public void printYearBook()
    {
        Console.WriteLine($"Year: {_year}");
        
    }
}