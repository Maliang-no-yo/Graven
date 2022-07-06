using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermouvement : MonoBehaviour
{
    public MouvementJoystick mouvementJoystick;
    public float playerSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 mouvement;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        animator.SetFloat("Horizontal", mouvementJoystick.joystickVec.x);
        animator.SetFloat("Vertical", mouvementJoystick.joystickVec.y);
        animator.SetFloat("Speed", mouvementJoystick.joystickVec.sqrMagnitude);

    }

    void FixedUpdate()
    {
        if(mouvementJoystick.joystickVec.y != 0)
        {
            rb.velocity = new Vector2(mouvementJoystick.joystickVec.x * playerSpeed, mouvementJoystick.joystickVec.y * playerSpeed);
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
       
}