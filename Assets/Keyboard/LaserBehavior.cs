using UnityEngine;

public class LaserBehavior : MonoBehaviour
{

    public Note Note;

    void Start()
    {
        var particleSystems = GetComponentsInChildren<ParticleSystem>();
        particleSystems[0].startColor = Notes.EntityColor[Note];
        particleSystems[1].startColor = Notes.SecondaryColor[Note];
        foreach (var particleSystem in particleSystems)
        {
            particleSystem.Simulate(1f);
            particleSystem.Play();
        }
    }
}
