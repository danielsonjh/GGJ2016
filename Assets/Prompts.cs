using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prompts : MonoBehaviour
{

    public GameObject LanePromptObject, ColorPromptObject, LanePromptShadowObject, ColorPromptShadowObject;

    private bool InLanePhase;



    // Use this for initialization
    void Start ()
	{
	    InLanePhase = Timer.CurrentBeat < 2;
	}
	
	// Update is called once per frame
	void Update () {
        InLanePhase = Timer.CurrentBeat < 2;
	    if (InLanePhase)
	    {
	        LanePromptObject.GetComponent<Text>().color = Color.white;
	        LanePromptShadowObject.GetComponent<Text>().color = Color.black;
            ColorPromptObject.GetComponent<Text>().color = Color.gray;
            ColorPromptShadowObject.GetComponent<Text>().color = Color.clear;
        }
	    else
	    {
            LanePromptObject.GetComponent<Text>().color = Color.gray;
            LanePromptShadowObject.GetComponent<Text>().color = Color.clear;
            ColorPromptObject.GetComponent<Text>().color = Color.white;
            ColorPromptShadowObject.GetComponent<Text>().color = Color.black;
        }

    }
}
