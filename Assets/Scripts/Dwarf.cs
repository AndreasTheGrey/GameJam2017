using UnityEngine;
using System.Collections;

public class Dwarf: MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;
    // For determining which way the player is currently facing.
    [HideInInspector]
    private bool jump = false;
    // Condition for whether the player should jump.

    public float moveForce = 365f;
    // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    // The fastest the player can travel in the x axis.

    public float jumpForce = 700f;
    // Amount of force added when the player jumps.


    private Transform groundCheck;
    // A position marking where to check if the player is grounded.
    private bool grounded = false;
    // Whether or not the player is grounded.

    private Animator anim;
    // Reference to the player's animator component.
    public Hammer hammer;

    private bool dead;
    public int healthPoints;
    public string dwarfName;

    private DwarfHealth dh;

    void Awake ()
    {
        // Setting up references.
        groundCheck = transform.Find ("groundCheck");
        anim = GetComponent<Animator> ();
        dh = GetComponent<DwarfHealth>();
    }


    void Update ()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
        
        anim.SetBool("Grounded", grounded);

    }

    public void Jump ()
    {
        if (grounded)
        {
            jump = true;
        }
    }

    public void Move (float horizontal, float vertical)
    {
        if (dh.dead)
        {
            return;
        }
        anim.SetFloat ("Speed", Mathf.Abs (horizontal));

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (horizontal * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D> ().AddForce (Vector2.right * horizontal * moveForce);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (horizontal > 0 && !facingRight)
            // ... flip the player.
            Flip ();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal < 0 && facingRight)
            // ... flip the player.
            Flip ();
    }

    private bool canAttack = true;

    public void Attack ()
    {
        if (dh.dead)
        {
            return;
        }
        if (canAttack)
            anim.SetTrigger("Attack");
            canAttack = false;
    }

    public void DoDamage()
    {
        hammer.DoDamage();
    }

    public void refreshAttack()
    {
        canAttack = true;
    }

    void FixedUpdate ()
    {
        if (dh.dead)
        {
            return;
        }
        if (jump) {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger ("Jump");


            // Add a vertical force to the player.
            GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
    }


    void Flip ()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
