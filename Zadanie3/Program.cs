class Program
{ 
    public static void Main()
    {
        User user1 = new User("Anatoliy", "dfsd@gmail.com");
        Console.WriteLine($"Name: {user1.GetName()}\tEmail: {user1.GetMail()}");
        Post post1 = new Post("Title","Content", user1);
        Console.WriteLine($"Title: {post1.GetTitle()}\tContent: {post1.GetContent()}\tAuthor: {post1.GetAuthor().GetName()                              }");
    } 
}

class User
{
    private string _nameUser;
    private string _email;

    public User(string name, string mail)
    {
        _nameUser = name;
        _email = mail;
    }
    public string GetName()
    {
        return _nameUser;
    }public string GetMail()
    {
        return _email;
    }    
}

class Post
{
    private string _title;
    private string _content;
    private User _author;
    public Post(string title, string content,User user)
    {
        _title = title;
        _content = content;
        _author = user;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetContent()
    {
        return _content;
    }
    public User GetAuthor()
    {
        return _author;
    }
}