using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    [SerializeField] private LayerMask groundmask;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D capcoll;
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
        capcoll = GetComponent<BoxCollider2D>();



    }


    // Update is called once per frame
    private void FixedUpdate()
    {

        Movement();
        //rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);

        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }




        //AllignSprites();
        AnimUpdate();

    }

    private void Movement()
    {
        movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(movX, movY);
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }



    //private void MovementLogic()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");

    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //    rb.AddForce(movement * moveSpeed);
    //}
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

        //if (visionOn == true)
        //{
        //    anim.SetBool("eyes", true);
        //}
        //else if(visionOn == false)
        //{
        //    anim.SetBool("eyes", false);
        //}

    }


    private bool isGrounded()
    {
        float extraHeight = 50f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capcoll.bounds.min, Vector2.down, capcoll.bounds.extents.y + extraHeight, groundmask);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(capcoll.bounds.center, Vector2.down * (capcoll.bounds.extents.y));
        return raycastHit.collider != null;
    }
}
