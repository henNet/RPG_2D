using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Vector3 move;
    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Coleta entradas do setas/analogicos-controle */
        move = new Vector3(Input.GetAxis("Horizontal"),
                            Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.magnitude);
        move = move.normalized; /* para a diagonal não ficar rápida */

        /* Player esta em movimento */
        if(move.x != 0 || move.y != 0)
        {
            anim.SetLayerWeight(1, 1); //Layer do Player Andando
        }else{/* Player esta parado */
            anim.SetLayerWeight(1, 0); //Layer do Player Parado
        }
    }

    void FixedUpdate()
    {
        rb.velocity = move * speed;
    }
}
