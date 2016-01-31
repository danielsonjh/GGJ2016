using UnityEngine;

public class LazerBehavior : MonoBehaviour {

    public Note Note;

    void Start()
    {
        GetComponentInChildren<ParticleSystem>().startColor = Notes.EntityColor[Note];
    }

}
