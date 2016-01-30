using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EnemyGameObject;
    private const int OffsetFromNote = 5;
	private List<Enemy> _spawns;

    void Start()
    {
        _spawns = new List<Enemy>();

        _spawns.Add(new Enemy { Time = 1, Speed = 1, Type = 1, Note = Note.A });
        _spawns.Add(new Enemy { Time = 2, Speed = 1, Type = 1, Note = Note.C });
        _spawns.Add(new Enemy { Time = 3, Speed = 1, Type = 1, Note = Note.A });
        _spawns.Add(new Enemy { Time = 4, Speed = 1, Type = 1, Note = Note.B });
    }

    void Update()
    {
        var enemies = GetSpawns(Time.time);
        foreach (var enemy in enemies)
        {
            SpawnEnemy(enemy);
        }
    }
    
    public List<Enemy> GetSpawns(float currentTime){
        var enemiesToSpawn = new List<Enemy>();
        foreach (var e in _spawns)
        {
            if (e.Time <= currentTime)
            {
                enemiesToSpawn.Add(e);
            }
        }
        
        foreach (var e in enemiesToSpawn)
        {
            _spawns.Remove(e);
        }

        return enemiesToSpawn;
    }

    public void SpawnEnemy(Enemy enemy)
    {
        var clone = Instantiate(EnemyGameObject);
        clone.transform.position = Note.KeyPositions[enemy.Note] + Vector2.up * OffsetFromNote;
        clone.GetComponent<Rigidbody2D>().velocity = Vector2.down * enemy.Speed;
    }
}

public class Enemy
{
    public float Time;
    public float Speed;
    public string Note;
    public int Type;
    
    public override string ToString() {
        return "Enemy: {Time = " + Time + ", Type = " + Type + ", Note = " + Note + "}";
    }
}

