using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public float water, maxWater, waterGain, waterLoss;
    public float heat, heatGain, maxHeat, heatLoss;
    public bool heatToggle,blackHoleToggle,earthLives = false;
  

    public Sprite mySprite; 
    public SpriteRenderer spriteR;
    public Animator animator;

    void Start()
    {
      
        heat = 100f;
        water = 100f; 
        
        maxWater = 100f;
        waterGain = 30f;
        heatGain = 10f; 
        animator = GetComponent<Animator>();
      //  this.GetComponent<SpriteRenderer>().sprite = mySprite; 
      //Comment
    }

    void Update()
    {
        if (heatToggle)
        {
            heat += heatGain * Time.deltaTime;
            water -= waterLoss * Time.deltaTime;

            animator.SetFloat("heat", heat);
            Debug.Log("can you see me");

            if (heat > maxHeat)
            {
                heat = maxHeat; 
                 if (water <= 0 || heat <= 0)
                {
                    PlayerDeath();
                }

            }

            else if (water <= 0 || heat <= 0)
            {
                PlayerDeath();
            }




        }

        else if (!heatToggle)
        {
            heat -= heatLoss * Time.deltaTime;

            animator.SetFloat("heat", heat);

            if (blackHoleToggle)
            {
                heatLoss = heatLoss + 10;

                water -= waterLoss * Time.deltaTime; 
            }

            else if(water <= 0 || heat <= 0)
            {
                PlayerDeath();
            }
        }



        else if (heat <= 0 || water <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene());
        }

   

    }





    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            if (heatToggle == false && heat < maxHeat)
            {
                heatToggle = true;


                if (heatToggle && heat >= maxHeat)
                {
                    heatLoss = 0f; 
                    heatToggle = false;
                }

            }

        }

        else if (collision.gameObject.tag == "Water")
        {

            Debug.Log("It Works");
            Destroy(collision.gameObject);
            if (water <= maxWater)
            {
                water += waterGain;
                Debug.Log(water);

                if (water >= maxWater)
                {
                    water = 100f; 
                }
            }

        
           



        }

        else if (collision.gameObject.tag == "Blackhole")
        {
            blackHoleToggle = true;
            Debug.Log("blackhole");
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            if (heat > maxHeat)
            {
                heat = maxHeat;
            }
            Debug.Log("i've exited");
            heatLoss = 10f; 
            heatToggle = false;
            Debug.Log("I've exited");

        }

       else if (collision.gameObject.tag == "Blackhole")
        {
            blackHoleToggle = false; 
        }

    }

    void PlayerDeath()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }


}
