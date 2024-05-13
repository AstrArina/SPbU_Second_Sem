using Bor;

var trie = new Trie();
while (true)
{
    Console.WriteLine(
        @"Choose an action: 
        1: Add element
        2: Remove elements
        3: Check element in Trie
        4: Size of Trie
        5: Number of strings with prefix
        6: Exit");

    var action = Console.ReadLine();

    switch (action)
    {
        case "1":
            {
                Console.WriteLine("Enter the string you want to add:");
                var addWord = Console.ReadLine();
                if (string.IsNullOrEmpty(addWord))
                {
                    Console.WriteLine("Input is NULL");
                    break;
                }
                var isAdded = trie.Add(addWord);
                Console.WriteLine(isAdded ? "New word added to the trie" : "The string already exists in the trie");
                break;
            }
        case "2":
            {
                Console.WriteLine("Enter the string to remove from the trie:");
                var removeWord = Console.ReadLine();
                if (string.IsNullOrEmpty(removeWord))
                {
                    Console.WriteLine("Input is NULL");
                    break;
                }
                var isRemoved = trie.Remove(removeWord);
                Console.WriteLine(isRemoved ? "String removed from the trie" : "The string is not in the trie");
                break;
            }
        case "3":
            {
                Console.WriteLine("Enter the string to check its presence in trie:");
                var checkWord = Console.ReadLine();
                if (string.IsNullOrEmpty(checkWord))
                {
                    Console.WriteLine("Input is NULL");
                    break;
                }
                Console.WriteLine(trie.Contains(checkWord) ? "String found in the trie" : "String not found in the trie");
                break;
            }
        case "4":
            {
                Console.WriteLine("Size of the trie: {0}", trie.Size);
                break;
            }
        case "5":
            {
                Console.WriteLine("Enter the prefix:");
                var prefix = Console.ReadLine();
                if (string.IsNullOrEmpty(prefix))
                {
                    Console.WriteLine("Input is NULL");
                    break;
                }
                Console.WriteLine("Number of strings in the trie with this prefix: {0}", trie.HowManyStartsWithPrefix(prefix));
                break;
            }
        case "6":
            return;
        default:
            Console.WriteLine("Invalid option, please choose again.");
            break;
    }
}