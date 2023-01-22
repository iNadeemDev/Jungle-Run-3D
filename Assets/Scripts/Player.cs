using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    public Rigidbody rb;
    CharacterController characterController;

    private Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.GetInstance().addScore(1);
        ScoreBoard.GetInstance().updateScoreUI();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moving_direction = new Vector3(horizontal, 0f, vertical);

        if(horizontal != 0f || vertical != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        if(horizontal==0 && vertical==0 && animator.GetBool("isRunning")){
            animator.SetBool("isRunning", false);
        }

        moving_direction.y += Physics.gravity.y * 10;

        moving_direction = transform.TransformDirection(moving_direction);

        characterController.Move(moving_direction * speed * Time.deltaTime);

        // Player left anim
        if(horizontal < 0f)
        {
            animator.SetBool("isLeft", true);
            animator.SetBool("isRight", false);

        }
        else
        {
            animator.SetBool("isLeft", false);
        }
        // Player Right anim
        if (horizontal > 0f)
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
        }
        else
        {
            animator.SetBool("isRight", false);
        }

        // Player Jump
        if (Input.GetButtonDown("Jump"))
        {
            moving_direction.y -= Physics.gravity.y * 10;
            moving_direction.y = jump;
            animator.SetBool("isJump", true);
        }
        else if(!animator.GetBool("isJump") && (horizontal != 0 || vertical != 0))
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isRunning", false);
        }
    }
}