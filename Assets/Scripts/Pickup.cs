﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float water, maxWater, waterGain, waterLoss;
    public float heat, heatGain, heatLimit, heatLoss;
    public bool heatToggle = false;


    void Start()
    {


    }

    void Update()
    {
        if (heatToggle && heat < heatLimit)
        {
            heat += heatGain * Time.deltaTime;
            water -= waterLoss * Time.deltaTime;


            Debug.Log("can you see me");

        }

        else if (!heatToggle)
        {
            heat -= heatLoss * Time.deltaTime;
        }

        else
        {
            heatToggle = false;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            if (heatToggle == false && heat < heatLimit)
            {
                heatToggle = true;

                if (heatToggle && heat >= heatLimit)
                {
                    heatToggle = false;
                }

            }

            else
            {
                Debug.Log("can you see me");
                heatToggle = false;
            }
        }

        else if (collision.gameObject.tag == "Water")
        {

            Debug.Log("It Works");
            Destroy(collision.gameObject);

            water = +waterGain;
            Debug.Log(water);



        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            if (heat > heatLimit)
            {
                heat = heatLimit;
            }
            heatToggle = false;

        }

    }


}