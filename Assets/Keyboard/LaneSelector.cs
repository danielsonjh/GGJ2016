using UnityEngine;

public class LaneSelector : MonoBehaviour {
	
	void Update ()
    {
	    if (Timer.CurrentBeat == 3)
	    {
	        Destroy(gameObject);
	    }
	}
}
