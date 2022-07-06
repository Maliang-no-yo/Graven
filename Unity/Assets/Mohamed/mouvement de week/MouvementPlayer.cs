using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlayer : MonoBehaviour
{
    
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 mouvement;
    
    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", mouvement.x);
        animator.SetFloat("Vertical", mouvement.y);
        animator.SetFloat("Speed", mouvement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + mouvement * moveSpeed * Time.fixedDeltaTime);
    }
}
