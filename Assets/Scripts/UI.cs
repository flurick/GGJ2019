using UnityEngine;
using UnityEngine.UI;   //Required when using UI elements

public class UI : MonoBehaviour
{
    private Image waterImage;
    private Image warmthImage;

        [SerializeField]private float water;
        [SerializeField]private float maxWater;
        [SerializeField]private float heat;
        [SerializeField]private float maxHeat;

    public GameObject Pickup_script;
    public Pickup Earth;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI script start");
        Earth = Pickup_script.GetComponent<Pickup>();

        water = Earth.water;
        maxWater = Earth.maxWater;
        heat = Earth.heat;
        maxHeat = Earth.maxHeat;
    }

    // Update is called once per frame
    void Update()
    {
        //Update fill amount
        waterImage.fillAmount = water/maxWater;
        warmthImage.fillAmount = heat/maxHeat;
    }
}
