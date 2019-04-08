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
    public GameObject pinManager;

    public int getRolls()
    {
        return rolls;
    }

    public void initRolls()
    {
        rolls = 0;
    }

    public void ResetBall()
    {
        rig.isKinematic = true;
        ballSpeed = 1000f;
        transform.position = initPos;
        wasThrown = false;
        rig.velocity = new Vector3(0, 0, 0);
        rig.rotation = Quaternion.identity;
        rig.isKinematic = false;
        if(rolls==3 || pinManager.GetComponent<PinManager>().GetDisables()==10)
        {
            rolls = 0;
            pinManager.GetComponent<PinManager>().SetResetPins(true);
        }
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
            transform.position += Vector3.right * horMov * 5f * Time.deltaTime;
        }
        if (verMov != 0 && !wasThrown)
        {
            ballSpeed += verMov * baseSpeed * Time.deltaTime;
            Debug.Log("vel:" + ballSpeed);
        }
        if (transform.position.x < leftLim && !wasThrown)
        {
            transform.position = initPos + Vector3.right * leftLim;
        }
        if (transform.position.x > rightLim && !wasThrown)
        {
            transform.position = initPos + Vector3.right * rightLim;
        }

        if (ballSpeed < 1000)
        {
            ballSpeed = 1000;
        }
        if (ballSpeed > 1700)
        {
            ballSpeed = 1700;
        }

        if (rig.velocity.z <= 0.1f && wasThrown)
        {
            timer += Time.deltaTime;
            if (timer>2f)
            {
                ResetBall();
                timer = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !wasThrown)
        {
            rolls++;
            Debug.Log("roll " + rolls);
            wasThrown = true;
            rig.AddForce(Vector3.forward * ballSpeed, ForceMode.Acceleration);
        }
    }
}
