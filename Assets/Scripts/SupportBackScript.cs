
using UnityEngine;

public class SupportBackScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                AndroidJavaClass javaClass = new AndroidJavaClass("edu.upc.login.apiUnity");
                javaClass.CallStatic("guardarStats", GameManager.instance.duracion, GameManager.instance.puntos);
                Application.Quit();
            }
        }
    }
}
