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
    }

    void Update()
    {
        if (!AlreadySpawnedThisMeasure && Timer.CurrentBeat == 0)
        {
            var enemies = GenerateWave();
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

    public List<Enemy> GenerateWave(int seed = 0)
    {
        System.Random random;
        if (seed == 0)
        {
            random = new Random();
        }
        else
        {
            random = new Random(seed);
        }

        var types = 3; //number of potential types


        var probabilityOfEnemyCount = new[] { 0.1, 0.8, 1 };

        //determine number of enemies spawned
        var r = random.NextDouble();
        var numEnemies = 0;
        for (int n = 0; n < probabilityOfEnemyCount.Length; n++)
        {
            if (r <= probabilityOfEnemyCount[n])
            {
                numEnemies = n;
                break;
            }
        }

        //determine lanes for enemies
        var EnemyLanes = new Note[numEnemies]; ;
        for (int k = 0; k < numEnemies; k++)
        {
            bool uniqueLane = false;


            while (!uniqueLane)
            {
                uniqueLane = true;
                var lane = Notes.GetRandom();
                //get new lane if repeat
                for (int l = 0; l < EnemyLanes.Length; l++)
                {
                    if (lane == EnemyLanes[l])
                    {
                        uniqueLane = false;
                    }
                }
                if (uniqueLane)
                {
                    EnemyLanes[k] = lane;
                }
            }

        }

        //Generate enemies
        var EnemyWave = new List<Enemy>();
        for (int j = 0; j < numEnemies; j++)
        {
            var color = Notes.GetRandom();
            var type = random.Next(types);

            Enemy enemy = new Enemy()
            {
                Speed = EnemySpeed,
                Lane = EnemyLanes[j],
                Color = color,
                Type = type
            };
            EnemyWave.Add(enemy);
            _spawns.Add(enemy);
        }

        return EnemyWave;
    }
}
