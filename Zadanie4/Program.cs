using System.Text;
using System.Linq;



string Zadanie1(StringBuilder str)
{
    for (int i = 0; i < str.Length; i++)
    {
        if (str[i] >= '0' && str[i] <= '9')
        {
            str.Remove(i, 1);
            i--;
        }
    }
    return str.ToString();
}




void Zadanie2(StringBuilder str)
{
    Console.WriteLine($"Inserted Item: {str.ToString()}");
    for (int i = 1;i <= 10;i++)
    {
        str.Append(i);
        Console.WriteLine($"Item: {i}\n");
    }

}



string Reverse(string[] name)
{
    StringBuilder str = new StringBuilder();

    for (int i = 0; i < name.Length; i++)
    {
        str.Append(name[i]);
        str.Append(" ");
    }
    int size = name.Length;
    StringBuilder rev = new StringBuilder();

    for(int i = 0;i < name.Length; i++)
    {
        rev.Append(name[size -1]);
        rev.Append(" ");
        size --;
    }
    return rev.ToString();
}

                                        //PROVERKI
////Proverka Zadania3
//string[] name = {"Hello", "C#", "Tuke", "Matlab","KAKAUI"};
//StringBuilder res = new StringBuilder();
//for (int i = 0;i < name.Length; i++)
//{
//    res.Append(name[i].ToString());
//    res.Append(" ");
//}
//Console.WriteLine($"Before String: {res}\nAfter String: {Reverse( name)}");


////Proverka Zadania2
//StringBuilder str = new StringBuilder();
//Zadanie2(str);

////Proverka Zadnia1
//StringBuilder str = new StringBuilder("Andriy24September2005");
//Console.WriteLine(Zadanie1(str));
