using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EnemyGameObject;

    private const int EnemySpeed = 2;
    private const int OffsetFromNote = 10;

	private List<Enemy> EnemyCollection;

    private bool AlreadySpawnedThisMeasure = false;
    private int CurrentTime = 0;

    private double[] ProbabilityOfEnemyCount = { 0.1, 0.6, 0.8, 0.95, 1};
    
    void Start()
    {
        EnemyCollection = new List<Enemy>();
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
        foreach (var e in EnemyCollection)
        {
            if (e.Time <= CurrentTime)
            {
                enemiesToSpawn.Add(e);
            }
        }
        
        foreach (var e in enemiesToSpawn)
        {
            EnemyCollection.Remove(e);
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
            EnemyCollection.Add(enemy);
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
        EnemyCollection.Add(enemy);
        return enemy;

    }

    public List<Enemy> GenerateWave()
    {

        System.Random random;
        random = new Random();

        var r = 0.0;
        //determine number of enemies spawned
        if (ModeControl.numberOfLanes <= ProbabilityOfEnemyCount.Length)
        {
            r = random.NextDouble() * ProbabilityOfEnemyCount[ModeControl.numberOfLanes - 1];
        } else
        {
            r = random.NextDouble() * ProbabilityOfEnemyCount[ProbabilityOfEnemyCount.Length - 1];
        }
            var numEnemies = 0;
        for (int n = 0; n < ModeControl.numberOfLanes; n++)
        {
            if (r <= ProbabilityOfEnemyCount[n])
            {
                numEnemies = n;
                break;
            }
        }

        var EnemyLanes = new Note[numEnemies];
        var numOfLanesDesignated = 0;
        for (int k = 0; k < numEnemies; k++)
        {
            bool uniqueLane = false;


            while (!uniqueLane)
            {
                uniqueLane = true;
                var lane = (Note)random.Next(0, ModeControl.numberOfLanes);
                //get new lane if repeat
                for (int l = 0; l < numOfLanesDesignated; l++)
                {
                    if (lane == EnemyLanes[l])
                    {
                        uniqueLane = false;
                    }
                }
                if (uniqueLane)
                {
                    EnemyLanes[k] = lane;
                    numOfLanesDesignated++;
                }
            }

        }

        var EnemyWave = new List<Enemy>();
        for (int j = 0; j < numEnemies; j++)
            
        {
            Note color = 0;
            if (ModeControl.numberOfColors <= 5)
            {
                color = (Note)random.Next(0, ModeControl.numberOfColors);
            }
            else
            {
                color = (Note)random.Next(0, 5);
            }
            EnemyWave.Add(GenerateEnemy(color, EnemyLanes[j]));
        }

        return EnemyWave;
    }
}
