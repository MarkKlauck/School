using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Constants.PickupType type;
    public int value;
    // Use this for initialization

    void Start()
    {
        type = (Constants.PickupType)Random.Range(0, System.Enum.GetValues(typeof(Constants.PickupType)).Length);
        GetComponent<Rigidbody>().AddForce(transform.up * 30, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().PickupItem(type, value);
        }

        //decrement current item
        PickupSpawn.Instance.DecrementCurrentItems();
        Destroy(gameObject);
    }
}