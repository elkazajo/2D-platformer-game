using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class Jump : AbstractBehaviour
    {
        public float jumpSpeed = 10f;
        public float jumpDelay = 0.1f;
        public int jumpCount = 2;
        public GameObject doubleJumpEffect;

        protected float lastJumpTime = 0;
        protected int jumpsRemaining = 0;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            var canJump = inputState.GetButtonValue(inputButtons[0]);
            var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

            if (collisionState.isGrounded)
            {
                if (canJump && holdTime < 0.1f)
                {
                    jumpsRemaining = jumpCount - 1;
                    OnJump();
                }
            }
            else
            {
                if (canJump && holdTime < 0.1f && Time.time - lastJumpTime > jumpDelay)
                {
                    if (jumpsRemaining > 0)
                    {
                        OnJump();
                        jumpsRemaining--;
                        var clone = Instantiate(doubleJumpEffect);
                        clone.transform.position = transform.position;
                    }
                }
            }
        }

        protected virtual void OnJump()
        {
            var velocity = rigidbody2D.velocity;
            lastJumpTime = Time.time;
            rigidbody2D.velocity = new Vector2(velocity.x, jumpSpeed);
        }
    }
}
