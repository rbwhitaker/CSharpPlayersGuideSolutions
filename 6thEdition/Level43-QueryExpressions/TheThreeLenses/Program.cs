int[] input = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int number in ProceduralCode(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in KeywordSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in MethodCallSyntax(input))
    Console.Write($"{number} ");
Console.WriteLine();

IEnumerable<int> ProceduralCode(int[] input)
{
    List<int> filtered = new List<int>();

    // Filter to only even numbers.
    foreach (int number in input)
        if (number % 2 == 0)
            filtered.Add(number);

    // Sorting the results.
    int[] results = filtered.ToArray();
    Array.Sort(results);

    // Doubling everything.
    for (int index = 0; index < results.Length; index++)
        results[index] *= 2;

    return results;
}

IEnumerable<int> KeywordSyntax(int[] input)
{
    return from n in input
           where n % 2 == 0
           orderby n
           select n * 2;
}

IEnumerable<int> MethodCallSyntax(int[] input)
{
    return input
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2);
}

// Answer this question: Compare the size and understandability of these three approaches. Do any stand out as being particularly good or particularly bad?
//
//    The procedural code is definitely the longest and ugliest. Query expressions using keywords and method calls are both far shorter,
//    and if you understand delegates, far easier to understand. The keyword approach is perhaps the fewest characters here, with a tiny
//    advantage over the method call syntax, since you don't have to keep reintroducing the variable `n`. In my opinion, it is a negligible
//    benefit when it comes to actual understandability.
//
// Answer this question: Of the three approaches, which is your personal favorite, and why?
//
//    The query expressions both have a clear advantage over the procedural code. It is hard to pick between the two of them, but
//    definitely not the procedural code because of its length and it is harder to understand. If forced to choose, I'd probably
//    give a slight advantage to method call syntax, for no reason other than it's the approach I more often do because there are
//    more options available with method calls than with the keywords. (None of those advantages show up with this code though.)