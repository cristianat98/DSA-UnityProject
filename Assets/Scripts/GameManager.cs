using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;
    public static GameManager instance = null;
    public int healthPoints = 100;
    public float levelStartDelay = 5f;
    public GameObject presentacion;
    public GameObject presentacionFinal;
    public GameObject encargado1;
    public GameObject entremapas;
    public GameObject restart;
    public GameObject quit;
    public GameObject final;
    public Text textoPersonajes;
    public Text entreMapas;
    public Text presentacionText;
    public Text presentacionFinalText;
    private Text tiempoText;
    public int minutos, segundos;
    private float contador;
    public Text puntosText;
    public bool doingSetup;
    public bool llave = false;
    public bool codigo = false;
    public bool contagio = false;
    public int nivel = 0;
    public int puntos;
    public string duracion;
    string mapa;
    string personajes;
    public int cantidadDesinfectante;
    public int cantidadDesinfectantePlus;
    public int cantidadDesinfectantePro;
    public int cantidadJabon;
    public int cantidadMascarilla;
    public int cantidadMegaMascarilla;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        InicializarObjetos();

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

                    mapa = "60 60 1                                                    \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

               personajes = "48      \n" +
                            "P 7 3 1            \n" +
                            "0 0 0 23 11 0 0    \n" +
                            "1 0 48 23 11 0 0   \n" +
                            "2 36 48 23 11 0 0  \n" +
                            "3 36 0 23 11 0 0   \n" +
                            "4 22 0 15 11 0 0   \n" +
                            "0 0 10 15 11 0 0   \n" +
                            "1 44 10 15 11 0 0  \n" +
                            "2 44 38 15 11 0 0  \n" +
                            "3 0 38 15 11 0 0   \n" +
                            "4 22 48 15 11 0 0  \n" +
                            "0 0 20 59 19 0 0   \n" +
                            "1 22 1 21 9 2 1    \n" +
                            "2 58 1 21 9 2 1    \n" +
                            "3 58 49 21 9 2 1   \n" +
                            "4 22 49 21 9 2 1   \n" +
                            "0 58 39 13 9 2 1   \n" +
                            "1 36 1 13 9 2 1    \n" +
                            "2 58 11 13 9 2 1   \n" +
                            "3 14 11 13 9 2 1   \n" +
                            "4 14 39 13 9 2 1   \n" +
                            "0 36 49 13 9 2 1   \n" +
                            "1 58 21 57 17 2 1  \n" +
                            "2 14 10 31 11 0 0  \n" +
                            "3 44 11 29 9 2 1   \n" +
                            "4 14 38 31 11 0 0  \n" +
                            "0 44 39 29 9 2 1   \n" +
                            "H 24 9   \n" +
                            "H 2 22   \n" +
                            "H 2 30   \n" +
                            "H 57 30  \n" +
                            "H 16 40  \n" +
                            "H 24 50  \n" +
                            "H 40 37  \n" +
                            "H 16 19  \n" +
                            "H 43 12  \n" +
                            "H 43 47  \n" +
                            "V 21 2   \n" +
                            "V 38 9   \n" +
                            "V 13 12  \n" +
                            "V 46 19  \n" +
                            "V 23 37  \n" +
                            "V 34 22  \n" +
                            "V 13 47  \n" +
                            "V 21 50  \n" +
                            "V 46 40  \n" +
                            "V 38 57  \n" +
                            "L 46 37  \n";

