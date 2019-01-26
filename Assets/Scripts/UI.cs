using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Required when using UI elements

public class UI : MonoBehaviour
{
    public Image waterImage;
    public Image warmthImage;

    public float waterLevel;
    public float warmthLevel;

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 1;
        warmthLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Update fill amount
        waterImage.fillAmount = waterLevel;
        warmthImage.fillAmount = warmthLevel;

        waterLevel -= (float)0.0001;
        warmthLevel -= (float)0.0001;
    }
}
