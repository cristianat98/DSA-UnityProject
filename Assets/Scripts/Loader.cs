using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }
}
