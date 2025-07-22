using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rg;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
        rg.AddForce(kuvvet * 10f);
    }
}
