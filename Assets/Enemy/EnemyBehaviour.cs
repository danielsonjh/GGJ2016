using UnityEngine;

[RequireComponent(typeof (Collider2D))]
public class EnemyBehaviour : MonoBehaviour
{

    public GameObject DeathGameObject;
    public Enemy Enemy;

    private float moveDistance;
    private float moveDistanceInit = 0.3f;

    private static Vector2 MovementVelocity = new Vector2(0,-6f);

    public void SetEnemy(Enemy enemy)
    {
        Enemy = enemy;
        GetComponent<SpriteRenderer>().color = Notes.EntityColor[Enemy.Color];
    }

    void Update()
    {
        /*
        if (moveDistance >= 0)
        {
            float distanceToMove = Mathf.Abs(MovementVelocity.y * Time.deltaTime);
            transform.position -= new Vector3(0, distanceToMove);
            moveDistance -= distanceToMove;
        }*/
    }
    void Start()
    {
        Timer.OnChangeBeat += OnChangeBeat;
    }

    void OnDestroy()
    {
        Timer.OnChangeBeat -= OnChangeBeat;
    }

    void OnChangeBeat()
    {
        //float distanceToMove = Mathf.Abs(MovementVelocity.y * Time.deltaTime);
        transform.position -= new Vector3(0, moveDistanceInit);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var name = other.gameObject.name;
        if (name == "Keyboard" || name == "Laser(Clone)"  && other.GetComponent<LazerBehavior>().Note == Enemy.Color)
        {
            var deathExplosion = Instantiate(DeathGameObject);
            deathExplosion.transform.position = this.transform.position;
            deathExplosion.GetComponent<ParticleSystem>().Play();
            Camera.main.GetComponent<AudioManager>().PlayEnemyAudio(Enemy.Color);
            Destroy(gameObject);
            if (name == "Laser(Clone)")
            {
                Stats.Instance.IncreaseScoreByOne();
            }
        }
    }
}

