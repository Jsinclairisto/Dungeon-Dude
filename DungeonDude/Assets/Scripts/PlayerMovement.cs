using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]private float _jumpForce;
    public GameObject deathEffect;
    public CameraMove camPan;
    public Rigidbody2D rb;
    public Animator animator, camAnim;
    public float shakeAmount;
    public AudioManager jumpSound;
    private BoxCollider2D boxCollider;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    
    public bool isTouchingGround, facingRight, isPaused, isTouchDeath = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        jumpSound = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle (groundCheckPoint.position, groundCheckRadius, groundLayer);
        JumpAnim(isTouchingGround);
        float horizontalMove = Input.GetAxis("Horizontal");
        animator.SetFloat ("Speed", Mathf.Abs(horizontalMove));
        transform.Translate((horizontalMove * _speed) * Time.deltaTime, 0f, 0f);
        Flip(horizontalMove);

        if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            jumpSound.Play("jump");
        }
    }

    private void JumpAnim(bool isTouchingGround)
    {
        //if touching ground, set bool in jump animator to false
        if(isTouchingGround)
        {
            animator.SetBool("isJumping", false);
            
        }else
            //otherwise, set it to true.
        {   
            animator.SetBool ("isJumping", true);
            
            
        }
    }
    private void Flip(float horizontalMove)
    {
        if(horizontalMove > 0 && facingRight || horizontalMove < 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    IEnumerator dieCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        Destroy(this.gameObject);
        //GetComponent(SpriteRenderer).enabled = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("DeathCollide")) 
        {
            //StartCoroutine(dieCoroutine());
            //isTouchDeath = false;
            camPan.isAlive = false;
            Debug.Log("Collided");
            camAnim.SetBool("isDie", true);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("hurt");
            StartCoroutine(dieCoroutine());
            
            
            
        }
    }
    
}
