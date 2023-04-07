using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private LayerMask groundmask;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D bxcoll;
  

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private float movX = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
        sr = GetComponent<SpriteRenderer>();
        bxcoll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
         movX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);
        
        //while (Player.isTouching(Tilemap))
        //{
            if (isGrounded() && Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        //}

       

        AnimUpdate();

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
    }

    private bool isGrounded()
    {
        float extraHeight = .5f;
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
