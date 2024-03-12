using Trees;
var trie = new Trie();
while (true) {


    Console.WriteLine("""
        Choose an action: 
        1: Add element
        2: Remove elements
        3: Check element in Trie
        4: Size of Trie
        5: Number of prefix element
        6: Exit
        """);
    var action = Console.ReadLine();
    switch (action) {
        case "1": {
        Console.WriteLine("What string do you want to add?");
        var addword = Console.ReadLine();
        if (addword == null) {
            Console.WriteLine("NULL");
            break;
        }
        var possible = trie.Add(addword);
        Console.WriteLine(possible ? "New word added to tree" : "Such a line already exists");
        break;
        }
        case "2": {
            Console.WriteLine("Input string to remove from trie");
            var removeword = Console.ReadLine();
            if (removeword == null || removeword == string.Empty) {
                Console.WriteLine("NULL");
                break;
            }
            var possible = trie.Remove(removeword);
            Console.WriteLine(possible ? "String removed from trie": "This string in not in trie");
            break;
        } 
        case "3": {
            Console.WriteLine("Input string to check its contents in tree");
            var checkword = Console.ReadLine();
            if (checkword == null) {
                Console.WriteLine("NULL");
                break;
            }
            Console.WriteLine(trie.Contains(checkword) ? "String in trie" : "No string in trie");
            break;
        }
        case "4": {
            Console.WriteLine("Size of trie: {0}", trie.Size);
            break;
        }
        case "5":{
            Console.WriteLine("input prefix");
            var prefix = Console.ReadLine();
            if (prefix == null) {
                Console.WriteLine("NULL");
                break;
            }
            Console.WriteLine("Number of string in true with this prefix: {0}", trie.HowManyStartsWithPrefix(prefix));
            break;
        }
        case "6":
            break;
        default: {
            Console.WriteLine("There in no such option");
            break;
        }
    }
}
