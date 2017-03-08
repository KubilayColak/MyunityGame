using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
            
    public enum SpawnTypes
    {
        TimedWave
    }

    public GameObject zombie, gui;
    public Text starting, enemiesRemain;

    public int totalEnemy = 10;
    private int numEnemy = 0;
    private int killedEnemy = 0;
    private int enemiesLeft;


    private int SpawnID;
    
    private bool waveSpawn = false, text = true;
    static public bool Spawn = true;
    public SpawnTypes spawnType = SpawnTypes.TimedWave;
    // timed wave controls
    private float waveTimer  = 0.0f, countdown;
    public float timeTillWave = 10.0f;
    //Wave controls
    public int totalWaves;
    private int numWaves;

    void Start()
    {
        // sets a random number for the id of the spawner
        SpawnID = Random.Range(1, 500);
    }

    void Update()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Spawn)
        {
            enemiesLeft = totalWaves * 4 - killedEnemy;
            // Spawns enemies in waves but based on time.
            if (spawnType == SpawnTypes.TimedWave)
            {
                starting.text = TimeTillWave.ToString("F0");
                // checks if the number of waves is bigger than the total waves
                if (numWaves <= totalWaves)
                {
                    // Increases the timer to allow the timed waves to work
                    timeTillWave -= Time.deltaTime;
                    if (waveSpawn)
                    {
                        //spawns an enemy
                        spawnEnemy();
                    }
                    // checks if the time is equal to the time required for a new wave
                    if (timeTillWave <= waveTimer)
                    {
                        text = false;
                        // enables the wave spawner
                        waveSpawn = true;
                        // sets the time back to zero
                        if (MyData.round <= 5)
                        {
                            timeTillWave = 10.0f;
                        }
                        if (MyData.round <= 10)
                        {
                            timeTillWave = 15.0f;
                        }
                        // increases the number of waves
                        numWaves++;
                        // A hack to get it to spawn the same number of enemies regardless of how many have been killed
                        numEnemy = 0;
                    }
                    if (numEnemy >= totalEnemy)
                    {
                        // diables the wave spawner
                        waveSpawn = false;
                    }
                }
                else
                {
                    if (enemiesLeft <= 0)
                    {
                        if (MyData.round <= 5)
                        {
                            totalWaves = 0;
                        }
                        if (MyData.round <= 10)
                        {
                            totalWaves = 1;
                        }
                        totalWaves++;
                        enemiesLeft = 0;
                        killedEnemy = 0;
                        Spawn = false;
                        MyData.round++;
                        numWaves = 1;
                    }
                }
            }
        }
        if (text)
        {
            gui.SetActive(true);

        }
        if (!text)
        {
            if (Spawn)
            {
                enemiesRemain.text = "Enemies Left: " + enemiesLeft.ToString();
            }
            starting.text = "Kill Them!";
            countdown += Time.deltaTime;
            if (countdown >= 3)
            {
                gui.SetActive(false);
            }
        }        
    }
    // spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {
        GameObject[] enemySpawnSystem = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawnPoint in enemySpawnSystem)
        {
            GameObject Enemy = (GameObject)Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
            Enemy.SendMessage("setName", SpawnID);
            print(SpawnID);
            numEnemy++;
        }
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killEnemy(int sID)
    {
        // if the enemy's spawnId is equal to this spawnersID then remove an enemy count
        if (SpawnID == sID)
        {
            numEnemy--;
            killedEnemy++;
        }
    }
    //enable the spawner based on spawnerID
    public void enableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = true;
        }
    }
    //disable the spawner based on spawnerID
    public void disableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = false;
        }
    }
    // returns the Time Till the Next Wave, for a interface, ect.
    public float TimeTillWave
    {
        get
        {
            return timeTillWave;
        }
    }
    // Enable the spawner, useful for trigger events because you don't know the spawner's ID.
    public void enableTrigger()
    {
        Spawn = true;
    }
}
