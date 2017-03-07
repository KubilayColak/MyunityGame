using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    /*public GameObject gui, zombie;
    public int maxSpawned;
    float roundStart = 10, countdown;
    public Text starting;
    static public bool isWave = true, text = true, spawn = false;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        starting.text = roundStart.ToString("F0");
        if (isWave == true && !MyManager.isPause)
        {
            Wave();
        }
        if (spawn)
        {
            //Spawn();
        }
    }

    void Wave()
    {
        gui.SetActive(true);
        roundStart -= Time.deltaTime;
        if (roundStart <= 0)
        {
            roundStart = 99999999999;
            MyData.round++;
            spawn = true;
            text = false;
        }
        if (!text)
        {
            starting.text = "Kill Them!";
            countdown += Time.deltaTime;
            if (countdown >= 3)
            {
                gui.SetActive(false);
            }
        }
    }

    void Spawn()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < maxSpawned; i++)
        {
            MyData.round++;

            for (int j = 0; j < 1; j++)
            {
                GameObject zombies = Instantiate(zombie, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                MyData.round++;
            }
        }

        spawn = false;
    }
    */
        
    public enum SpawnTypes
    {
        TimedWave
    }

    public GameObject zombie, gui;
    public Text starting;

    public int totalEnemy = 10;
    private int numEnemy = 0;
    private int spawnedEnemy = 0;
    
    private int SpawnID;
    
    private bool waveSpawn = false, text = true;
    static public bool Spawn = true;
    public SpawnTypes spawnType = SpawnTypes.TimedWave;
    // timed wave controls
    public float waveTimer  = 0.0f;
    private float timeTillWave = 10.0f, countdown;
    //Wave controls
    public int totalWaves = 5;
    private int numWaves = 0;

    void Start()
    {
        // sets a random number for the id of the spawner
        SpawnID = Random.Range(1, 500);
    }

    void Update()
    {
        print(Spawn);
        if (Spawn)
        {
            // Spawns enemies in waves but based on time.
            if (spawnType == SpawnTypes.TimedWave)
            {
                starting.text = timeTillWave.ToString("F0");
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
                        timeTillWave = 10.0f;
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
                    Spawn = false;
                }
            }
        }
        if (text)
        {
            gui.SetActive(true);
        }
        if (!text)
        {
            starting.text = "Kill Them!";
            countdown += Time.deltaTime;
            if (countdown >= 3)
            {
                gui.SetActive(false);
                text = true;
            }
        } 
    }
    // spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {
        GameObject Enemy = (GameObject)Instantiate(zombie, gameObject.transform.position, Quaternion.identity);
        Enemy.SendMessage("setName", SpawnID);
        // Increase the total number of enemies spawned and the number of spawned enemies
        numEnemy++;
        spawnedEnemy++;
    }
    // Call this function from the enemy when it "dies" to remove an enemy count
    public void killEnemy(int sID)
    {
        // if the enemy's spawnId is equal to this spawnersID then remove an enemy count
        if (SpawnID == sID)
        {
            numEnemy--;
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
