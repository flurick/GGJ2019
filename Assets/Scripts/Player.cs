﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15;
    
    [SerializeField] bool randomRotStart = true;

    // Start is called before the first frame update
    void Start()
    {
        if (randomRotStart)
        {
            transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        }   
    }

    // Update is called once per frame
    void Update()
    {
        float up = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 movement = transform.rotation * new Vector3(up, -right);
        gameObject.transform.Find("Player").GetComponent<SpriteRenderer>().flipX = right>0;

        transform.RotateAround(Vector3.zero, movement, moveSpeed * Time.deltaTime);
    }
}
