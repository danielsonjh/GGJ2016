using UnityEngine;
using System.Collections;

public class ModeControl : MonoBehaviour {

    //public static bool Difficult;
    public static int numberOfLanes;
    public static int numberOfColors;
    //public static ModeControl Instance { get; private set; }
    public int ChangeNumLanes;
    public int ChangeNumColors;

    void Awake()
    {
        numberOfLanes = 3;
        numberOfColors = 3;

        ChangeNumLanes = numberOfLanes;
        ChangeNumColors = numberOfColors;
    }
    /* void Awake()
     {
         if (Instance != null)
         {
             DestroyImmediate(gameObject);
         }
         else
         {
             Instance = this;
         } */

    // Use this for initialization

    void Start () 
        {
	    
	    }
	
	// Update is called once per frame
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
