using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public GameObject pins;
    List<GameObject> instances;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            instances.Add(Instantiate(pins));
            instances[i].SetActive(false);
            instances[i].GetComponent<Pins>().SetNum(i);
            instances[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
