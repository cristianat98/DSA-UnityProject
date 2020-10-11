using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f; //tiempo que dura un movimiento
    public LayerMask blockingLayer; //capa a la que pertenece
    public LayerMask carretera;
    public LayerMask player;
    public LayerMask enemigo;


    private float movementSpeed; //velocidad de movimiento
    private BoxCollider2D boxCollider; //referencia al box collider
    private Rigidbody2D rb2D; //referencia al rigidbody
    protected bool moving = false;

    protected virtual void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        movementSpeed = 0.5f / moveTime;
    }

    protected IEnumerator SmoothMovement(Vector2 end) //corutina para movimiento
    {
        float distanciaRestante = Vector2.Distance(rb2D.position, end);
        while (distanciaRestante > float.Epsilon)
        {
            Vector2 posicionNueva = Vector2.MoveTowards(rb2D.position, end, movementSpeed * Time.deltaTime);
            rb2D.MovePosition(posicionNueva);
            distanciaRestante = Vector2.Distance(rb2D.position, end);
            yield return null;
        }
        moving = false;
    }

 
    protected bool Move(string objectname, int xDir, int yDir, out RaycastHit2D hit) //movimiento
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;
        if (hit.transform == null)
        {
            if(objectname == "player")
            {
                boxCollider.enabled = false;
                hit = Physics2D.Linecast(start, end, carretera);
                boxCollider.enabled = true;

                if (hit.transform == null)
                {
                        moving = true;
                        StartCoroutine(SmoothMovement(end));
                        return true;                    
                }
            
            }

            else if (objectname == "enemigo" || objectname == "coche" || objectname == "guardia")
            {
                boxCollider.enabled = false;
                hit = Physics2D.Linecast(start, end, enemigo);
                boxCollider.enabled = true;

                if (hit.transform == null)
                {
                    boxCollider.enabled = false;
                    hit = Physics2D.Linecast(start, end, player);
                    boxCollider.enabled = true;
                    if (hit.transform == null)
                    {
                        boxCollider.enabled = false;
                        hit = Physics2D.Linecast(start, end, carretera);
                        boxCollider.enabled = true;

                        if (hit.transform == null)
                        {
                            moving = true;
                            StartCoroutine(SmoothMovement(end));
                            return true;
                        }

                    }

                } 
                
                if(hit.transform != null)
                {
                        boxCollider.enabled = false;
                }

                else return false;
            }
            else if (objectname == "coche")
            {
                boxCollider.enabled = false;
                hit = Physics2D.Linecast(start, end, player);
                boxCollider.enabled = true;

                if (hit.transform == null)
                {
                        moving = true;
                        StartCoroutine(SmoothMovement(end));
                        return true;                   
                }
                
            }
            return false;

        }

        else return false;
    }       

    protected abstract void OnCantMove(GameObject go);

    protected virtual void AttemptMove(string objectname, int xDir, int yDir)
    {
        RaycastHit2D hit;
        bool canMove = Move(objectname, xDir, yDir, out hit);

        if (canMove) return;

        OnCantMove(hit.transform.gameObject);
        
    }
}