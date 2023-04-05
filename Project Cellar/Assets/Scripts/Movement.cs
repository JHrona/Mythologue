using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    //private Vector2 moveDir;
    private const float MOVE_SPEED = 8f;
    private Animator animator;
    private bool isDashButtonDown;

   // private enum Facing {UP, DOWN, LEFT, RIGHT};
   // private Facing FacingDir = Facing.DOWN;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        float moveX = 0f;
        float moveY = 0f;
        if  (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        if  (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if  (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if  (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
        Anim();

       // TakeInput();
       // Move();

     /*   if(Input.GetKeyDown(KeyCode.Space))
        {
          isDashButtonDown = true;    
        }
        */
    }

private void Anim()
{
 //   moveDir = new Vector3(moveDir.x, moveDir.y).normalized;

    if (moveDir.x != 0 || moveDir.y != 0)
    {
        animator.SetBool("isWalking", true);
        SetAnimatorMovement(moveDir);
    }
    else
    {
        animator.SetBool("isWalking", false);
        animator.SetLayerWeight(1, 0);
    }
}

    /*private void TakeInput()
    {
       moveDir = Vector2.zero;

       if(Input.GetKey(KeyCode.W))
       {
         moveDir += Vector2.up;
         FacingDir = Facing.UP;
        }
       if(Input.GetKey(KeyCode.A))
       {
         moveDir += Vector2.left;
         FacingDir = Facing.LEFT;
        }
       if(Input.GetKey(KeyCode.S))
       {
         moveDir += Vector2.down;
         FacingDir = Facing.DOWN;
        }
       if(Input.GetKey(KeyCode.D))
       {
         moveDir += Vector2.right;
         FacingDir = Facing.RIGHT;
        }
    } 
    */

    /*private void Move()
    {
      //  transform.Translate(moveDir * MOVE_SPEED * Time.deltaTime);
      //  moveDir = new Vector3(moveDir.x, moveDir.y).normalized;
       //rb.velocity = new Vector2(direction.x, direction.y);

        if (moveDir.x != 0 || moveDir.y != 0)
        {
          SetAnimatorMovement(moveDir);
        }
        else
      {
          animator.SetLayerWeight(1, 0);
      }
    }
    */

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDir * MOVE_SPEED; 
       /* if (isDashButtonDown)
        {
          float dashAmount = 20f;
          rigidbody2D.MovePosition(transform.position + moveDir * dashAmount);
          isDashButtonDown = false;
          
        }
        */
    }

      // float na animace
  private void SetAnimatorMovement(Vector3 direction)
  {
    animator.SetLayerWeight(1, 1);
    animator.SetFloat("xDir", moveDir.x);
    animator.SetFloat("yDir", moveDir.y);
  }
}
