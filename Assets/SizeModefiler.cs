﻿using UnityEngine;
using System.Collections;

public class SizeModefiler : MonoBehaviour {

    private float initX = 2;
    private float initY = 0.5f;
    
    // Use this for initialization
	void Start () {
        GetComponent<Transform>().position = new Vector3(initX, initY, 0)

    }
	
	void SetSize(int Lanes)
    {
        GetComponent<Transform>().position = new Vector3(0, 0, 0);
    }
    
    // Update is called once per frame
	void Update () {
	
	}
}