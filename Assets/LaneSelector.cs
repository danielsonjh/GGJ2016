using UnityEngine;

public class LaneSelector : MonoBehaviour {
	
	void Update ()
    {
	    if (Timer.IsStartOfLanePhase)
	    {
	        Destroy(gameObject);
	    }
	}
}
