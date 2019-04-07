﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rig;
    float horMov;
    float verMov;
    float baseSpeed = 150f;
    float ballSpeed;
    bool wasThrown = false;
    Vector3 initPos;
    public GameObject lane;
    float leftLim;
    float rightLim;

    private void OnEnable()
    {
        ballSpeed = 300f;
        transform.position = initPos;
        rig.useGravity = false;
        wasThrown = false;
        rig.velocity = new Vector3(0, 0, 0);
    }

    private void Awake()
    {
        initPos = transform.position;
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        leftLim = lane.transform.position.x - lane.transform.localScale.x / 2f;
        rightLim = lane.transform.position.x + lane.transform.localScale.x / 2f;
        //rig.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        horMov = Input.GetAxis("Horizontal");
        verMov = Input.GetAxis("Vertical");

        if (horMov != 0)
        {
            transform.position += transform.right * horMov * 5f * Time.deltaTime;
        }
        if (verMov!=0)
        {
            ballSpeed += verMov * baseSpeed * Time.deltaTime;
            Debug.Log("vel:" + ballSpeed);
        }
        if(transform.position.x<leftLim)
        {
            transform.position =initPos+transform.right*leftLim;
        }
        if (transform.position.x > rightLim)
        {
            transform.position = initPos + transform.right * rightLim;
        }

        if (rig.velocity.z <= 0.5 && wasThrown)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.useGravity = true;
            wasThrown = true;
            rig.AddForce(transform.forward * ballSpeed,ForceMode.Acceleration);
        }
        
    }
}
