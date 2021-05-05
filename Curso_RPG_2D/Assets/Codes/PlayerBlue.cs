using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlue : MonoBehaviour
{
    private Vector3 move;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isAttacking = false; 
    private bool isDashing = false;
    private float dashTime;
    private float speedInput;

    public float speed;
    public float dashSpeed;
    public float startDashTime;
    public GameObject camShake;
    public ParticleSystem dust;
    public ParticleSystem dustRun;

    public Ghost ghost;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        //dustRun.Stop();
        speedInput = speed;
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"),
                                    Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.magnitude);

        /* Verifica se esta o player esta andando, atacando ou dash */
        checkPlayerMove();
        checkPlayerAttack();
        checkPlayerDash();
        
        move = move.normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2((move.x)*speed, (move.y)*speed);
    }

    public void checkPlayerMove()
    {
        /* Verifica se esta o player esta andando */
        if(move.x != 0f || move.y != 0f)
        {
            //ghost.makeGhost = true;
            if(!dustRun.isPlaying)
                dustRun.Play();
        }else{
            //ghost.makeGhost = false;
            dustRun.Stop();
        }
    }

    public void checkPlayerAttack()
    {
        /* ATTACK */
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Fire1")){
            isAttacking = true;
            speed = 0;
            Invoke("stopAttack", 0.183f);
            anim.SetTrigger("attack_down");
        }
    }

    public void checkPlayerDash()
    {
        /* DASH */
        if(Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2")){
            //camShake.GetComponent<Animator>().SetTrigger("camShake");
            isDashing = true;
            dust.Play();
            ghost.position = transform.position;
            ghost.rotation = transform.rotation;
            ghost.makeGhost = true;
        }

        if(isDashing)
        {
            if(dashTime <= 0)
            {
                dashTime = startDashTime;
                speed = speedInput;
                isDashing = false;
            }else{
                dashTime -= Time.deltaTime;
                speed = dashSpeed;
                Invoke("disableGhost", 0.5f);
                //ghost.makeFirtsGhost = false;
            }
        }
    }

    public void disableGhost()
    {
        ghost.makeGhost = false;
        ghost.makeFirtsGhost = false;
    }

    public void stopAttack()
    {
        isAttacking = false;
        speed = speedInput;
    }

    
}
