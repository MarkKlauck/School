using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {
    public GameObject[] spawnLocation;
    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
        Instantiate(enemyPrefab, spawnLocation[0].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, spawnLocation[1].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, spawnLocation[2].transform.position, Quaternion.identity);
        Instantiate(enemyPrefab, spawnLocation[3].transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        int n = spawnLocation.Length;
        int o = 30;
        int Ecount = 4;
        int lastSpawnLoc = 0;
        while (o > 0)
        {
            yield return new WaitForSeconds(3);
            int i = Random.Range(0, n);
            if(i == lastSpawnLoc)
            {
                i++;
                if(i==n)
                {
                    i = 0;
                }
                lastSpawnLoc = i;
            }
            else
            {
                lastSpawnLoc = i;
            }
            Instantiate(enemyPrefab, spawnLocation[i].transform.position, Quaternion.identity);
            o--;
            Ecount++;
        }
    }
    // Update is called once per frame
    void Update () {
        //StartCoroutine(SpawnEnemies());
	}
    
}
