using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool isJumping = false;
    private bool isGrounded = false;
    private Rigidbody2D rb;

    public bool canMove;
    public GameObject MenuPanel;
    public GameObject ScoreText;
    public GameObject StartingPlatform;
    public GameObject PlatformSpawner;

    public GameObject DeathPanel;

    public AudioSource JumpSound;
    public AudioSource GameOverSound;

    private Transform cameraTransform;
    public float yOffset = 2f;

    bool death;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraTransform = Camera.main.transform;
        Time.timeScale = 1;
    }

    void Update()
    {
        if(canMove == true)
        {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            isGrounded = false;
            JumpSound.Play();
            animator.SetTrigger("jump");
        }

        if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false; // saga donme
        }
        else if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true; // sola dosnme
        }
        }

        float cameraYPosition = cameraTransform.position.y - yOffset;

        if (transform.position.y < cameraYPosition)
        {
            if(death == false)
            Death();
        }
    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void Death()
    {
        GameOverSound.Play();
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
        death = true;
    }

    public void Grounded()
    {
        isGrounded = true;
    }

    public void StartGame()
    {
        canMove = true;
        ScoreText.SetActive(true);
        StartingPlatform.SetActive(true);
        PlatformSpawner.SetActive(true);
        MenuPanel.SetActive(false);   
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}