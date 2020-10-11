using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Guardia : MovingObject
{

    public int hormax;
    public int vermax;
    public int move;
    int horizontal = 0;
    int vertical = 0;
    public int ordenmovimiento;
    private Animator animator;
    bool pillado = false;
    bool pillado2 = false;
    Vector2 start;
    Vector2 end;

    protected override void Start()
    {
        ComprobarEstado();
        base.Start();
    }

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    protected override void AttemptMove(string objectname, int xDir, int yDir)
    {
        base.AttemptMove(objectname, xDir, yDir);
    }

    void Update()
    {
        if (!moving && !pillado2 && !pillado && !GameManager.instance.doingSetup)
        {
            if (move == 0)
            {
                AttemptMove("guardia", 0, -1);
                animator.SetTrigger("frontMove");
                vertical--;
            }

            else if (move == 1)
            {
                AttemptMove("guardia", 0, 1);
                animator.SetTrigger("backMove");
                vertical++;
            }

            else if (move == 2)
            {
                AttemptMove("guardia", -1, 0);
                animator.SetTrigger("leftMove");
                horizontal--;
            }

            else
            {
                AttemptMove("guardia", 1, 0);
                animator.SetTrigger("rightMove");
                horizontal++;
            }
            ComprobarPosicion();
            ComprobarEstado();
            pillar();
        }

        else if (pillado && !pillado2)
        {
            if (move == 0)
            {
                AttemptMove("guardia", 0, -1);
                animator.SetTrigger("frontMove");
            }

            else if (move == 1)
            {
                AttemptMove("guardia", 0, 1);
                animator.SetTrigger("backMove");
            }

            else if (move == 2)
            {
                AttemptMove("guardia", -1, 0);
                animator.SetTrigger("leftMove");
            }

            else
            {
                AttemptMove("guardia", 1, 0);
                animator.SetTrigger("rightMove");
            }
        }
    }

    private void ComprobarEstado()
    {
        if (move == 0)
        {
            animator.SetBool("frontIdle", true);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
        }

        else if (move == 1)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", true);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);

        }
        else if (move == 2)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", true);
            animator.SetBool("rightIdle", false);

        }
        else if (move == 3)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", true);
        }
    }

    private void ComprobarPosicion()
    {
        if (horizontal == hormax)
        {
            if (ordenmovimiento == 0)
                move = 0;
            else
                move = 1;
            horizontal = 0;
        }

        else if (-horizontal == hormax)
        {
            if (ordenmovimiento == 0)
                move = 1;
            else
                move = 0;

            horizontal = 0;
        }

        else if (vertical == vermax){
            if (ordenmovimiento == 0)
                move = 3;
            else
                move = 2;

            vertical = 0;
        }

        else if (-vertical == vermax)
        {
            if (ordenmovimiento == 0)
                move = 2;
            else
                move = 3;

            vertical = 0;
        }
    }

    protected override void OnCantMove(GameObject go)
    {
        pillado2 = true;
        GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(0);
    }

    public void pillar()
    {
        start = transform.position;
        if (move == 0)
            end = start + new Vector2(0, -5);

        else if (move == 1)
            end = start + new Vector2(0, 5);

        else if (move == 2)
            end = start + new Vector2(-5, 0);

        else
            end = start + new Vector2(5, 0);

        RaycastHit2D hit = Physics2D.Linecast(start, end, player);

        if (hit.transform != null)
        {
            Player vistaplayer = hit.transform.gameObject.GetComponent<Player>();
            pillado = true;
            if (move == 0)
                vistaplayer.CambiarIdle(0);
            else if (move == 1)
                vistaplayer.CambiarIdle(1);
            else if (move == 2)
                vistaplayer.CambiarIdle(3);
            else if (move == 3)
                vistaplayer.CambiarIdle(2);

            if (GameManager.instance.nivel != 5)
                GameManager.instance.InteractuarEncargado(14);
            else
                GameManager.instance.InteractuarEncargado(18);
            vistaplayer.animacion = true;
            vistaplayer.cogido = true;
            GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(1);
        }

        else
        {
            end = start + new Vector2(0, 1);
            hit = Physics2D.Linecast(start, end, player);

            if (hit.transform != null)
            {
                move = 1;
                pillado = true;
                Player vistaplayer = hit.transform.gameObject.GetComponent<Player>();
                vistaplayer.CambiarIdle(1);
                vistaplayer.animacion = true;
                vistaplayer.cogido = true;
                GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(1);
            }

            else
            {
                end = start + new Vector2(0, -1);
                hit = Physics2D.Linecast(start, end, player);
                if (hit.transform != null)
                {
                    move = 0;
                    pillado = true;
                    Player vistaplayer = hit.transform.gameObject.GetComponent<Player>();
                    vistaplayer.CambiarIdle(0);
                    vistaplayer.animacion = true;
                    vistaplayer.cogido = true;
                    GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(1);
                }
                else
                {
                    end = start + new Vector2(1, 0);
                    hit = Physics2D.Linecast(start, end, player);
                    if (hit.transform != null)
                    {
                        move = 3;
                        pillado = true;
                        Player vistaplayer = hit.transform.gameObject.GetComponent<Player>();
                        vistaplayer.CambiarIdle(2);
                        vistaplayer.animacion = true;
                        vistaplayer.cogido = true;
                        GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(1);
                    }
                    else
                    {
                        end = start + new Vector2(-1, 0);
                        hit = Physics2D.Linecast(start, end, player);
                        if (hit.transform != null)
                        {
                            move = 2;
                            pillado = true;
                            Player vistaplayer = hit.transform.gameObject.GetComponent<Player>();
                            vistaplayer.CambiarIdle(3);
                            vistaplayer.animacion = true;
                            vistaplayer.cogido = true;
                            GameObject.Find("Jugador(Clone)").GetComponent<Player>().pillado(1);
                        }
                    }
                }
            }
        }    

        if (pillado)
        {
            if (GameManager.instance.nivel != 5)
                GameManager.instance.InteractuarEncargado(14);

            else
                GameManager.instance.InteractuarEncargado(18);
        }
    }
}
