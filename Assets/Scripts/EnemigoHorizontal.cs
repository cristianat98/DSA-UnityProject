using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHorizontal : MovingObject
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
                AttemptMove("enemigo", 1, 0);
            }
            else
            {
                AttemptMove("enemigo", -1, 0);
            }
        }
    }

    protected override void OnCantMove(GameObject go)
    {

        Player hitPlayer = go.GetComponent<Player>();

        if (hitPlayer != null)
            hitPlayer.LoseHealth(playerDamage);



        if (transform.position.x < go.transform.position.x)
        {
            animator.SetBool("TopeRight", true);
            animator.SetBool("TopeLeft", false);
            move = 1;

        }

        else if (transform.position.x > go.transform.position.x)
        {
            animator.SetBool("TopeRight", false);
            animator.SetBool("TopeLeft", true);
            move = 0;
        }

    }
}
