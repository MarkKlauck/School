using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupSpawn : MonoBehaviour {

    private static PickupSpawn instance;

    public static PickupSpawn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PickupSpawn>();
                if (instance == null)
                {
                    GameObject container = new GameObject();
                    instance = container.AddComponent<PickupSpawn>();
                }
            }

            return instance;
        }
    }

    public Vector3 CenterOfTerrain = new Vector3(300.0f, 1, 250.0f);
    public GameObject pickUpItem;
    public int min_items = 5;
    public int max_items = 20;
    public float start_spawn_time = 10.0f;
    public float spawn_time = 10.0f;
    public int try_finding_spawnPos = 20;
    public float range = 200;
    // Use this for initialization

    private int currentSpawnItems = 0;
    void Start ()
    {
        InvokeRepeating("SpawnItems", start_spawn_time, spawn_time);
        currentSpawnItems = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void DecrementCurrentItems()
    {
        --currentSpawnItems;
    }

    void SpawnItems()
    {
        //check if there are items more than max items
        int capacity = max_items - currentSpawnItems;
        if (capacity <= 0)
            return;

        int item_count = Random.Range(min_items, max_items);

        if (item_count >= capacity)
            item_count = capacity;

        for(int count = 0; count < item_count; ++count)
        {
            Vector3 spawn_pos;
            if(FindSpawnPosInNav(out spawn_pos) == true)
            {
                currentSpawnItems++;
                Instantiate(pickUpItem, spawn_pos, Quaternion.identity);
            }
        }

    }

    bool FindSpawnPosInNav(out Vector3 pos)
    {
        for (int i = 0; i < try_finding_spawnPos; i++)
        {
            Vector3 randomPoint = CenterOfTerrain + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                pos = hit.position;
                return true;
            }
        }

        pos = Vector3.zero;
        return false;
    }
}
