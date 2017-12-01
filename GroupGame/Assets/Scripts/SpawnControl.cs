using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {
    public GameObject[] spawnLocation;
    public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
        Instantiate(enemyPrefab, spawnLocation[0].transform);
        Instantiate(enemyPrefab, spawnLocation[1].transform);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
