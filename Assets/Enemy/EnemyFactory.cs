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
    private double[] ProbabilityOfEnemyCountDifficult = { 0.1, 0.6, 0.8, 0.95, 1 };
    private double[] ProbabilityOfEnemyCount = { 0.1, 0.8, 1};

    void Start()
    {
        _spawns = new List<Enemy>();
    }

    void Update()
    {
        if (!AlreadySpawnedThisMeasure && Timer.CurrentBeat == 0)
        {
            double[] probabilities;
            int count;
            if (Stats.Instance.Difficult)
            {
                probabilities = ProbabilityOfEnemyCountDifficult;
                count = 5;
            }
            else
            {
                probabilities = ProbabilityOfEnemyCount;
                count = 3;
            }

            var enemies = GenerateWave(probabilities, count);
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

    /*
    generate an enemy with random color and lane
    */
    public Enemy GenerateEnemy()
    {
        
        Enemy enemy = new Enemy()
        {
            Speed = EnemySpeed,
            Lane = Notes.GetRandom(),
            Color = Notes.GetRandom()
        };
            //add to list of all enemies
            _spawns.Add(enemy);
        return enemy;

    }

    /*
    generate an enemy with given color and lane
    */
    public Enemy GenerateEnemy(Note color, Note lane)
    {
        Enemy enemy = new Enemy()

        {
            Speed = EnemySpeed,
            Lane = lane,
            Color = color
        };
        //add to list of all enemies
        _spawns.Add(enemy);
        return enemy;

    }

    public List<Enemy> GenerateWave(double[] probabilities, int maxTypes)
    {

<<<<<<< HEAD
        var probabilityOfEnemyCount = new[] { 0.1, 0.6, 0.8, 0.95, 1};
=======
        
>>>>>>> a728c546f4e355b5c03c58d8f3cd6c697ea05c50

        System.Random random;
        random = new Random();
        
        //determine number of enemies spawned
        var r = random.NextDouble();
        var numEnemies = 0;
        for (int n = 0; n < probabilities.Length; n++)
        {
            if (r <= probabilities[n])
            {
                numEnemies = n;
                break;
            }
        }

        //determine lanes for enemies
        var EnemyLanes = new Note[numEnemies];
        for (int k = 0; k < numEnemies; k++)
        {
            bool uniqueLane = false;


            while (!uniqueLane)
            {
                uniqueLane = true;
                var lane = Notes.GetRandom(maxTypes);
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
            var color = Notes.GetRandom(maxTypes);
            EnemyWave.Add(GenerateEnemy(color, EnemyLanes[j]));
        }

        return EnemyWave;
    }
}
