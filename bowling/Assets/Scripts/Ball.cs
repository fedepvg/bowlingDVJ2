using System.Collections;
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
    float timer;
    int rolls;

    public int getRolls()
    {
        return rolls;
    }

    public void initRolls()
    {
        rolls = 0;
    }

    private void OnEnable()
    {
        ballSpeed = 1000f;
        transform.position = initPos;
        rig.useGravity = false;
        wasThrown = false;
        rig.velocity = new Vector3(0, 0, 0);
        rig.rotation = Quaternion.identity;
        rig.isKinematic = false;
    }

    private void OnDisable()
    {
        rig.isKinematic = true;
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
    }

    // Update is called once per frame
    void Update()
    {
        horMov = Input.GetAxis("Horizontal");
        verMov = Input.GetAxis("Vertical");

        if (horMov != 0 && !wasThrown)
        {
            transform.position += transform.right * horMov * 5f * Time.deltaTime;
        }
        if (verMov != 0 && !wasThrown)
        {
            ballSpeed += verMov * baseSpeed * Time.deltaTime;
            Debug.Log("vel:" + ballSpeed);
        }
        if (transform.position.x < leftLim)
        {
            transform.position = initPos + transform.right * leftLim;
        }
        if (transform.position.x > rightLim)
        {
            transform.position = initPos + transform.right * rightLim;
        }

        if (ballSpeed < 800)
        {
            ballSpeed = 800;
        }
        if (ballSpeed > 1700)
        {
            ballSpeed = 1700;
        }

        if (rig.velocity.z <= 0f && wasThrown)
        {
            timer += Time.deltaTime;
            if (timer>2f)
            {
                gameObject.SetActive(false);
                timer = 0f;
                //gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !wasThrown)
        {
            rolls++;
            Debug.Log("roll " + rolls);
            rig.useGravity = true;
            wasThrown = true;
            rig.AddForce(Vector3.forward * ballSpeed, ForceMode.Acceleration);
        }
    }
}
