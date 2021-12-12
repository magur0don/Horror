using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{
    public CharacterController CharacterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    public float playerSpeed = 2.0f;
    public float jumpPower = 1.0f;
    public float glavityValue = -9.81f;
    public Animator Animator;


    public Vector3 oldVelocity;

    public FootStepsSoundManager FootStepsSoundManager;

    public Camera mainCamera;

    public float MaxStamina = 6.0f;

    public float NowStamina = 6.0f;

    public bool Tired = false;

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = CharacterController.isGrounded;

        // ê⁄ínÇµÇƒÇ¢ÇÈÇ©å©ÇÈ
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }


        if (NowStamina <= 0 && !Tired)
        {
            Tired = true;
            Animator.SetBool("Tired", true);
        }

        if (Tired)
        {
            NowStamina += Time.deltaTime / 2;
            if (NowStamina > MaxStamina)
            {
                Tired =false;
                NowStamina = MaxStamina;
                Animator.SetBool("Tired",false);
            }
            return;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.X))
        {
            playerSpeed = 3.5f;
            NowStamina -= Time.deltaTime;
        }
        else
        {
            playerSpeed = 2.0f;
            if(NowStamina < MaxStamina){ 
                NowStamina += Time.deltaTime;
            }
            
        }


        if (move.magnitude > 0)
        {
            FootStepsSoundManager.PlayFootStepSE();
        }
        else
        {
            FootStepsSoundManager.StopFootStepSE();
        }


        Animator.SetFloat("MovePower", move.magnitude * playerSpeed);

        playerVelocity = move;


        var horizontalRotation = Quaternion.AngleAxis(mainCamera.transform.eulerAngles.y, Vector3.up);

        playerVelocity = horizontalRotation * move;

        playerVelocity = Vector3.Slerp(oldVelocity, playerVelocity, playerSpeed * Time.deltaTime);

        oldVelocity = playerVelocity;

        // âΩÇ©ì¸óÕÇ≥ÇÍÇƒÇ¢ÇÍÇŒ
        if (playerVelocity.magnitude > 0f)
        {
            transform.LookAt(transform.position + playerVelocity);
        }
        playerVelocity.y += glavityValue + Time.deltaTime;
        CharacterController.Move(playerVelocity * Time.deltaTime * playerSpeed);
    }
}
