using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public GameObject pins;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(pins);
            go.SetActive(false);
            go.GetComponent<Pins>().SetNum(i);
            go.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
