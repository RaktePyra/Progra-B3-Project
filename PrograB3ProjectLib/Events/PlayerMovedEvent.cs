namespace PrograB3Project.Events
{
    public class PlayerMovedEvent : Event
    {
        public readonly int newPlayerPositionX;
        public readonly int newPlayerPositionY;
        public PlayerMovedEvent(int newPosX, int newPosY)
        {
            newPlayerPositionX = newPosX;
            newPlayerPositionY = newPosY;
        }
    }
}
