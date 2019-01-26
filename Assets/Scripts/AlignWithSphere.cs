using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AlignWithSphere : MonoBehaviour
{
    public Vector3 centerRot = Vector3.forward;


    void Update()
    {
        transform.position = Quaternion.Euler(centerRot) * Vector3.forward * 55;
        transform.eulerAngles = centerRot;
        //transform.rotation = GameObject.Find("Player").transform.rotation;
    }
}
