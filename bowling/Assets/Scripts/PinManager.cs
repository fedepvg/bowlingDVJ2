using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    private static PinManager instance;
    int disabledPins;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(DisabledPins==10)
        {
            GameManager.Instance.ResetGame();
        }
    }

    public static PinManager Instance
    {
        get { return instance; }
    }

    public int DisabledPins
    {
        get { return disabledPins; }
        set { disabledPins = value; }
    }

    public void AddDisablePinCount()
    {
        disabledPins++;
    }
}
