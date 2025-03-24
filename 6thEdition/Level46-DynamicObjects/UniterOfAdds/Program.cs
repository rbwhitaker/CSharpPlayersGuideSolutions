Console.WriteLine(Add(1, 2));
Console.WriteLine(Add(1.1, 2.2));
Console.WriteLine(Add("abc", "def"));
Console.WriteLine(Add(DateTime.Now, TimeSpan.FromDays(1)));

dynamic Add(dynamic a, dynamic b) => a + b;

// Answer this question: What downside do you see with using dynamic here?
//
//    The biggest downside is that the compiler can't tell you if there is a `+` operator
//    defined for two given types. You could add the line below and it would crash at runtime,
//    with no indication from the compiler that it might go wrong. This is the drawback
//    to dynamic typing in general.
//        Console.WriteLine(Add(DateTime.Now, 1));