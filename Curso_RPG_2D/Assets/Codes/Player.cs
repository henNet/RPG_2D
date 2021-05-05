using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerBlue player;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    private Vector3 move;
    private Animator anim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(PlayerBlue)) as PlayerBlue;
    }

    // Update is called once per frame
    void Update()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        anim.SetFloat("Horizontal", directionToPlayer.x);
        anim.SetFloat("Vertical", directionToPlayer.y);
        anim.SetFloat("Speed", directionToPlayer.magnitude);
    }

    void FixedUpdate()
    {
        
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
    }
}
