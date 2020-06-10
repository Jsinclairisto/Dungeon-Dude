using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]private float _jumpForce;
    public GameObject deathEffect;
    public Rigidbody2D rb;
    public Animator animator, camAnim;
    public float shakeAmount;
    public AudioManager jumpSound;
    private BoxCollider2D boxCollider;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround, facingRight, isPaused;

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
        if(isTouchingGround)
        {
            animator.SetBool("isJumping", false);
            
        }else
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("DeathCollide")) 
        {
            Destroy(this.gameObject);
            camAnim.SetBool("isDie", true);
            FindObjectOfType<AudioManager>().Play("hurt");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Debug.Log("Collided"); 
        }
    }
}
