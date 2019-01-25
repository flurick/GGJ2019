using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float up = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        Vector3 movement = transform.rotation * new Vector3(-up, right);

        transform.RotateAround(Vector3.zero, -movement, moveSpeed * Time.deltaTime);
    }
}
