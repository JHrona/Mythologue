using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement1 : MonoBehaviour
{
    private enum State {
        Normal,
        Rolling,
    }
    private new Rigidbody2D rigidbody2D;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private Vector3 rollDir;
    //private Vector2 dashDir; // nová proměnná pro směr dáshování
    private const float SPEED = 8f;
    private float rollSpeed;
    private Animator animator;
    private bool isDashButtonDown;
    private State state;
    private float lastDashTime; // čas posledního Dashu
    private const float DASH_COOLDOWN = 2f; // cooldown pro Dash v sekundách
   public Slider dashSlider;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = State.Normal;
    }

    private void Update()
    {
        switch (state){
            case State.Normal:
         
        HandleMovement();
        break;
        case State.Rolling:
        float rollSpeedDropMultiplier = 5f;
        rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;

        float rollSpeedMinimum = 8f;
        if(rollSpeed < rollSpeedMinimum)
        {
            state = State.Normal;
        }
        break;
    }
    dashSlider.value = Mathf.Clamp01((Time.time - lastDashTime) / DASH_COOLDOWN);
    }

    

    private void HandleMovement()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
        }

        // použití instance proměnné moveDir
        moveDir = new Vector3(moveX, moveY).normalized;
        if (moveX != 0 || moveY != 0)
        {
            lastMoveDir = moveDir;
        }

        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetFloat("horizontalMovement", moveDir.x);
            animator.SetFloat("verticalMovement", moveDir.y);
            animator.SetBool("isMoving", true);
        }

        // přidáno - detekce klávesy pro Dash a výpočet směru dáshování

        if (Time.time >= lastDashTime + DASH_COOLDOWN)
        {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isDashButtonDown = true;
            lastDashTime = Time.time;
        }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollDir = lastMoveDir;
            rollSpeed = 50f;
            state = State.Rolling;
        }

    }

    private void FixedUpdate()
    {
        switch(state){
        case State.Normal:
        rigidbody2D.velocity = moveDir * SPEED;
        // použití proměnné dashDir místo moveDir, pokud byla detekována klávesa pro Dash
        if (isDashButtonDown)
        {
            float dashAmount = 5f;
            rigidbody2D.MovePosition(transform.position + lastMoveDir * dashAmount);
            isDashButtonDown = false;
        }
        break;
        case State.Rolling:
        rigidbody2D.velocity = rollDir * rollSpeed;
        break;
    }
    }
}
