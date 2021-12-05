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
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = CharacterController.isGrounded;

        // ê⁄ínÇµÇƒÇ¢ÇÈÇ©å©ÇÈ
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        var movePower = Mathf.Abs(move.z) + Mathf.Abs(move.x);

        if(movePower >0){ 
            FootStepsSoundManager.PlayFootStepSE();
            }else{ 
            FootStepsSoundManager.StopFootStepSE();
            }


        Animator.SetFloat("MovePower", movePower);

        playerVelocity = move;
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
