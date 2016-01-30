using UnityEngine;
using System.Collections;

public class ExplosionBehavior : MonoBehaviour
{
    private const float MaxSecondsAlive = 1;

    private float KillTime;
    void Start()
    {
        KillTime = Time.time + MaxSecondsAlive;
    }
	void Update ()
	{
	    if (Time.time >= KillTime)
	    {
	        Destroy(gameObject);
	    }
	}
}
