using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracker : MonoBehaviour
{
    //public Transform trackingTarget;
    public GameObject player;
    public int mapa = 0;
    float x;
    float y;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null)
            mapa = GameManager.instance.GetComponent<BoardManager>().mapa;

        if (player == null)
            player = GameObject.Find("Jugador(Clone)");

        else if (player != null)
        {
            x = player.transform.position.x;
            y = player.transform.position.y;

            if (x < 7.84f)
                x = 7.84f;

            if (y < 4.5f)
                y = 4.5f;

            if (mapa == 1)
            {
                if (x > 51.15f)
                    x = 51.15f;

                if (y > 54.5f)
                    y = 54.5f;
            }

            if (mapa == 2)
            {
                if (x > 11.2f)
                    x = 11.2f;

                if (y > 10.5f)
                    y = 10.5f;
            }

            if (mapa == 3)
            {
                if (x > 10f)
                    x = 10f;

                if (y > 5.5f)
                    y = 5.5f;
            }
            transform.position = new Vector3(x, y, -10);
        }
    }

    
}
