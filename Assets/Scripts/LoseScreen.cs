using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoseScreen : MonoBehaviour
{
    public float[] data1;
    public float[] data2;
    // Start is called before the first frame update
    void Start()
    {
        data1 = new float[24];
        data2 = new float[24];
    }

    // Update is called once per frame
    void Update()
    {
        data2 = data1.Concat(data2).ToArray();
        data1 = data2.Concat(data2).ToArray();
    }
}
