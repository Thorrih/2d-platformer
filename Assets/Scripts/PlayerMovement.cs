using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 5;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

   private void Awake()
   {

       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
   }
   
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        //snua playerinum thegar hann hreyfir sig
        if(horizontalInput> 0.01f)
        transform.localScale = Vector3.one;

       else if(horizontalInput< -0.01f)
        transform.localScale = new Vector3(-1, 1, 1);

        if(Input.GetKey(KeyCode.Space) && grounded)
        jump();

        anim.SetBool("run",horizontalInput != 0);
        anim.SetBool("grounded",grounded);
    }   //hoppa
           private void jump()
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            grounded = false;
        }

        private void OnCollisionEnter2D (Collision2D collision)
        {
            if(collision.gameObject.tag =="ground");
            grounded = true;
        }
}   
