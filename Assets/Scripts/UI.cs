using UnityEngine;
using UnityEngine.UI;   //Required when using UI elements

public class UI : MonoBehaviour
{
    public Image waterImage;
    public Image warmthImage;

    [SerializeField] private float water;
    [SerializeField] private float maxWater;
    [SerializeField] private float warmth;
    [SerializeField] private float maxWarmth;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UI script start");

    }

    // Update is called once per frame
    void Update()
    {
        waterImage.fillAmount = water/maxWater;
        warmthImage.fillAmount = warmth/maxWarmth;
    }
}
