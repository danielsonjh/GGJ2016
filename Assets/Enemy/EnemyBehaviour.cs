using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyBehaviour : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Score.Instance.Value++;
        Destroy(gameObject);
    }
}
