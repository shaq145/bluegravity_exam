using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Rigidbody2D rgbd2d;

    [SerializeField]
    private Animator animator;

    Vector2 movement;
    Vector2 lastMove;
    bool playerMoving;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw ( "Horizontal" );
        movement.y = Input.GetAxisRaw ( "Vertical" );

        if ( movement.sqrMagnitude != 0 ) {
            playerMoving = true;
            lastMove = new Vector2 ( movement.x, movement.y );
        } else {
            playerMoving = false;
        }

        animator.SetFloat ( "MoveX", movement.x );
        animator.SetFloat ( "MoveY", movement.y );
        animator.SetFloat ( "LastMoveX", lastMove.x );
        animator.SetFloat ( "LastMoveY", lastMove.y );
        animator.SetBool ( "PlayerMoving", playerMoving );
    }

    private void FixedUpdate () {
        rgbd2d.MovePosition ( rgbd2d.position + movement * moveSpeed * Time.fixedDeltaTime );
    }
}
