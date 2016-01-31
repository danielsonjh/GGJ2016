using UnityEngine;

public class LaneSelector : MonoBehaviour {
	
	void Update ()
    {
	    if (Timer.CurrentBeat > 1)
	    {
	        Destroy(gameObject);
	    }
	}
}
