using UnityEngine;
using System.Collections;

public class ContextualDisplay : MonoBehaviour
{
    public int LaneNum;
    public bool LanePosition;
    private bool _showing = false;
    private CanvasGroup _canvasGroup;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (LanePosition = true)
        {
            if (ModeControl.numberOfLanes >= LaneNum && !_showing)
            {
                _showing = true;
                GetComponent<CanvasFader>().FadeIn();
            }
            else if (ModeControl.numberOfLanes < LaneNum && _showing)
            {
                _showing = false;
                GetComponent<CanvasFader>().FadeOut();
            }
        } else
        {
            if (ModeControl.numberOfColors >= LaneNum && !_showing)
            {
                _showing = true;
                GetComponent<CanvasFader>().FadeIn();
            }
            else if (ModeControl.numberOfColors < LaneNum && _showing)
            {
                _showing = false;
                GetComponent<CanvasFader>().FadeOut();
            }
        }
    }
}