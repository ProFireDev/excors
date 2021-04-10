using System.Collections; // imports objects such as bite arRAYS ETC
using System.Collections.Generic; // adds improvments to objecta to make them more efficient
using UnityEngine; // tells VS code what libray we aer using.

public class playerController : MonoBehaviour // class is same name as script, MonoBehaviour tells  the editor what to do.
{

    Animator animator; //nameing of classes for anemation.
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded; // sets the name of the bool (this one checks to see if its grounded or not)

    [SerializeField]
    Transform groundCheck; // checks to see if you can jump, based on a true or false value defigned by the ground and other objects in the level


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // get component from the API
        rb2d = GetComponent<Rigidbody2D>(); // Rigidbody2D is the name of the 2d player object, this is how you refrince the cherictor in the game. (only for 2D games)
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame (60FPS locked) || game tends to run at 87 FPS in the editor @4k downscaled to 1080P
    private void FixedUpdate() //update function, happens 60 times a seconds
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))// checking if grounded or not if grounded = 1 (true) you can jump if 0 you cant jump.
        {
            isGrounded = true;

        }
        else        // true / false values
        {
            isGrounded = false;

        }


        if (Input.GetKey("d") || Input.GetKey("right")) // this part of the script is what moves the character right on the 2D access
        {
            rb2d.velocity = new Vector2(5, rb2d.velocity.y); // vector is a linear access that tells the script whitch way you ant to move
            animator.Play("player-run"); // refrinces the name of the anamation by name to start it (close to get element by ID)
            spriteRenderer.flipX = false; // if you want to invert the animation to go the other way this = true

        }
        else if (Input.GetKey("a") || Input.GetKey("left")) //this part of the script is what moves the character left on the 2D access
        {
            rb2d.velocity = new Vector2(-5, rb2d.velocity.y); // basicly does everything the same as the first part of the script. (and inverts is to go the other direction)
            animator.Play("player-run"); // calls the annamation by name (ID)
            spriteRenderer.flipX = true; // is true so it inverts the anamation to go the  other direction.

            // note: a good function name is inverse
        }
        else 
        {

            animator.Play("player-idle"); //if there is no action on the keyboard it will play this animation (grabs the animation by its name)
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); // refrices the liner directiion needed to move.


        }

        if (Input.GetKey("w") || Input.GetKey("up") && isGrounded == true) { // this is the jump part of the script checks to see if you are grounded, if yes then you can jump (refrinces the is grounded game object)

            rb2d.velocity = new Vector2(rb2d.velocity.x, 6); //  refrinces the right vector and the the get riged body function
            animator.Play("player-jump");// gets trhe name of the annamation (simmaler to get element by ID.)
        // velocity is motion, the number at the send sets speed.
        }

        // VS should have spell check someone invent that pls

        // tryed to comment this so anyone can understand it let me know if i did a good job or not.
    }
}
