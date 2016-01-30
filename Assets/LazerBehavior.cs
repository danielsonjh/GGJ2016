using UnityEngine;
using System.Collections;

public class LazerBehavior : MonoBehaviour {

    public Note Note;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Notes.EntityColor[Note];
    }

}
