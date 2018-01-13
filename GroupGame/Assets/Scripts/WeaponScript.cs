using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hit an enemy");
            other.gameObject.GetComponent<Enemy>().TakeDamage(player.GetComponent<Player>().GetDamage());
            
        }
        else
        {
            Debug.Log(other.gameObject.name);
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
