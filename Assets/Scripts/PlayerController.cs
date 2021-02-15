using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 10.0f;
    private static PlayerController sharedInstance;

    public Vector3 initializePosition;
    public Vector2 initializeVelocity;

    private void Awake() {
        sharedInstance = this;
        initializePosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        initializeVelocity = rb.velocity;
        animator.SetBool("isAlive", true);
    }

    public static PlayerController GetInstance(){
        return sharedInstance;
    }
    public void StartGame()
    {
        animator.SetBool("isAlive", true);
        rb.velocity = initializeVelocity;
        transform.position = initializePosition;
    }

    private void FixedUpdate() {
        if (GameManager.GetInstance().currentGameState == GameManager.GameState.InGame)
        {            
            if(rb.velocity.x < runSpeed){
                rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool IsOnTheGround = IsGrounded();

        animator.SetBool("isGrounded", IsOnTheGround);

        bool isInGame = GameManager.GetInstance().currentGameState == GameManager.GameState.InGame;

        if (isInGame && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            if(IsOnTheGround){
                Jump();
            }
        }
    }

    void Jump(){
        rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }

    bool IsGrounded(){
        return  Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayerMask.value);
    }

    public void KillPlayer(){
        animator.SetBool("isAlive", false);
        GameManager.GetInstance().GameOver();
    }
}
