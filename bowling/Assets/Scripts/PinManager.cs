using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    public GameObject pins;
    GameObject[] instances = new GameObject[10];
    bool resetPins = false;

    public int GetDisables()
    {
        int disablesCount = 0;

        for (int i = 0; i < 10; i++)
        {
            if (!instances[i].activeSelf)
            {
                disablesCount++;
            }
        }

        return disablesCount;
    }

    public void SetResetPins(bool s)
    {
        resetPins = s;
    }

    public bool GetResetPins()
    {
        return resetPins;
    }

    void ResetPins()
    {
        for (int i = 0; i < 10; i++)
        {
            instances[i].SetActive(false);
            instances[i].SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(pins);
            instances[i] = go;
            instances[i].SetActive(false);
            instances[i].GetComponent<Pins>().SetNum(i);
            instances[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(resetPins)
        {
            ResetPins();
            resetPins = false;
        }
    }
}
