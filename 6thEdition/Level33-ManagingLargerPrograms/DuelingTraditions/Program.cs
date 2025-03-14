namespace DuelingTraditions;

public class Program
{
    public static void Main(string[] args)
    {
        FountainOfObjectsGame game = CreateSmallGame();
        game.Run();
    }

    // Creates a small 4x4 game.
    private static FountainOfObjectsGame CreateSmallGame()
    {
        Map map = new Map(4, 4);
        Location start = new Location(0, 0);
        map.SetRoomTypeAtLocation(start, RoomType.Entrance);
        map.SetRoomTypeAtLocation(new Location(1, 2), RoomType.Fountain);

        Monster[] monsters = new Monster[] { };

        return new FountainOfObjectsGame(map, new Player(start), monsters);
    }
}


// Answer this question: Now that you have made programs that use top-level statements and the
// traditional `Program` and `Main` method, which do you prefer and why?
//
// I like top-level programs (the newer approach we have been using in the book) for small
// programs. Having a file with a couple of class definitions and a few statements that use them
// is nice and simple, without a lot of overhead. But as programs get bigger, splitting them
// across multiple files becomes imperative.
//
// I typically find that as I build larger programs, my `Main` method often is little more than
// create an instance of the program's key object and ask it to do something. In that case,
// `Main` is usually a very small method, and `Program` is a very small class. Those two things
// become only a tiny facet of the overall project, and thus I end up not really caring about
// their structure as long as the rest of the code is organized well enough (namespaces, files, 
// and even folders and projects if necessary).
//
// As an experienced C# programmer, I'll admit I'm still adjusting to the top-level approach.
// But I think I like it better, in general. Less code to write.