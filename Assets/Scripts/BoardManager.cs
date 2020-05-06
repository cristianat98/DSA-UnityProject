using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;	

    public void SetupScene()
    {
        boardHolder = new GameObject("Board").transform;
        for (float x = -4.5f; x < 5.5; x++)
        {
            for (float y = -4.5f; y < 5.5; y++)
            {
                GameObject instance = Instantiate(acera, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }
}
