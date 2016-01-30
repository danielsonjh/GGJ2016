using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyBehaviour : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        var name = other.gameObject.name;
        if (name == "Laser(Clone)")
        {
            Stats.Instance.Score++;
        }
        Destroy(gameObject);
    }
}
