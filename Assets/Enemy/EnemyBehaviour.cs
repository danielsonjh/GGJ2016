using UnityEngine;

[RequireComponent(typeof (Collider2D))]
public class EnemyBehaviour : MonoBehaviour
{

    public GameObject DeathGameObject;

    public Enemy Enemy;

    private static Vector2 MovementVelocity = new Vector2(0,-2.5f);

    public void SetEnemy(Enemy enemy)
    {
        Enemy = enemy;
        GetComponent<SpriteRenderer>().color = Notes.EntityColor[Enemy.Color];
    }

    void Update()
    {
        if (Timer.CurrentBeat == 0)
        {
            GetComponent<Rigidbody2D>().velocity = MovementVelocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var name = other.gameObject.name;
        if (name == "Keyboard" || name == "Laser(Clone)"  && other.GetComponent<LazerBehavior>().Note == Enemy.Color)
        {
            var deathExplosion = Instantiate(DeathGameObject);
            deathExplosion.transform.position = this.transform.position;
            deathExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            if (name == "Laser(Clone)")
            {
                Stats.Instance.Score++;
            }
        }
    }
}

