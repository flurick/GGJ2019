using UnityEngine;
using UnityEngine.UI;   //Required when using UI elements

public class UI : MonoBehaviour
{
    public Image waterImage;
    public Image warmthImage;

    public float water;
    public float maxWater;
    public float warmth;
    public float maxWarmth;

    public Pickup pickupScript;
    public GameObject Earth;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI script start");

        Earth = GameObject.Find("Player");
        if(Earth == null){
            Debug.Log("UI could not find Player object");
        }else{
            pickupScript = Earth.GetComponent<Pickup>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Check if Player object exists
        if(Earth != null){
            warmth = pickupScript.heat;
            maxWarmth = pickupScript.maxHeat;
            water = pickupScript.water;
            maxWater = pickupScript.maxWater;            
        }else{
            warmth = maxWarmth = water = maxWater = 100;
        }

        waterImage.fillAmount = water / maxWater;
        warmthImage.fillAmount = warmth / maxWarmth;
    }
}
