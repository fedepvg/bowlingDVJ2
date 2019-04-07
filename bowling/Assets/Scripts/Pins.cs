using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    int num;
    Transform pinTransf;
    float posY = -1.3f;
    float baseZ = 16f;
    float lineDistance = 1f;
    float[] posX = new float[9] {-2.12f,-1.69f,-1.06f,-0.53f,0f,0.53f,1.06f,1.69f,2.12f };

    public void SetNum(int n)
    {
        num = n;
    }

    private void OnEnable()
    {
        switch (num)
        {
            case 0:
                transform.position = new Vector3(0, posY, baseZ);
                break;
            case 1:
                transform.position = new Vector3(posX[3], posY, baseZ + lineDistance);
                break;
            case 2:
                transform.position = new Vector3(posX[5], posY, baseZ + lineDistance);
                break;
            case 3:
                transform.position = new Vector3(posX[2], posY, baseZ + lineDistance * 2);
                break;
            case 4:
                transform.position = new Vector3(posX[4], posY, baseZ + lineDistance * 2);
                break;
            case 5:
                transform.position = new Vector3(posX[6], posY, baseZ + lineDistance * 2);
                break;
            case 6:
                transform.position = new Vector3(posX[1], posY, baseZ + lineDistance * 3);
                break;
            case 7:
                transform.position = new Vector3(posX[3], posY, baseZ + lineDistance * 3);
                break;
            case 8:
                transform.position = new Vector3(posX[5], posY, baseZ + lineDistance * 3);
                break;
            case 9:
                transform.position = new Vector3(posX[7], posY, baseZ + lineDistance * 3);
                break;

        }
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        if(transform.rotation.z<=-70 || transform.rotation.z>=70)
        {
            gameObject.SetActive(false);
        }
    }
}
