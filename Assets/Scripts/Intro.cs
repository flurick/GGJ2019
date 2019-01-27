using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    RectTransform IntroPicture;
    public float scrollSpeed;
    public float positionTriggerY;

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 0.5f;
        positionTriggerY = 700f;
        IntroPicture = GameObject.Find("IntroPicture").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IntroPicture.position.y < 900){
            transform.Translate(0f, scrollSpeed, 0f);
        }else{
            SceneManager.LoadScene("Level1");
        }
        

    }

}