#else
                mapa = "60 60 1                                                    \n" +
                        "A9555555555555555555559955555555599599555555555555555555559C\n" +
                        "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                        "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                        "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                        "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "7155555555555599555555415555G5555555415555559955555555555548\n" +
                        "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                        "EF            EF                            EF            EF\n" +
                        "EF            EF   hhhhh                    EF            EF\n" +
                        "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                        "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                        "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                        "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                        "EF            EF                            EF            EF\n" +
                        "EF            EF                            EF            EF\n" +
                        "71555555555555415555G555555555555555G55555554155555555555548\n" +
                        "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                        "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                        "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                        "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                        "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                        "EFiiiii ggggg           pppppppppp                        EF\n" +
                        "EF                      pppppppppp                        EF\n" +
                        "EF                      pppppppppp                        EF\n" +
                        "EF                      pppppppppp                        EF\n" +
                        "EF                      pppppppppp                        EF\n" +
                        "EF                      pppppppppp             ggggg iiiiiEF\n" +
                        "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                        "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                        "EFddddd fffff                                  ggggg iiiiiEF\n" +
                        "EFddddd ffff                                   ggggg iiiiiEF\n" +
                        "EF                                                        EF\n" +
                        "EF                                                        EF\n" +
                        "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                        "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                        "EF            EF                            EF            EF\n" +
                        "EF            EF     hhhhh                  EF            EF\n" +
                        "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                        "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                        "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                        "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                        "EF            EF                            EF            EF\n" +
                        "EF            EF                            EF            EF\n" +
                        "7155555555555541555555995555G5555995555555554155555555555548\n" +
                        "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                        "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                        "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                        "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "EF                    EF            EF                    EF\n" +
                        "715555555555555555555541555555555555415555555555555555555548\n" +
                        "026666666666666666666622666666666666226666666666666666666623\n";

        
            personajes = "48      \n" +
                         "P 7 3 1            \n" +
                         "0 0 0 23 11 0 0    \n" +
                         "1 0 48 23 11 0 0   \n" +
                         "2 36 48 23 11 0 0  \n" +
                         "3 36 0 23 11 0 0   \n" + 
                         "4 22 0 15 11 0 0   \n" +
                         "0 0 10 15 11 0 0   \n" +
                         "1 44 10 15 11 0 0  \n" +
                         "2 44 38 15 11 0 0  \n" +
                         "3 0 38 15 11 0 0   \n" +
                         "4 22 48 15 11 0 0  \n" +
                         "0 0 20 59 19 0 0   \n" +
                         "1 22 1 21 9 2 1    \n" +
                         "2 58 1 21 9 2 1    \n" +
                         "3 58 49 21 9 2 1   \n" +
                         "4 22 49 21 9 2 1   \n" +
                         "0 58 39 13 9 2 1   \n" +
                         "1 36 1 13 9 2 1    \n" +
                         "2 58 11 13 9 2 1   \n" +
                         "3 14 11 13 9 2 1   \n" +
                         "4 14 39 13 9 2 1   \n" +
                         "0 36 49 13 9 2 1   \n" +
                         "1 58 21 57 17 2 1  \n" +
                         "2 14 10 31 11 0 0  \n" +
                         "3 44 11 29 9 2 1   \n" +
                         "4 14 38 31 11 0 0  \n" +
                         "0 44 39 29 9 2 1   \n" +
                         "H 24 9   \n" +
                         "H 2 22   \n" +
                         "H 2 30   \n" +
                         "H 57 30  \n" +
                         "H 16 40  \n" +
                         "H 24 50  \n" +
                         "H 40 37  \n" +
                         "H 16 19  \n" +
                         "H 43 12  \n" +
                         "H 43 47  \n" +
                         "V 21 2   \n" +
                         "V 38 9   \n" +
                         "V 13 12  \n" +
                         "V 46 19  \n" +
                         "V 23 37  \n" +
                         "V 34 22  \n" +
                         "V 13 47  \n" +
                         "V 21 50  \n" +
                         "V 46 40  \n" +
                         "V 38 57  \n" +
                         "L 46 37  \n";

