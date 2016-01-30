using UnityEngine;

[RequireComponent(typeof (Collider2D))]
public class EnemyBehaviour : MonoBehaviour
{

    public GameObject DeathGameObject;

    public Enemy Enemy;


    public void SetEnemy(Enemy enemy)
    {
        Enemy = enemy;
        GetComponent<SpriteRenderer>().color = Notes.EntityColor[Enemy.
            Color];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var name = other.gameObject.name;
        if (name == "Keyboard" || name == "Laser(Clone)" && other.GetComponent<LazerBehavior>().Note == Enemy.Color)
        {
            var deathExplosion = Instantiate(DeathGameObject);
            deathExplosion.transform.position = this.transform.position;
            deathExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            Stats.Instance.Score++;
        }
    }
}

