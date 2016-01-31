using UnityEngine;

public class ModeControl : MonoBehaviour {

    public static int numberOfLanes;
    public static int numberOfColors;
    public int ChangeNumLanes;
    public int ChangeNumColors;

    void Awake()
    {
        ChangeNumLanes = numberOfLanes;
        ChangeNumColors = numberOfColors;
    }

    void Start () 
    {
	    
	}
	
	void Update () {
        if (ChangeNumColors != numberOfColors)
        {
            numberOfColors = ChangeNumColors;
        }

        if (ChangeNumLanes != numberOfLanes)
        {
            numberOfLanes = ChangeNumLanes;
        }
	}
}
