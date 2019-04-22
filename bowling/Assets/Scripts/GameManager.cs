using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField]
    private Ball ball;
    int rolls;

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

    public static GameManager Instance
    {
        get { return instance; }
    }

    public int Rolls
    {
        get { return rolls; }
    }

    public void AddRoll()
    {
        rolls++;
    }

    public void ResetGame()
    {
        PinManager.Instance.DisabledPins = 0;
        rolls = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
