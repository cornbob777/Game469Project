using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add RigidBody and Charachter controller component to player
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _playerSpeed;
    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    private float _yVelocity;
    CharacterController _controller;

    Animator animator;
    SpriteRenderer spriteRenderer;
    

    void Start()
    {
        _controller = GetComponent<CharacterController>();
         animator = gameObject.GetComponent<Animator>();
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate()
    {

        
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, 0, 0);

        Vector3 velocity = direction * _playerSpeed;

        _controller.Move(velocity * Time.unscaledDeltaTime);

        transform.Translate(direction * _playerSpeed * Time.unscaledDeltaTime, Space.World);

   
    spriteRenderer.flipX = Input.GetKeyDown(KeyCode.A);


       if(direction != Vector3.zero)
        {
            transform.right = direction;
            animator.SetBool("Run", true);
            
        }
        else
        {
            animator.SetBool("Run", false);
        }

        
        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.unscaledDeltaTime);
        if (_controller.isGrounded == false)
        {
           _yVelocity -= _gravity;
        }
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                 _yVelocity = _jumpHeight;
            }

           
        }
         
    }
}
