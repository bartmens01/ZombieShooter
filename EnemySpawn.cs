using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy1;
    public GameObject enemy2;  
    public float spawnTime = 6f;
    Vector3 spawnPosition;
    public int spawned;
    bool canSpawn;
    public int zombies;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public int randomSpawn;
    public int spawnAmount;
    public int spawnUpgrade;
    public int spawnUpgradeAmount;
    public int addAmount;
    void Start()
    {
        spawnUpgradeAmount = 5;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        canSpawn = true;
    }

    void Spawn()
    {
        randomSpawn = Random.Range(1, 16);

        if (randomSpawn >= 1)
        {

            spawnPosition = new Vector3 (spawn1.transform.position.x, spawn1.transform.position.y, spawn1.transform.position.z);
        
        }
        if (randomSpawn >= 6)
        {

            spawnPosition = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y,spawn2.transform.position.z);

        }
        if (randomSpawn >= 11)
        {

            spawnPosition = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y, spawn3.transform.position.z);

        }
        if (canSpawn == true)
        {
            spawned++;
            zombies = Random.Range(1, 10);
            if (zombies <= 7)
            {
                Instantiate(enemy1, spawnPosition, Quaternion.identity);
            }
            if (zombies >= 8)
            {
                Instantiate(enemy2, spawnPosition, Quaternion.identity);
            }
        }
    }
    private void Update()
    {
        if (spawnAmount >= 50)
        {
            spawnAmount = 50;


        }
        if (spawnUpgrade == spawnUpgradeAmount )
        {
            spawnAmount += addAmount;
            spawnUpgradeAmount++;
            spawnUpgrade = 0;
        }
        if (spawned == spawnAmount)
        {
            canSpawn = false;
        
        }
        if (spawned <= 0)
        {
            canSpawn = true;
        }

    }

}
