using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Coche : MovingObject
{
    public int playerDamage;
    public Sprite goizquierda;
    public Sprite goderecha;
    public Sprite goarriba;
    public Sprite goabajo;
    public int hormax = 23;
    public int vermax = 11;

    private SpriteRenderer spriterenderer;
    public int move = 0;
    int horizontal = 0;
    int vertical = 0;
    public int ordenmovimiento;

    //necesto un variable que me guarde la posicion del enemigo y me lo pasa el boardManager


    protected override void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        base.Awake();
    }

    protected override void Start()
    { /*
        GameManager.instance.AddEnemyToList(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;*/
        moveTime = 0.05f;
        InicializarCoche();
        base.Start();
    }

    protected override void AttemptMove(string objectname, int xDir, int yDir)
    {
        base.AttemptMove(objectname, xDir, yDir);

    }

    void Update()
    {
        if (!moving)
        {
            if (move == 0)
            {
                AttemptMove("coche", 1, 0);
                horizontal++;
            }

            else if (move == 1)
            {
                AttemptMove("coche", 0, 1);
                vertical++;
            }
                
            else if (move == 2)
            {
                AttemptMove("coche", -1, 0);
                horizontal--;
            }
                
            else
            {
                AttemptMove("coche", 0, -1);
                vertical--;
            }   
        }

        Comprobarposicion();
    }

    private void InicializarCoche()
    {
        if (move == 0)
            spriterenderer.sprite = goderecha;

        else if (move == 1)
            spriterenderer.sprite = goarriba;

        else if (move == 2)
            spriterenderer.sprite = goizquierda;

        else
            spriterenderer.sprite = goabajo;
    }
    
    private void Comprobarposicion()
    {
        if (ordenmovimiento == 0)
        {
            if (horizontal == hormax)
            {
                move = 1;
                spriterenderer.sprite = goarriba;
                horizontal = 0;
            }

            else if (vertical == vermax)
            {
                move = 2;
                spriterenderer.sprite = goizquierda;
                vertical = 0;
            }

            else if (horizontal == -hormax)
            {
                move = 3;
                spriterenderer.sprite = goabajo;
                horizontal = 0;
            }
            else if (vertical == -vermax)
            {
                move = 0;
                spriterenderer.sprite = goderecha;
                vertical = 0;
            }
        }
        else
        {
            if (horizontal == hormax)
            {
                move = 3;
                spriterenderer.sprite = goabajo;
                horizontal = 0;
            }

            else if (vertical == vermax)
            {
                move = 0;
                spriterenderer.sprite = goderecha;
                vertical = 0;
            }

            else if (horizontal == -hormax)
            {
                move = 1;
                spriterenderer.sprite = goarriba;
                horizontal = 0;
            }
            else if (vertical == -vermax)
            {
                move = 2;
                spriterenderer.sprite = goizquierda;
                vertical = 0;
            }
        }
        
    }
    
    protected override void OnCantMove(GameObject go)
    {
        if (move == 0)
            horizontal--;

        else if (move == 1)
            vertical--;

        else if (move == 2)
            horizontal++;

        else
            vertical++;

        if (go.tag == "Player")
            go.GetComponent<Player>().LoseHealth(go.GetComponent<Player>().health);

    }
}
