using UnityEngine;
using UnityEngine.UI;   //Required when using UI elements

public class UI : MonoBehaviour
{
    private Image waterImage;
    private Image warmthImage;
    private float water;
    private float maxWater;
    private float heat;
    private float maxHeat;

    public GameObject Pickup_script;
    private Pickup Earth;

    // Start is called before the first frame update
    void Start()
    {
        Earth = Pickup_script.GetComponent<Pickup>();

        water = Earth.water;
        heat = Earth.heat;
    }

    // Update is called once per frame
    void Update()
    {
        //Update fill amount
        waterImage.fillAmount = water;
        warmthImage.fillAmount = heat;
    }
}
