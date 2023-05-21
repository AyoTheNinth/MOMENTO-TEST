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

    private float movX = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bxcoll = GetComponent<CapsuleCollider2D>();



    }


    // Update is called once per frame
    private void Update()
    {


        movement();
        jumping();
        //AllignSprites();
        AnimUpdate();

    }

    private void movement()
    {
        //float movX = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(movX, 0.0f, moveVertical);

        //transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);


        movX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);
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
            anim.SetBool("running", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }

        anim.SetFloat("jumping", rb.velocity.y);

        
    }

    private bool isGrounded()
    {
        float extraHeight = 1f;
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