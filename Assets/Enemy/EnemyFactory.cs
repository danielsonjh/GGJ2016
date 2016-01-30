using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EnemyGameObject;

    private const int EnemySpeed = 2;
    private const int OffsetFromNote = 10;

	private List<Enemy> _spawns;

    private bool AlreadySpawnedThisMeasure = false;
    private int CurrentTime = 0;

    void Start()
    {
        _spawns = new List<Enemy>();

        ProceduralSpawns();
    }

    void Update()
    {
        if (!AlreadySpawnedThisMeasure && Timer.CurrentBeat == 0)
        {
            var enemies = GetSpawns();
            foreach (var enemy in enemies)
            {
                SpawnEnemy(enemy);
            }
            AlreadySpawnedThisMeasure = true;
        }

        if (Timer.CurrentBeat != 0)
        {
            AlreadySpawnedThisMeasure = false;
        }
    }
    
    public List<Enemy> GetSpawns(){
        var enemiesToSpawn = new List<Enemy>();
        foreach (var e in _spawns)
        {
            if (e.Time <= CurrentTime)
            {
                enemiesToSpawn.Add(e);
            }
        }
        
        foreach (var e in enemiesToSpawn)
        {
            _spawns.Remove(e);
        }

        CurrentTime++;
        return enemiesToSpawn;
    }

    public void SpawnEnemy(Enemy enemy)
    {
        var clone = Instantiate(EnemyGameObject);
        clone.transform.position = Notes.KeyPositions[enemy.Lane] + Vector2.up * OffsetFromNote;
        //clone.GetComponent<Rigidbody2D>().velocity = Vector2.down * enemy.Speed;
        clone.GetComponent<EnemyBehaviour>().SetEnemy(enemy);
    }

    public void ProceduralSpawns(int seed = 0)
    {
        System.Random random;
        if(seed == 0)
        {
            random = new Random();
        }
        else
        {
            random = new Random(seed);
        }
        
        var types = 3; //number of potential types
        var endTime = 200;

        var probabilityOfEnemyCount = new[] {0.1, 0.8, 1};

        for (int i = 1; i < endTime; i ++)
        {
            var r = random.NextDouble();
            for (int n = 0; n < probabilityOfEnemyCount.Length; n++)
            {
                if (r > probabilityOfEnemyCount[n]) continue;
                var notesAlreadySpawned = new List<Note>();

                for (int j = 0; j < n; j++)
                {
                    if (notesAlreadySpawned.Count >= probabilityOfEnemyCount.Length)
                    {
                        break;
                    }

                    var lane = Notes.GetRandom();
                    var color = Notes.GetRandom();

                    while (notesAlreadySpawned.Contains(lane))
                    {
                        lane = Notes.GetRandom();
                    }

                    var type = random.Next(types);

                    _spawns.Add(new Enemy()
                    {
                        Time = i,
                        Speed = EnemySpeed,
                        Lane = lane,
                        Color = color,
                        Type = type
                    });
                    notesAlreadySpawned.Add(lane);
                }

                break;
            }
        }
    }
}
