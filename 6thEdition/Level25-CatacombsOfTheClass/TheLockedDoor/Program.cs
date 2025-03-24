int initialPasscode = GetInt("What is the initial passcode?");
Door door = new Door(initialPasscode);

while (true)
{
    Console.Write($"The door is {door.State}. What do you want to do? (open, close, lock, unlock, change code) ");
    string? command = Console.ReadLine();

    switch (command)
    {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.Lock();
            break;
        case "unlock":
            int guess = GetInt("What is the passcode?");
            door.Unlock(guess);
            break;
        case "change code":
            int currentCode = GetInt("What is the current passcode?");
            int newCode = GetInt("What do you want to change it to?");
            door.ChangeCode(currentCode, newCode);
            break;
    }
}

int GetInt(string text)
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}

public class Door
{
    private int _passcode;
    public DoorState State { get; private set; }

    public Door(int initialPasscode)
    {
        _passcode = initialPasscode;
        State = DoorState.Closed;
    }
    
    public void Close()
    {
        if (State == DoorState.Open) State = DoorState.Closed;
    }

    public void Open()
    {
        if (State == DoorState.Closed) State = DoorState.Open;
    }

    public void Lock()
    {
        if (State == DoorState.Closed) State = DoorState.Locked;
    }

    public void Unlock(int passcode)
    {
        if (State == DoorState.Locked && passcode == _passcode) State = DoorState.Closed;
    }

    public void ChangeCode(int oldPasscode, int newPasscode)
    {
        if (oldPasscode == _passcode) _passcode = newPasscode;
    }
}

public enum DoorState { Open, Closed, Locked }