using System.Collections.Generic;

public class ZedFactory {

	List<Enemy> spawns;
	List<Enemy> enemiesToSpawn;
	int currentTime = 0;

	public ZedFactory() {
		spawns = new List<Enemy>();
        enemiesToSpawn = new List<Enemy>();

        //test spawning
        spawns.Add(new Enemy {time = 1, type = 1, column = 1});
	}

    //a number of "turns" has been taken
    public void updateTime(int deltaTime = 1){
		currentTime += deltaTime;
		prepSpawns();
	}

	private void prepSpawns(){
		foreach(Enemy e in spawns){
			if(e.time <= currentTime){
				enemiesToSpawn.Add(e);
			}
		}
		foreach(Enemy e in enemiesToSpawn){
			spawns.Remove(e);
		}
	}

	public Enemy[] getSpawnedUnits(){
        Enemy[] enemies = enemiesToSpawn.ToArray();
		enemiesToSpawn.Clear();
        return enemies;
	}

    

}

public struct Enemy {
	public int time,
		       type,
		       column;
    
    public override string ToString() {
        return "Enemy: {time = " + time + ", type = " + type + ", column = " + column + "}";
    }
}

