using UnityEngine;
using UnityEngine.UI;

public class Prompts : MonoBehaviour
{
    public Color ActiveColor;
    public Color InactiveColor;
    public Color ShadowColor;

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
        Timer.OnPreciseBeat += PromptUpdate;
    }

    void OnDestroy()
    {
        Timer.OnPreciseBeat -= PromptUpdate;
    }

    void PromptUpdate () 
    {
        switch (CurrentBeat) 
        {
            case 0:
                DeselectAll();
                LanePromptObject.GetComponent<Text>().color = ActiveColor;
                LanePromptShadowObject.GetComponent<Text>().color = ShadowColor;
                break;
            case 1:
                DeselectAll();
                LanePromptObject2.GetComponent<Text>().color = ActiveColor;
                LanePromptShadowObject2.GetComponent<Text>().color = ShadowColor;
                break;
            case 2:
                DeselectAll();
                ColorPromptObject.GetComponent<Text>().color = ActiveColor;
                ColorPromptShadowObject.GetComponent<Text>().color = ShadowColor;
                break;
            case 3:
                DeselectAll();
                ColorPromptObject2.GetComponent<Text>().color = ActiveColor;
                ColorPromptShadowObject2.GetComponent<Text>().color = ShadowColor;
                break;

        }
	    CurrentBeat++;
	    CurrentBeat %= Timer.BeatsPerMeasure;

    }

    void DeselectAll()
    {
        LanePromptObject.GetComponent<Text>().color = InactiveColor;
        LanePromptShadowObject.GetComponent<Text>().color = Color.clear;
        ColorPromptObject.GetComponent<Text>().color = InactiveColor;
        ColorPromptShadowObject.GetComponent<Text>().color = Color.clear;
        LanePromptObject2.GetComponent<Text>().color = InactiveColor;
        LanePromptShadowObject2.GetComponent<Text>().color = Color.clear;
        ColorPromptObject2.GetComponent<Text>().color = InactiveColor;
        ColorPromptShadowObject2.GetComponent<Text>().color = Color.clear;
    }
}
