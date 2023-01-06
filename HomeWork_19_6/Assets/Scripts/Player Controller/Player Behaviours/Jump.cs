using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class Jump : AbstractBehaviour
    {
        public float jumpSpeed = 10f;
    
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
                    OnJump();
                }
            }
        }

        protected virtual void OnJump()
        {
            var velocity = rigidbody2D.velocity;
            rigidbody2D.velocity = new Vector2(velocity.x, jumpSpeed);
        }
    }
}
