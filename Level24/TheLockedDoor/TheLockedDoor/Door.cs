namespace TheLockedDoor
{
    public class Door
    {
        public DoorState State { get; private set; }
        private int _passcode;

        public Door(int passcode)
        {
            _passcode = passcode;
            State = DoorState.Open;
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

        public bool TryUnlock(int passcode)
        {
            if (State == DoorState.Locked && passcode == _passcode)
            {
                State = DoorState.Closed;
                return true;
            }

            return false;
        }

        public bool TryChangeCode(int oldCode, int newCode)
        {
            if(oldCode == _passcode)
            {
                _passcode = newCode;
                return true;
            }

            return false;
        }
    }
}
