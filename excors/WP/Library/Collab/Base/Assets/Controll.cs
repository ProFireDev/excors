using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    //Weapon public and private//

    public Transform firePoint;
    public GameObject bulletPrefab;

    //Animation private//

    private float fireCounter;
    public GameObject deathAnim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }


        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {
                isJumping = false;

            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;

        }


        ////////////////////////////////////////
        //Animation//

        if (moveInput > 0 || moveInput < 0)
        {
            anim.SetBool("isRunning", true);
          
        }
        else
        {

            anim.SetBool("isRunning", false);

        }
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");

        }

      
       


    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag.Equals("Enemy")) {

            //Add here//
            //Put whatever transition or ui to transition
            //before this Instantiate
            Instantiate(deathAnim, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

        }
    
    }
}


