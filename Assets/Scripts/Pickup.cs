using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public float water, maxWater, waterGain, waterLoss,blackHoleDamageW;
    public float heat, heatGain, maxHeat, heatLoss,blackHoleDamageH;
    public bool heatToggle,blackHoleToggle,earthLives = false;


    public string nextLevel; 
  

    public Sprite mySprite; 
    public SpriteRenderer spriteR;
    public Animator animator;

    void Start()
    {
        blackHoleDamageH = 5;
         
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
                heatLoss = heatLoss + blackHoleDamageH ;

                water -= waterLoss + blackHoleDamageW * Time.deltaTime;

             
                if (water <= 0 || heat <= 0)
                {
                    PlayerDeath();
                }
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
                    heat = maxHeat ; 
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

        else if (collision.gameObject.tag == "Wormhole")
        {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
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
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
    }


}
