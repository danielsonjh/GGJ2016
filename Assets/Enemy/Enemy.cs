public class Enemy
{
    public float Time;
    public float Speed;
    public Note Note;
    public int Type;

    public override string ToString()
    {
        return "Enemy: {Time = " + Time + ", Type = " + Type + ", Note = " + Note + "}";
    }
}
