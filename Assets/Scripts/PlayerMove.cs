using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundmask;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private CapsuleCollider2D bxcoll;
    public GameObject AltPlayer;
    public GameObject Player;
    public GameObject eyes;
    public bool visionOn;


    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private float movX = 0;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bxcoll = GetComponent<CapsuleCollider2D>();



    }


    // Update is called once per frame
    private void FixedUpdate()
    {


        movement();
        
        //AllignSprites();
       

    }
    private void Update()
    {
        AnimUpdate();
        jumping();
    }

    private void movement()
    {
        movX = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(movX, 0.0f);
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
        Debug.Log(movX);

        //movX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);
    }
    private void jumping()
    {
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void AnimUpdate()
    {
        if (movX > 0f)
        {
            sr.flipX = false;
            anim.SetBool("running", true);
        }
        else if (movX < 0f)
        {
            sr.flipX = true;
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

        if (rb.velocity.y != 0)
        {
            anim.SetFloat("jumping", rb.velocity.y);
        }
        else
        {
            anim.SetFloat("jumping", 0);
        }
        

        
    }

    private bool isGrounded()
    {
        float extraHeight = 0.6f;
        RaycastHit2D raycastHit = Physics2D.Raycast(bxcoll.bounds.center, Vector2.down, bxcoll.bounds.extents.y + extraHeight, groundmask);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(bxcoll.bounds.center, Vector2.down * (bxcoll.bounds.extents.y));
        return raycastHit.collider != null;
    }
}