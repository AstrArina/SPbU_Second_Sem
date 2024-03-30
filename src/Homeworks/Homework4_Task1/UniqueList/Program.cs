using UniqueList;

UniqueList<string> names = new UniqueList<string>() { "Tom", "Tim", "Bob" };

foreach (var name in names)
{
    Console.WriteLine(name);
}