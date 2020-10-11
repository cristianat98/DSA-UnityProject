using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVertical : MovingObject
{
    public int playerDamage;

    private Animator animator;

    int move = 1;

    //necesto un variable que me guarde la posicion del enemigo y me lo pasa el boardManager


    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    protected override void Start()
    { /*
        GameManager.instance.AddEnemyToList(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;*/
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
                AttemptMove("enemigo", 0, 1);
            }
            else
            {
                AttemptMove("enemigo", 0, -1);
            }
        }   
    }

    protected override void OnCantMove(GameObject go)
    {

        Player hitPlayer = go.GetComponent<Player>();
        //EnemigoHorizontal eh = go.GetComponent<EnemigoHorizontal>();
        

        if (hitPlayer != null)
        {
            hitPlayer.LoseHealth(playerDamage);
        }

        /*if(eh != null)
        {
            AttemptMove("enemigo", 0, -1);
        }*/
       
        if (transform.position.y < go.transform.position.y)
        {
            animator.SetBool("TopeArriba", true);
            animator.SetBool("TopeAbajo", false);
            move = 1;

        } 
        else if(transform.position.y > go.transform.position.y)
        {
            animator.SetBool("TopeArriba", false);
            animator.SetBool("TopeAbajo", true);
            move = 0;
        }
        
    }

}
