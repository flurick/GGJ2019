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

    }

    // Update is called once per frame
    void Update()
    {
        warmth = pickupScript.heat;
        maxWarmth = pickupScript.maxHeat;
        water = pickupScript.water;
        maxWater = pickupScript.maxWater;


        waterImage.fillAmount = water / maxWater;
        warmthImage.fillAmount = warmth / maxWarmth;
    }
}
