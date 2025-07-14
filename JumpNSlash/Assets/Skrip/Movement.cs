using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    public bool isGrounded;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float rangeGround = 0f;
    private bool flip = false;
    private Animator anim;

    private enum State { idle, running, jumping, falling }
    private State state = State.idle;

    private float horizontalInput;

    // Tambahkan variabel untuk input dari tombol UI
    private float mobileInputX = 0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.deltaTime != 0)
        {
            AnimationState();
            anim.SetInteger("state", (int)state);
        }

        // Ambil input dari keyboard
        float keyboardInput = Input.GetAxisRaw("Horizontal");

        // Gabungkan input keyboard + tombol UI
        horizontalInput = keyboardInput + mobileInputX;

        // Batasi nilai horizontalInput agar tidak lebih dari -1 atau 1
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);

        // Gerakkan karakter
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Deteksi apakah sedang menyentuh tanah
        isGrounded = Physics2D.OverlapCircle(transform.position, rangeGround, targetLayer);

        // Lompat dengan tombol Space (keyboard)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }

        // Flip karakter
        if (horizontalInput < 0 && !flip)
        {
            Flip();
            flip = true;
        }
        else if (horizontalInput > 0 && flip)
        {
            Flip();
            flip = false;
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .3f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (isGrounded)
            {
                state = State.idle;
            }
        }
        else if (horizontalInput != 0)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    // ===== Tambahkan fungsi ini untuk digunakan oleh UI Button =====

    public void MoveLeft(bool isPressed)
    {
        if (isPressed)
            mobileInputX = -1f;
        else if (mobileInputX == -1f)
            mobileInputX = 0f;
    }

    public void MoveRight(bool isPressed)
    {
        if (isPressed)
            mobileInputX = 1f;
        else if (mobileInputX == 1f)
            mobileInputX = 0f;
    }

    public void MobileJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
        }
    }
}
