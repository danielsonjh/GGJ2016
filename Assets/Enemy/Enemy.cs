public class Enemy
{
    public float Time;
    public float Speed;
    public Note Lane;
    public Note Color;
    public int Type;

    public override string ToString()
    {
        return "Enemy: {Time = " + Time + ", Type = " + Type + ", Lane = " + Lane + ", Color" + Color +"}";
    }
}
