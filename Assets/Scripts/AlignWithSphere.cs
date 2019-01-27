using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class AlignWithSphere : MonoBehaviour
{
    public Vector3 centerRot = Vector3.forward;

    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = Quaternion.Euler(centerRot) * Vector3.forward * 55;
        transform.eulerAngles = centerRot;
        
        if (player && EditorApplication.isPlaying)
        {
            transform.rotation = player.transform.rotation;
            Vector3 toPlayer = Vector3.Normalize(player.position);
            float dotDistance = Vector3.Dot(toPlayer, transform.position);

            if (dotDistance > 0)
            {
                float difference = player.position.magnitude - dotDistance;
                Vector3 fixedPosition = transform.position + (toPlayer * difference);
                transform.position = fixedPosition;
            }
        }


    }
}
