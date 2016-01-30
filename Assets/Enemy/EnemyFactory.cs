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

    public void ProceduralSpawns(int seed = 0)
    {
        System.Random random;
        if(seed == 0)
            random = new System.Random();
        else
            random = new System.Random(seed);
        
        
        string[] notes = {Note.A, Note.B, Note.C};
        var types = 3; //number of potential types
        var time = 20; //number of waves to generate for

        var pZero = 0.1; //probability "tiers" of spawning 0, 1, or 2 enemies in a wave
        var pOne = 0.8;
        var pTwo = 1.0;
        


        for (int i = 0; i < time; i++)
        {
            var r = random.NextDouble();
            if (r < pZero)
            {
                //wave of 0 enemies
            }
            else if (r < pOne)
            {
                //wave of 1 enemy
                _spawns.Add(new Enemy()
                {
                    Time = i,
                    Speed = 1,
                    Note = notes[random.Next(notes.Length)],
                    Type = random.Next(types)
                });
            }
            else if (r < pTwo)
            {
                //wave of 2 enemies
                var n1 = notes[random.Next(notes.Length)];
                _spawns.Add(new Enemy() {
                    Time = i,
                    Speed = 1,
                    Note = n1,
                    Type = random.Next(types)
                });

                var n2 = notes[random.Next(notes.Length)];
                while(n2 == n1)
                    n2 = notes[random.Next(notes.Length)];
                _spawns.Add(new Enemy() {
                    Time = i,
                    Speed = 1,
                    Note = n2,
                    Type = random.Next(types)
                });

            }
        }


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

