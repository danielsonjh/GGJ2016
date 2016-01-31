using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Prompts : MonoBehaviour
{

    public GameObject LanePromptObject,
        ColorPromptObject,
        LanePromptShadowObject,
        ColorPromptShadowObject,
        LanePromptObject2,
        ColorPromptObject2,
        LanePromptShadowObject2,
        ColorPromptShadowObject2;

    private int CurrentBeat = 0;

    void Start()
    {
        Timer.OnPreciseBeat += pUpdate;
    }


	// Update is called once per frame
	void pUpdate () 
    {
        switch (CurrentBeat) 
        {
            case 0:
                DeselectAll();
                LanePromptObject.GetComponent<Text>().color = Color.white;
                LanePromptShadowObject.GetComponent<Text>().color = Color.black;
                break;
            case 1:
                DeselectAll();
                LanePromptObject2.GetComponent<Text>().color = Color.white;
                LanePromptShadowObject2.GetComponent<Text>().color = Color.black;
                break;
            case 2:
                DeselectAll();
                ColorPromptObject.GetComponent<Text>().color = Color.white;
                ColorPromptShadowObject.GetComponent<Text>().color = Color.black;
                break;
            case 3:
                DeselectAll();
                ColorPromptObject2.GetComponent<Text>().color = Color.white;
                ColorPromptShadowObject2.GetComponent<Text>().color = Color.black;
                break;

        }
	    CurrentBeat++;
	    CurrentBeat %= Timer.BeatsPerMeasure;

    }

    void DeselectAll()
    {
        LanePromptObject.GetComponent<Text>().color = Color.gray;
        LanePromptShadowObject.GetComponent<Text>().color = Color.clear;
        ColorPromptObject.GetComponent<Text>().color = Color.gray;
        ColorPromptShadowObject.GetComponent<Text>().color = Color.clear;
        LanePromptObject2.GetComponent<Text>().color = Color.gray;
        LanePromptShadowObject2.GetComponent<Text>().color = Color.clear;
        ColorPromptObject2.GetComponent<Text>().color = Color.gray;
        ColorPromptShadowObject2.GetComponent<Text>().color = Color.clear;
    }
}
