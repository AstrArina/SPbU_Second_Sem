using Alg;
Console.WriteLine("If you want to run the Direct BWT, input '1', if Reverse BWT - '2'");
switch (Console.ReadLine()) {
    case "1":
    {
        Console.WriteLine("Input string: ");
        var InputString = Console.ReadLine();
        if (InputString == null || InputString == "") {
            Console.WriteLine("NULL");
            return;
        }
        var ResultString = BWT.Direct(InputString);
        Console.WriteLine("Transformed string and index of the end of string: {0}, {1}", ResultString.Item1, ResultString.Item2 + 1);
        break;
    }
    case "2":
    {
        System.Console.Write("Input the transform string: ");
        string Inputstring2 = Console.ReadLine();
        if (Inputstring2 == null || Inputstring2 == "") {
            Console.WriteLine("NULL");
            return;
        }
        System.Console.Write("Input the end of the string number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n<=0) {
            Console.WriteLine("Incorrect index");
            return;
        }
        var OriginString = BWT.Inverse(Inputstring2, n);
        Console.WriteLine("String before transformation: {0}", OriginString);
        break;
    }
    default:
    {
        Console.WriteLine("No dialed number");
        break;
    }
}