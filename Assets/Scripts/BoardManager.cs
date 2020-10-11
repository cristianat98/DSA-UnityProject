using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    private Transform boardHolder2;
    private Transform boardHolder3;
    private Transform boardHolder4;
    private Transform boardHolder5;
    private Transform boardHolder6;
    public GameObject[] carretera;
    public GameObject[] mercadona;
    public GameObject[] casacomun;
    public GameObject[] casa1;
    public GameObject[] casa2;
    public GameObject[] casa3;
    public GameObject[] edificio1;
    public GameObject[] edificio2;
    public GameObject[] edificio3;
    public GameObject[] edificio4;
    public GameObject[] edificio5;
    public GameObject[] hospital;
    public GameObject[] tienda;
    public GameObject[] parque;
    public GameObject[] coches;
    public GameObject player;
    public GameObject[] horizontal;
    public GameObject[] vertical;
    public GameObject[] nevera1;
    public GameObject nevera2;
    public GameObject[] cesta;
    public GameObject[] cajaregistradora;
    public GameObject[] estanterias;
    public GameObject sueloMercadona;
    public GameObject guardiaLlave;
    public GameObject guardia;
    public GameObject carro;
    public GameObject invisible;
    public GameObject alarma;
    public GameObject alfombra;
    public GameObject puertaalmacen;
    public GameObject codigo;
    public GameObject propietarioMercadona;
    public GameObject sueloAlmacen;
    public GameObject papel;
    public GameObject conjuntopapel;
    public GameObject[] cajas;
    public int mapa;

    public void SetupScene(string escenario, string personajes)
    {
        string[] lineas = escenario.Split('\n');
        int xtotal = Convert.ToInt32(lineas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(lineas[0].Split(' ')[1]);
        mapa = Convert.ToInt32(lineas[0].Split(' ')[2]);
        string[] jugadores = personajes.Split('\n');
        int ptotal = Convert.ToInt32(jugadores[0]);
        int m = 0;
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int e1 = 0;
        int e2 = 0;
        int e3 = 0;
        int e4 = 0;
        int e5 = 0;
        int h = 0;
        int t = 0;
        int p = 0;
        int n = 0;
        int e = 0;
        int c = 0;
        float xmapa;
        float ymapa;

        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Personajes").transform;
        boardHolder3 = new GameObject("Bordes").transform;

        if (mapa == 1)
        {
            boardHolder4 = new GameObject("Casas").transform;
        }

        else if (mapa == 2)
        {
            boardHolder4 = new GameObject("Caja Registradora").transform;
            boardHolder5 = new GameObject("Estanterías").transform;
            boardHolder6 = new GameObject("Objetos").transform;
        }

        else if (mapa == 3)
        {
            boardHolder4 = new GameObject("Cajas").transform;
        }

        int x;
        int y;

        for (x = -1; x < xtotal + 1; x++)
        {
            GameObject borde = Instantiate(invisible, new Vector3(x, -1f, 0f), Quaternion.identity);
            borde.transform.SetParent(boardHolder3);
        }

        for (x = -1; x < xtotal + 1; x++)
        {
            GameObject borde = Instantiate(invisible, new Vector3(x, ytotal, 0f), Quaternion.identity);
            borde.transform.SetParent(boardHolder3);
        }

        for (y = -1; y< ytotal +1; y++)
        {
            GameObject borde = Instantiate(invisible, new Vector3(-1, y, 0f), Quaternion.identity);
            borde.transform.SetParent(boardHolder3);
        }

        for (y = -1; y < ytotal + 1; y++)
        {
            GameObject borde = Instantiate(invisible, new Vector3(xtotal, y, 0f), Quaternion.identity);
            borde.transform.SetParent(boardHolder3);
        }


        for (y = 0; y < ytotal; y++)
        {
            ymapa = -y + ytotal-1;
            string linea = lineas[y + 1];

            for (x = 0; x < xtotal; x++)
            {
                xmapa = x;
                char ch = linea[x];

                GameObject instance = null;

                switch (ch)
                {
                    case 'M':
                        GameObject extra = null;
                        if (mapa == 1)
                        {
                            extra = Instantiate(mercadona[m], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            m++;

                            if (m == 44)
                                m = 0;
                        }

                        else if (mapa == 2)
                        {
                            extra = Instantiate(cajaregistradora[m], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            m++;

                            if (m == 6)
                                m = 0;
                        }

                        else if (mapa == 3)
                        {
                            instance = Instantiate(sueloAlmacen, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            extra = Instantiate(cajas[c], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            c++;
                            if (c == 14)
                                c = 0;
                        }

                        extra.transform.SetParent(boardHolder4);
                        
                        break;

                    case '0':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            GameObject nevera = Instantiate(nevera1[n], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            n++;
                            if (n == 2)
                                n = 0;

                            nevera.transform.SetParent(boardHolder5);
                        }

                        else if (mapa == 3)
                        {
                            instance = Instantiate(sueloAlmacen, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            GameObject conjuntopapeles = Instantiate(conjuntopapel, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                            conjuntopapeles.transform.SetParent(boardHolder4);
                        }

                        break;

                    case '1':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            GameObject nevera = Instantiate(nevera2, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            nevera.transform.SetParent(boardHolder5);
                        }

                        else if (mapa == 3)
                        {
                            instance = Instantiate(sueloAlmacen, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            GameObject papelvater = Instantiate(papel, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            papelvater.transform.SetParent(boardHolder4);
                        }

                        break;

                    case '2':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            GameObject estanteria = Instantiate(estanterias[e], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            e++;

                            if (e == 20)
                                e = 0;

                            estanteria.transform.SetParent(boardHolder5);
                        }

                        break;

                    case '3':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            GameObject cestaobject = Instantiate(cesta[c], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            c++;
                            if (c == 16)
                                c = 0;

                            cestaobject.transform.SetParent(boardHolder6);
                        }

                        break;

                    case '4':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);


                        else if (mapa == 2)
                        {
                            GameObject carromercadona = Instantiate(carro, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                            carromercadona.transform.SetParent(boardHolder6);
                        }
                        
                        break;

                    case '5':
                        if (mapa == 1)
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            GameObject alarmaobject = Instantiate(alarma, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                            alarmaobject.transform.SetParent(boardHolder6);
                        }
                        break;

                    case '6':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2 || mapa == 3)
                        {
                            instance = Instantiate(alfombra, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        }
                        break;

                    case '7':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            instance = Instantiate(puertaalmacen, new Vector3(xmapa+0.5f, ymapa, 0f), Quaternion.identity);
                        }
                        break;

                    case '8':
                        if (mapa == 1)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                        {
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            GameObject codigoobject = Instantiate(codigo, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                            codigoobject.transform.SetParent(boardHolder6);
                        }
                        break;

                    case '9':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'A':
                        instance = Instantiate(carretera[10], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'B':
                        instance = Instantiate(carretera[11], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'C':
                        instance = Instantiate(carretera[12], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'D':
                        instance = Instantiate(carretera[13], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'E':
                        instance = Instantiate(carretera[14], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'F':
                        instance = Instantiate(carretera[15], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'G':
                        instance = Instantiate(carretera[16], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'H':
                        instance = Instantiate(carretera[17], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'I':
                        instance = Instantiate(carretera[18], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'J':
                        instance = Instantiate(carretera[19], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'Á':
                        GameObject bordecasa = Instantiate(casacomun[4], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa.transform.SetParent(boardHolder4);
                        break;

                    case 'É':
                        GameObject bordecasa2 = Instantiate(casacomun[5], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa2.transform.SetParent(boardHolder4);
                        break;

                    case 'Í':
                        GameObject bordecasa3 = Instantiate(casacomun[6], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa3.transform.SetParent(boardHolder4);
                        break;

                    case 'Ó':
                        GameObject bordecasa4 = Instantiate(casacomun[7], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa4.transform.SetParent(boardHolder4);
                        break;

                    case 'á':
                        GameObject bordecasa5 = Instantiate(casacomun[0], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa5.transform.SetParent(boardHolder4);
                        break;

                    case 'é':
                        GameObject bordecasa6 = Instantiate(casacomun[1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa6.transform.SetParent(boardHolder4);
                        break;

                    case 'í':
                        GameObject bordecasa7 = Instantiate(casacomun[2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa7.transform.SetParent(boardHolder4);
                        break;

                    case 'ó':
                        GameObject bordecasa8 = Instantiate(casacomun[3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa8.transform.SetParent(boardHolder4);
                        break;

                    case 'a':
                        GameObject casa1g = Instantiate(casa1[c1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c1++;
                        if (c1 == 16)
                            c1 = 0;
                        casa1g.transform.SetParent(boardHolder4);
                        break;

                    case 'b':
                        GameObject casa2g = Instantiate(casa2[c2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c2++;

                        if (c2 == 16)
                            c2 = 0;

                        casa2g.transform.SetParent(boardHolder4);
                        break;

                    case 'c':
                        GameObject casa3g = Instantiate(casa3[c3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c3++;
                        casa3g.transform.SetParent(boardHolder4);

                        if (c3 == 16)
                            c3 = 0;

                        break;

                    case 'd':
                        GameObject edificio1g = Instantiate(edificio1[e1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e1++;
                        edificio1g.transform.SetParent(boardHolder4);

                        if (e1 == 20)
                            e1 = 0;

                        break;

                    case 'e':
                        GameObject edificio2g = Instantiate(edificio2[e2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e2++;
                        edificio2g.transform.SetParent(boardHolder4);

                        if (e2 == 12)
                            e2 = 0;

                        break;

                    case 'f':
                        GameObject edificio3g = Instantiate(edificio3[e3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e3++;
                        edificio3g.transform.SetParent(boardHolder4);
                        if (e3 == 18)
                            e3 = 0;
                        break;

                    case 'g':
                        GameObject edificio4g = Instantiate(edificio4[e4], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e4++;
                        edificio4g.transform.SetParent(boardHolder4);

                        if (e4 == 25)
                            e4 = 0;

                        break;

                    case 'h':
                        GameObject hospitalg = Instantiate(hospital[h], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        h++;
                        hospitalg.transform.SetParent(boardHolder4);

                        if (h == 25)
                            h = 0;

                        break;

                    case 'i':
                        GameObject edificio5g = Instantiate(edificio5[e5], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e5++;
                        edificio5g.transform.SetParent(boardHolder4);

                        if (e5 == 25)
                            e5 = 0;

                        break;

                    case 'p':
                        GameObject parqueg = Instantiate(parque[p], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        p++;
                        parqueg.transform.SetParent(boardHolder4);

                        if (p == 80)
                            p = 0;

                        break;

                    case 't':
                        GameObject tiendag = Instantiate(tienda[t], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        t++;
                        tiendag.transform.SetParent(boardHolder4);

                        if (t == 20)
                            t = 0;

                        break;

                    default:
                        if (mapa == 1)
                            instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (mapa == 2)
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        else if (mapa == 3)
                            instance = Instantiate(sueloAlmacen, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;
                }

                if (instance != null)
                    instance.transform.SetParent(boardHolder);
            }
        }

        m = 0;
        h = 0;
          for (int pl = 0; pl < ptotal; pl++)
         {
             char ch = jugadores[pl + 1][0];
             GameObject instance = null;
             switch (ch)
             {
                 case 'P':
                    instance = Instantiate(player, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    Player jugador = instance.GetComponent<Player>();
                    jugador.estado = Convert.ToInt32(jugadores[pl + 1].Split(' ')[3]);

                     break;

                 case '0':
                     instance = Instantiate(coches[0], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol0 = instance.GetComponent<Coche>();
                     cochecontrol0.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol0.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol0.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol0.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '1':
                     instance = Instantiate(coches[1], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol1 = instance.GetComponent<Coche>();
                     cochecontrol1.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol1.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol1.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol1.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '2':
                     instance = Instantiate(coches[2], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol2 = instance.GetComponent<Coche>();
                     cochecontrol2.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol2.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol2.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol2.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '3':
                     instance = Instantiate(coches[3], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol3 = instance.GetComponent<Coche>();
                     cochecontrol3.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol3.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol3.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol3.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '4':
                     instance = Instantiate(coches[4], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol4 = instance.GetComponent<Coche>();
                     cochecontrol4.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol4.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol4.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol4.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case 'V':
                     instance = Instantiate(vertical[m], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    m++;
                    if (m == 10)
                        m = 0;
                    break;

                 case 'H':
                    if (mapa == 1)
                    {
                        instance = Instantiate(horizontal[h], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                        h++;
                        if (h == 10)
                            h = 0;
                    }
                    
                    else if (mapa == 2 || mapa == 3)
                        instance = Instantiate(propietarioMercadona, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     
                    break;

                case 'L':
                    instance = Instantiate(guardiaLlave, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);

                    break;

                case 'G':
                    instance = Instantiate(guardia, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    Guardia scriptguardia = instance.GetComponent<Guardia>();
                    scriptguardia.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                    scriptguardia.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                    scriptguardia.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                    scriptguardia.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                    
                    break;
            }

             if (instance != null)
                 instance.transform.SetParent(boardHolder2);
    
        }
    }
}
        
    