#endif
        nivel++;
        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;
        presentacion = GameObject.Find("Presentacion");
        presentacionFinal = GameObject.Find("Final");
        encargado1 = GameObject.Find("Encargado1");
        entremapas = GameObject.Find("EntreMapas");
        puntosText = GameObject.Find("PuntosText").GetComponent<Text>();
        tiempoText = GameObject.Find("DuracionText").GetComponent<Text>();
        textoPersonajes = GameObject.Find("Text").GetComponent<Text>();
        entreMapas = GameObject.Find("EntreMapasText").GetComponent<Text>();
        presentacionText = GameObject.Find("TextPresentacion").GetComponent<Text>();
        presentacionFinalText = GameObject.Find("TextPresentacionFinal").GetComponent<Text>();

        restart = GameObject.Find("Restart");
        quit = GameObject.Find("Quit");

        presentacion.SetActive(false);
        presentacionFinal.SetActive(false);
        entremapas.SetActive(false);
        encargado1.SetActive(false);
        restart.SetActive(false);
        quit.SetActive(false);

        if (instance.nivel == 1)
        {
            presentacion.SetActive(true);
        }
        else if (instance.nivel == 2)
        {
            entremapas.SetActive(true);
        }
        else if (instance.nivel == 3)
        {
            entreMapas.text = "Por fin consigo dar con la maldita clave. No sé que problemas más me puedo encontrar. ¡Esto es surrealista! No vuelvo a venir a Mercadona fijo.";
            entremapas.SetActive(true);
        }

        else if (instance.nivel == 4)
        {
            entreMapas.text = "La cosa se me complica. El amargado ese ha avisado a la policía. Baah!! Seguro que era un farol y no ha llamado a nadie.";
            entremapas.SetActive(true);
        }

        else if (instance.nivel == 5)
        {
            entreMapas.text = "Puff he conseguido escapar por los pelos, pero a saber que me encuentro ahora en la calle.";
            entremapas.SetActive(true);
        }

        boardScript.SetupScene(instance.mapa, instance.personajes);

        Invoke("HidePresentacion", levelStartDelay);
    }

    void Update()
    {
        if (!instance.doingSetup)
        {
            contador += Time.deltaTime;
            if (contador >= 1)
            {
                contador = 0;
                segundos++;
            }

            if (segundos >= 60)
            {
                minutos++;
                segundos = 0;
            }
            instance.duracion = minutos + ":" + segundos;
        }
        if (segundos/10 < 1 && minutos/10 < 1)
            tiempoText.text = "Duración: 0" + minutos + ":0" + segundos;

        else if (segundos/10 < 1)
            tiempoText.text = "Duración: " + minutos + ":0" + segundos;

        else if (minutos/10 < 1)
            tiempoText.text = "Duración: 0" + minutos + ":" + segundos;

        else
            tiempoText.text = "Duración: " + minutos + ":" + segundos;

        puntosText.text = "Puntuación: " + instance.puntos;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if (instance.nivel == 0)
        {
            instance.codigo = false;
            instance.llave = false;
            instance.segundos = 0;
            instance.minutos = 0;
            instance.contador = 0;
            instance.puntos = 0;
            instance.mapa = "60 60 1                                                     \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "48      \n" +
                            "P 7 3 1            \n" +
                            "0 0 0 23 11 0 0    \n" +
                            "1 0 48 23 11 0 0   \n" +
                            "2 36 48 23 11 0 0  \n" +
                            "3 36 0 23 11 0 0   \n" +
                            "4 22 0 15 11 0 0   \n" +
                            "0 0 10 15 11 0 0   \n" +
                            "1 44 10 15 11 0 0  \n" +
                            "2 44 38 15 11 0 0  \n" +
                            "3 0 38 15 11 0 0   \n" +
                            "4 22 48 15 11 0 0  \n" +
                            "0 0 20 59 19 0 0   \n" +
                            "1 22 1 21 9 2 1    \n" +
                            "2 58 1 21 9 2 1    \n" +
                            "3 58 49 21 9 2 1   \n" +
                            "4 22 49 21 9 2 1   \n" +
                            "0 58 39 13 9 2 1   \n" +
                            "1 36 1 13 9 2 1    \n" +
                            "2 58 11 13 9 2 1   \n" +
                            "3 14 11 13 9 2 1   \n" +
                            "4 14 39 13 9 2 1   \n" +
                            "0 36 49 13 9 2 1   \n" +
                            "1 58 21 57 17 2 1  \n" +
                            "2 14 10 31 11 0 0  \n" +
                            "3 44 11 29 9 2 1   \n" +
                            "4 14 38 31 11 0 0  \n" +
                            "0 44 39 29 9 2 1   \n" +
                            "H 24 9   \n" +
                            "H 2 22   \n" +
                            "H 2 30   \n" +
                            "H 57 30  \n" +
                            "H 16 40  \n" +
                            "H 24 50  \n" +
                            "H 40 37  \n" +
                            "H 16 19  \n" +
                            "H 43 12  \n" +
                            "H 43 47  \n" +
                            "V 21 2   \n" +
                            "V 38 9   \n" +
                            "V 13 12  \n" +
                            "V 46 19  \n" +
                            "V 23 37  \n" +
                            "V 34 22  \n" +
                            "V 13 47  \n" +
                            "V 21 50  \n" +
                            "V 46 40  \n" +
                            "V 38 57  \n" +
                            "L 46 37  \n";
            SoundManager.instance.curar();
        }
        
        else if (instance.nivel == 1)
            {
            instance.mapa = "20 16 2             \n" +
                             "33333333 001100117 8\n" +
                             "3                   \n" +
                             "3                   \n" +
                             "3     2222222222    \n" +
                             "3     2222222222    \n" +
                             "3                   \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "565      44444444444\n";

            instance.personajes = "3                 \n" +
                                  "P 1 0 0           \n" +
                                  "H 2 1             \n" +
                                  "G 18 10 16 4 0 0  \n";

        }

        else if (instance.nivel == 2)
        {
            instance.mapa = "19 11 3            \n" +
                            "                   \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMMM00100MMMMMM \n" +
                            " MMMMMMMMMMMMMMMMM \n" +
                            " MMMMMMMMMMMMMMMMM \n" +
                            "                   \n" +
                            "                   \n" +
                            "                   \n" +
                            "                 6 \n";

            instance.personajes = "4               \n" +
                                  "H 18 0          \n" +
                                  "P 17 0 0        \n" +
                                  "G 0 3 18 7 1 0  \n" +
                                  "G 16 2 15 2 2 1 \n";                    
        }

        else if (instance.nivel == 3)
        {
            instance.mapa = "20 16 2              \n" +
                             "33333333 001100117 8\n" +
                             "3                   \n" +
                             "3                   \n" +
                             "3     2222222222    \n" +
                             "3     2222222222    \n" +
                             "3                   \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "565      44444444444\n";

            instance.personajes = "6                 \n" +
                                  "P 18 14 1         \n" +
                                  "H 2 1             \n" +
                                  "G 1 13 18 1 3 1   \n" +
                                  "G 19 2 12 3 1 1   \n" +
                                  "G 0 9 6 7 0 1     \n" +
                                  "G 19 10 12 4 0 0  \n";
        }

        else if (instance.nivel == 4)
        {
            instance.mapa = "60 60 1                                                    \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "66      \n" +
                         "P 49 33 1          \n" +
                         "0 0 0 23 11 0 0    \n" +
                         "1 0 48 23 11 0 0   \n" +
                         "2 36 48 23 11 0 0  \n" +
                         "3 36 0 23 11 0 0   \n" +
                         "4 22 0 15 11 0 0   \n" +
                         "0 0 10 15 11 0 0   \n" +
                         "1 44 10 15 11 0 0  \n" +
                         "2 44 38 15 11 0 0  \n" +
                         "3 0 38 15 11 0 0   \n" +
                         "4 22 48 15 11 0 0  \n" +
                         "0 0 20 59 19 0 0   \n" +
                         "1 22 1 21 9 2 1    \n" +
                         "2 58 1 21 9 2 1    \n" +
                         "3 58 49 21 9 2 1   \n" +
                         "4 22 49 21 9 2 1   \n" +
                         "0 58 39 13 9 2 1   \n" +
                         "1 36 1 13 9 2 1    \n" +
                         "2 58 11 13 9 2 1   \n" +
                         "3 14 11 13 9 2 1   \n" +
                         "4 14 39 13 9 2 1   \n" +
                         "0 36 49 13 9 2 1   \n" +
                         "1 58 21 57 17 2 1  \n" +
                         "2 14 10 31 11 0 0  \n" +
                         "3 44 11 29 9 2 1   \n" +
                         "4 14 38 31 11 0 0  \n" +
                         "0 44 39 29 9 2 1   \n" +
                         "G 2 9 17 7 3 0     \n" +
                         "G 57 9 17 7 2 1    \n" +
                         "G 57 57 17 7 2 1   \n" +
                         "G 2 57 17 7 3 0    \n" +
                         "G 26 17 6 3 3 0    \n" +
                         "G 24 8 9 6 3 0     \n" +
                         "G 37 32 19 3 3 0   \n" +
                         "G 2 19 9 7 3 0     \n" +
                         "G 57 19 9 7 2 1    \n" +
                         "G 16 18 4 5 3 0    \n" +
                         "G 43 18 5 5 2 1    \n" +
                         "G 2 32 20 4 3 0    \n" +
                         "G 2 47 9 7 3 0     \n" +
                         "G 57 47 9 7 2 1    \n" +
                         "G 16 46 2 5 3 0    \n" +
                         "G 43 46 3 5 2 1    \n" +
                         "G 24 45 7 5 2 1    \n" +
                         "G 24 57 11 6 3 0   \n" +
                         "H 24 9   \n" +
                         "H 2 22   \n" +
                         "H 2 30   \n" +
                         "H 57 30  \n" +
                         "H 16 40  \n" +
                         "H 24 50  \n" +
                         "H 40 37  \n" +
                         "H 16 19  \n" +
                         "H 43 12  \n" +
                         "H 43 47  \n" +
                         "V 21 2   \n" +
                         "V 38 9   \n" +
                         "V 13 12  \n" +
                         "V 46 19  \n" +
                         "V 23 37  \n" +
                         "V 34 22  \n" +
                         "V 13 47  \n" +
                         "V 21 50  \n" +
                         "V 46 40  \n" +
                         "V 38 57  \n" +
                         "L 46 37  \n";
        }

        else if (instance.nivel == 6)
        {
            instance.mapa = "60 60 1                                                    \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "48      \n" +
                         "P 4 23 1           \n" +
                         "0 0 0 23 11 0 0    \n" +
                         "1 0 48 23 11 0 0   \n" +
                         "2 36 48 23 11 0 0  \n" +
                         "3 36 0 23 11 0 0   \n" +
                         "4 22 0 15 11 0 0   \n" +
                         "0 0 10 15 11 0 0   \n" +
                         "1 44 10 15 11 0 0  \n" +
                         "2 44 38 15 11 0 0  \n" +
                         "3 0 38 15 11 0 0   \n" +
                         "4 22 48 15 11 0 0  \n" +
                         "0 0 20 59 19 0 0   \n" +
                         "1 22 1 21 9 2 1    \n" +
                         "2 58 1 21 9 2 1    \n" +
                         "3 58 49 21 9 2 1   \n" +
                         "4 22 49 21 9 2 1   \n" +
                         "0 58 39 13 9 2 1   \n" +
                         "1 36 1 13 9 2 1    \n" +
                         "2 58 11 13 9 2 1   \n" +
                         "3 14 11 13 9 2 1   \n" +
                         "4 14 39 13 9 2 1   \n" +
                         "0 36 49 13 9 2 1   \n" +
                         "1 58 21 57 17 2 1  \n" +
                         "2 14 10 31 11 0 0  \n" +
                         "3 44 11 29 9 2 1   \n" +
                         "4 14 38 31 11 0 0  \n" +
                         "0 44 39 29 9 2 1   \n" +
                         "H 24 9   \n" +
                         "H 2 22   \n" +
                         "H 2 30   \n" +
                         "H 57 30  \n" +
                         "H 16 40  \n" +
                         "H 24 50  \n" +
                         "H 40 37  \n" +
                         "H 16 19  \n" +
                         "H 43 12  \n" +
                         "H 43 47  \n" +
                         "V 21 2   \n" +
                         "V 38 9   \n" +
                         "V 13 12  \n" +
                         "V 46 19  \n" +
                         "V 23 37  \n" +
                         "V 34 22  \n" +
                         "V 13 47  \n" +
                         "V 21 50  \n" +
                         "V 46 40  \n" +
                         "V 38 57  \n" +
                         "L 46 37  \n";
            instance.nivel = 0;
        }

 #else
        if (instance.nivel == 0)
        {
            instance.codigo = false;
            instance.llave = false;
            instance.segundos = 0;
            instance.minutos = 0;
            instance.contador = 0;
            instance.puntos = 0;

            instance.mapa = "60 60 1                                                    \n" +
                            "A9555555555555555555559955555555599599555555555555555555559C\n" +
                            "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "7155555555555599555555415555G5555555415555559955555555555548\n" +
                            "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF   hhhhh                    EF            EF\n" +
                            "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                            "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "71555555555555415555G555555555555555G55555554155555555555548\n" +
                            "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg           pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff                                  ggggg iiiiiEF\n" +
                            "EFddddd ffff                                   ggggg iiiiiEF\n" +
                            "EF                                                        EF\n" +
                            "EF                                                        EF\n" +
                            "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                            "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF     hhhhh                  EF            EF\n" +
                            "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                            "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "7155555555555541555555995555G5555995555555554155555555555548\n" +
                            "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "715555555555555555555541555555555555415555555555555555555548\n" +
                            "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "48      \n" +
                                  "P 7 3 1            \n" +
                                  "0 0 0 23 11 0 0    \n" +
                                  "1 0 48 23 11 0 0   \n" +
                                  "2 36 48 23 11 0 0  \n" +
                                  "3 36 0 23 11 0 0   \n" +
                                  "4 22 0 15 11 0 0   \n" +
                                  "0 0 10 15 11 0 0   \n" +
                                  "1 44 10 15 11 0 0  \n" +
                                  "2 44 38 15 11 0 0  \n" +
                                  "3 0 38 15 11 0 0   \n" +
                                  "4 22 48 15 11 0 0  \n" +
                                  "0 0 20 59 19 0 0   \n" +
                                  "1 22 1 21 9 2 1    \n" +
                                  "2 58 1 21 9 2 1    \n" +
                                  "3 58 49 21 9 2 1   \n" +
                                  "4 22 49 21 9 2 1   \n" +
                                  "0 58 39 13 9 2 1   \n" +
                                  "1 36 1 13 9 2 1    \n" +
                                  "2 58 11 13 9 2 1   \n" +
                                  "3 14 11 13 9 2 1   \n" +
                                  "4 14 39 13 9 2 1   \n" +
                                  "0 36 49 13 9 2 1   \n" +
                                  "1 58 21 57 17 2 1  \n" +
                                  "2 14 10 31 11 0 0  \n" +
                                  "3 44 11 29 9 2 1   \n" +
                                  "4 14 38 31 11 0 0  \n" +
                                  "0 44 39 29 9 2 1   \n" +
                                  "H 24 9   \n" +
                                  "H 2 22   \n" +
                                  "H 2 30   \n" +
                                  "H 57 30  \n" +
                                  "H 16 40  \n" +
                                  "H 24 50  \n" +
                                  "H 40 37  \n" +
                                  "H 16 19  \n" +
                                  "H 43 12  \n" +
                                  "H 43 47  \n" +
                                  "V 21 2   \n" +
                                  "V 38 9   \n" +
                                  "V 13 12  \n" +
                                  "V 46 19  \n" +
                                  "V 23 37  \n" +
                                  "V 34 22  \n" +
                                  "V 13 47  \n" +
                                  "V 21 50  \n" +
                                  "V 46 40  \n" +
                                  "V 38 57  \n" +
                                  "L 46 37  \n";
            SoundManager.instance.curar();
        }

        else if (instance.nivel == 1)
        {

            instance.mapa = "20 16 2             \n" +
                            "33333333 001100117 8\n" +
                                "3                   \n" +
                                "3                   \n" +
                                "3     2222222222    \n" +
                                "3     2222222222    \n" +
                                "3                   \n" +
                                "                    \n" +
                                "   MMM  2222222222  \n" +
                                "   MMM  2222222222  \n" +
                                "                    \n" +
                                "                    \n" +
                                "   MMM  2222222222  \n" +
                                "   MMM  2222222222  \n" +
                                "                    \n" +
                                "                    \n" +
                                "565      44444444444\n";

            instance.personajes = "3                 \n" +
                                    "P 1 0 0           \n" +
                                    "H 2 1             \n" +
                                    "G 18 10 16 4 0 0  \n";

        }

        else if (instance.nivel == 2)
        {

            instance.mapa = "19 11 3            \n" +
                            "                   \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMM       MMMMM \n" +
                            " MMMMMM00100MMMMMM \n" +
                            " MMMMMMMMMMMMMMMMM \n" +
                            " MMMMMMMMMMMMMMMMM \n" +
                            "                   \n" +
                            "                   \n" +
                            "                   \n" +
                            "                 6 \n";

            instance.personajes = "4               \n" +
                                    "H 18 0          \n" +
                                    "P 17 0 0        \n" +
                                    "G 0 3 18 7 1 0  \n" +
                                    "G 16 2 15 2 2 1 \n";
        }

        else if (instance.nivel == 3)
        {

            instance.mapa = "20 16 2              \n" +
                                "33333333 001100117 8\n" +
                                "3                   \n" +
                                "3                   \n" +
                                "3     2222222222    \n" +
                                "3     2222222222    \n" +
                                "3                   \n" +
                                "                    \n" +
                                "   MMM  2222222222  \n" +
                                "   MMM  2222222222  \n" +
                                "                    \n" +
                                "                    \n" +
                                "   MMM  2222222222  \n" +
                                "   MMM  2222222222  \n" +
                                "                    \n" +
                                "                    \n" +
                                "565      44444444444\n";

            instance.personajes = "6                 \n" +
                                    "P 18 14 1         \n" +
                                    "H 2 1             \n" +
                                    "G 1 13 18 1 3 1   \n" +
                                    "G 19 2 12 3 1 1   \n" +
                                    "G 0 9 6 7 0 1     \n" +
                                    "G 19 10 12 4 0 0  \n";
        }

        else if (instance.nivel == 4)
        {

            instance.mapa = "60 60 1                                                    \n" +
                            "A9555555555555555555559955555555599599555555555555555555559C\n" +
                            "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "7155555555555599555555415555G5555555415555559955555555555548\n" +
                            "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF   hhhhh                    EF            EF\n" +
                            "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                            "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "71555555555555415555G555555555555555G55555554155555555555548\n" +
                            "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg           pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff                                  ggggg iiiiiEF\n" +
                            "EFddddd ffff                                   ggggg iiiiiEF\n" +
                            "EF                                                        EF\n" +
                            "EF                                                        EF\n" +
                            "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                            "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF     hhhhh                  EF            EF\n" +
                            "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                            "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "7155555555555541555555995555G5555995555555554155555555555548\n" +
                            "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "715555555555555555555541555555555555415555555555555555555548\n" +
                            "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "66      \n" +
                                  "P 49 33 1          \n" +
                                  "0 0 0 23 11 0 0    \n" +
                                  "1 0 48 23 11 0 0   \n" +
                                  "2 36 48 23 11 0 0  \n" +
                                  "3 36 0 23 11 0 0   \n" +
                                  "4 22 0 15 11 0 0   \n" +
                                  "0 0 10 15 11 0 0   \n" +
                                  "1 44 10 15 11 0 0  \n" +
                                  "2 44 38 15 11 0 0  \n" +
                                  "3 0 38 15 11 0 0   \n" +
                                  "4 22 48 15 11 0 0  \n" +
                                  "0 0 20 59 19 0 0   \n" +
                                  "1 22 1 21 9 2 1    \n" +
                                  "2 58 1 21 9 2 1    \n" +
                                  "3 58 49 21 9 2 1   \n" +
                                  "4 22 49 21 9 2 1   \n" +
                                  "0 58 39 13 9 2 1   \n" +
                                  "1 36 1 13 9 2 1    \n" +
                                  "2 58 11 13 9 2 1   \n" +
                                  "3 14 11 13 9 2 1   \n" +
                                  "4 14 39 13 9 2 1   \n" +
                                  "0 36 49 13 9 2 1   \n" +
                                  "1 58 21 57 17 2 1  \n" +
                                  "2 14 10 31 11 0 0  \n" +
                                  "3 44 11 29 9 2 1   \n" +
                                  "4 14 38 31 11 0 0  \n" +
                                  "0 44 39 29 9 2 1   \n" +
                                  "G 2 9 17 7 3 0     \n" +
                                  "G 57 9 17 7 2 1    \n" +
                                  "G 57 57 17 7 2 1   \n" +
                                  "G 2 57 17 7 3 0    \n" +
                                  "G 26 17 6 3 3 0    \n" +
                                  "G 24 8 9 6 3 0     \n" +
                                  "G 37 32 19 3 3 0   \n" +
                                  "G 2 19 9 7 3 0     \n" +
                                  "G 57 19 9 7 2 1    \n" +
                                  "G 16 18 4 5 3 0    \n" +
                                  "G 43 18 5 5 2 1    \n" +
                                  "G 2 32 20 4 3 0    \n" +
                                  "G 2 47 9 7 3 0     \n" +
                                  "G 57 47 9 7 2 1    \n" +
                                  "G 16 46 2 5 3 0    \n" +
                                  "G 43 46 3 5 2 1    \n" +
                                  "G 24 45 7 5 2 1    \n" +
                                  "G 24 57 11 6 3 0   \n" +
                                  "H 24 9   \n" +
                                  "H 2 22   \n" +
                                  "H 2 30   \n" +
                                  "H 57 30  \n" +
                                  "H 16 40  \n" +
                                  "H 24 50  \n" +
                                  "H 40 37  \n" +
                                  "H 16 19  \n" +
                                  "H 43 12  \n" +
                                  "H 43 47  \n" +
                                  "V 21 2   \n" +
                                  "V 38 9   \n" +
                                  "V 13 12  \n" +
                                  "V 46 19  \n" +
                                  "V 23 37  \n" +
                                  "V 34 22  \n" +
                                  "V 13 47  \n" +
                                  "V 21 50  \n" +
                                  "V 46 40  \n" +
                                  "V 38 57  \n" +
                                  "L 46 37  \n";
        }

        else if (instance.nivel == 6)
        {

            instance.mapa = "60 60 1                                                    \n" +
                            "A9555555555555555555559955555555599599555555555555555555559C\n" +
                            "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "7155555555555599555555415555G5555555415555559955555555555548\n" +
                            "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF   hhhhh                    EF            EF\n" +
                            "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                            "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "71555555555555415555G555555555555555G55555554155555555555548\n" +
                            "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                            "EFiiiii ggggg           pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp                        EF\n" +
                            "EF                      pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                            "EFddddd fffff                                  ggggg iiiiiEF\n" +
                            "EFddddd ffff                                   ggggg iiiiiEF\n" +
                            "EF                                                        EF\n" +
                            "EF                                                        EF\n" +
                            "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                            "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF     hhhhh                  EF            EF\n" +
                            "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                            "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                            "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                            "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "EF            EF                            EF            EF\n" +
                            "7155555555555541555555995555G5555995555555554155555555555548\n" +
                            "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                            "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                            "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                            "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "EF                    EF            EF                    EF\n" +
                            "715555555555555555555541555555555555415555555555555555555548\n" +
                            "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "48      \n" +
                                  "P 4 23 1           \n" +
                                  "0 0 0 23 11 0 0    \n" +
                                  "1 0 48 23 11 0 0   \n" +
                                  "2 36 48 23 11 0 0  \n" +
                                  "3 36 0 23 11 0 0   \n" +
                                  "4 22 0 15 11 0 0   \n" +
                                  "0 0 10 15 11 0 0   \n" +
                                  "1 44 10 15 11 0 0  \n" +
                                  "2 44 38 15 11 0 0  \n" +
                                  "3 0 38 15 11 0 0   \n" +
                                  "4 22 48 15 11 0 0  \n" +
                                  "0 0 20 59 19 0 0   \n" +
                                  "1 22 1 21 9 2 1    \n" +
                                  "2 58 1 21 9 2 1    \n" +
                                  "3 58 49 21 9 2 1   \n" +
                                  "4 22 49 21 9 2 1   \n" +
                                  "0 58 39 13 9 2 1   \n" +
                                  "1 36 1 13 9 2 1    \n" +
                                  "2 58 11 13 9 2 1   \n" +
                                  "3 14 11 13 9 2 1   \n" +
                                  "4 14 39 13 9 2 1   \n" +
                                  "0 36 49 13 9 2 1   \n" +
                                  "1 58 21 57 17 2 1  \n" +
                                  "2 14 10 31 11 0 0  \n" +
                                  "3 44 11 29 9 2 1   \n" +
                                  "4 14 38 31 11 0 0  \n" +
                                  "0 44 39 29 9 2 1   \n" +
                                  "H 24 9   \n" +
                                  "H 2 22   \n" +
                                  "H 2 30   \n" +
                                  "H 57 30  \n" +
                                  "H 16 40  \n" +
                                  "H 24 50  \n" +
                                  "H 40 37  \n" +
                                  "H 16 19  \n" +
                                  "H 43 12  \n" +
                                  "H 43 47  \n" +
                                  "V 21 2   \n" +
                                  "V 38 9   \n" +
                                  "V 13 12  \n" +
                                  "V 46 19  \n" +
                                  "V 23 37  \n" +
                                  "V 34 22  \n" +
                                  "V 13 47  \n" +
                                  "V 21 50  \n" +
                                  "V 46 40  \n" +
                                  "V 38 57  \n" +
                                  "L 46 37  \n";

            instance.nivel = 0;
        }


#endif
        instance.nivel++;
        instance.InitGame();
    }

    private void HidePresentacion()
    {
        if(instance.nivel == 1)
        {
           presentacion.SetActive(false);
        }
        else
        {
            entremapas.SetActive(false);
        }
        doingSetup = false;
    }

    public void InteractuarEncargado(int inter)
    {
        encargado1.SetActive(true);

        if (inter == 1)
        {
            textoPersonajes.text = "Vigilante: ¡Hola! Lamentablemente nuestro establecimiento está cerrado debido a la pandemia. Solo yo tengo la llave… \n" +
                                   "¡¡Ostras!! Dónde está?? !! \n" +
                                   "Si consigues encontrarla haré ver como si no te he visto entrar...";

        }
        else if (inter == 2)
        {
            textoPersonajes.text = "Recién Graduado EETAC: Vaya primer día trabajando aquí... Uy! Hola, bienvenido a Mercadona! \n" +
                                   "Póngase la mascarilla y los guantes por favor. Ya que ha conseguido entrar, coja lo que necesite. \n" +
                                   "Sobretodo cuidado con los guardas, que no están de humor! Cualquier cosa que necesite no dude en preguntarme!";

        }
        else if (inter == 3)
        {
            textoPersonajes.text = "Mi conciencia: Joder con el señor Mercadona, mucho Hacendado y no hay papel...mi novia me va a matar...  \n" +
                                   "Preguntaré al encargado si tienen más...";
        }
        else if (inter == 4)
        {
            textoPersonajes.text = "Recién Graduado EETAC: El papel de váter? Si no queda en la estantería estará en el almacén. Pero para entrar necesitarás el código de TRES dígitos.  \n" +
                                   "Yo tenía un Post-it con cada dígito, pero ordenando por las estanterías se me debe de haber caído. Búscalos para acceder al almacén.";
        }
        else if (inter == 5)
        {
            textoPersonajes.text = "Mi conciencia: Ostia! Aquí hay un Post-it con un número: 6 ";
        }
        else if (inter == 6)
        {
            textoPersonajes.text = "Mi conciencia: Ostia! Aquí hay un Post-it con un número: 4 ";
        }
        else if (inter == 7)
        {
            textoPersonajes.text = "Mi conciencia: Ostia! Aquí hay un Post-it con un número: 7 ";
        }
        else if (inter == 8)
        {
            textoPersonajes.text = "Mi conciencia: Ahora que ya tengo los códigos voy a buscar el PANEL DE CONTROL. Debería estar al lado de la puerta del almacén...  ";

        }
        else if (inter == 9)
        {
            textoPersonajes.text = " ¡Código Correcto! ";
        }
        else if (inter == 10)
        {
            textoPersonajes.text = " ¡Código Incorrecto! ";
        }
        else if (inter == 11)
        {
            textoPersonajes.text = "Señor Mercadona: EH! ¡¿Tú que haces aquí?! Menudos inútiles he contratado...  \n" +
                                   "Estamos cerrados. ¡Ni se te ocurra coger nada!";
        }
        else if (inter == 12)
        {
            textoPersonajes.text = "Señor Mercadona: NO! El papel no!   \n" +
                                   "Voy a llamar a la policía... \n" +
                                   "... ... ¿Si? La Policía? ¡Aquí hay un chorizo que nos está robando! ¡Envíen refuerzos! ¡Y si hace falta el ejército! \n" +
                                   " Jejejeje TE VAS A CAGAR!";
        }
        else if (inter == 13)
        {
            textoPersonajes.text = "Recién Graduado EETAC: Cuidado! Hay mucha pasma fuera...  \n" +
                                   "Ya me da igual este trabajo! ¡ESTOY HARTO! ¡Te abro la puerta e intenta llegar a casa cagando leches!";
        }
        else if (inter == 14)
        {
            textoPersonajes.text = "Guardia: ¡Oye tú! ¡¿Qué haces aquí?!  \n" +
                                   "Derechito pa'l cuartel que te vas";
        }

        else if (inter == 15)
        {
            textoPersonajes.text = "Recién Graduado EETAC: Vaya, ya tienes el código completo \n" +
                                   "Tampoco puse uno muy difícil jejejeje, incluso sin los Pos-it lo habrías sabido";
        }

        else if (inter == 16)
        {
            textoPersonajes.text = "Mi conciencia: Síi!!!! Ya tengo el papel de vater, acabo de hacer mis sueños realidad!!!!";
        }

        else if (inter == 17)
        {
            textoPersonajes.text = "Mi conciencia: No puedo coger todos los rollos, si no me verán y me detendrán. \n" +
                                   "No hay que ser avariciosos en esta vida";
        }

        else if (inter == 18)
        {
            textoPersonajes.text = "Guardia: Vaya vaya, tu eres el que ha robado el papel eeh!! \n" +
                                   "Te vamos a enseñar como funcionan aquí las cosas";
        }

        else if (inter == 19)
        {
            textoPersonajes.text = "Mi conciencia: Vaya, parece que la puerta está cerrada. \n" +
                                   "Empezamos bien. Tendré que buscar la llave, pero no se por donde";
        }

        else if (inter == 20)
        {
            textoPersonajes.text = "Mi conciencia: Ahora que ya tengo el papel no necesito entrar a este sitio de ....";
        }

        else if (inter == 21)
        {
            textoPersonajes.text = "Mi conciencia: No puedo volver a casa sin el papel, lo conseguiré aunque sea lo último que haga";
        }
    }

    public void AcabarConversa()
    {
        encargado1.SetActive(false);
    }

    public void GameOver()
    {
        presentacionFinal.SetActive(true);
        quit.SetActive(true);
        restart.SetActive(true);
        InicializarObjetos();
    }

    private void InicializarObjetos()
    {
        cantidadDesinfectante = 5;
        cantidadDesinfectantePlus = 5;
        cantidadDesinfectantePro = 5;
        cantidadJabon = 5;
        cantidadMascarilla = 0;
        cantidadMegaMascarilla = 0;
}
    
    public void GanarPartida()
    {
        presentacionFinalText.text = "¡UAU, BIENVENIDO AL HALL DE LA FAMA! ";
        presentacionFinal.SetActive(true);
        quit.SetActive(true);
        restart.SetActive(true);
    }
}
