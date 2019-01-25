using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int water, maxWater, waterGain;
    public int heat, maxHeat, heatGain;

    void Start()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("It Works"); 
            Destroy(collision.gameObject);

            water =+ waterGain; 
            Debug.Log(water);

        }


    }


}
