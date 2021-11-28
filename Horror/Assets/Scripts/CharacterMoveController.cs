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

    public Animator Animator;

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
        
        var movePower = Mathf.Abs(move.z)+Mathf.Abs(move.x);

        Animator.SetFloat("MovePower",movePower);
        
        CharacterController.Move(move * Time.deltaTime * playerSpeed);

        // âΩÇ©ì¸óÕÇ≥ÇÍÇƒÇ¢ÇÍÇŒ
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
