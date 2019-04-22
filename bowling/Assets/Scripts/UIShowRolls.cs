using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowRolls : MonoBehaviour
{
    Text rolls;

    private void Start()
    {
        rolls = GetComponent<Text>();
    }

    void Update()
    {
        if(rolls)
            rolls.text = "Rolls: " + GameManager.Instance.Rolls;
    }
}
