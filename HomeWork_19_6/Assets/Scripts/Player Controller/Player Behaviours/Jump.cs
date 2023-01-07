using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class Jump : AbstractBehaviour
    {
        public float jumpSpeed = 10f;
        public float jumpDelay = 0.1f;
        public int jumpCount = 2;
        public GameObject doubleJumpEffect;

        private float _lastJumpTime = 0;
        private int _jumpsRemaining = 0;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            var canJump = inputState.GetButtonValue(inputButtons[0]);
            var holdTime = inputState.GetButtonHoldTime(inputButtons[0]);

            if (collisionState.isGrounded)
            {
                if (canJump && holdTime < 0.1f)
                {
                    _jumpsRemaining = jumpCount - 1;
                    OnJump();
                }
            }
            else
            {
                if (canJump && holdTime < 0.1f && Time.time - _lastJumpTime > jumpDelay)
                {
                    if (_jumpsRemaining > 0)
                    {
                        OnJump();
                        _jumpsRemaining--;
                        var clone = Instantiate(doubleJumpEffect);
                        clone.transform.position = transform.position;
                    }
                }
            }
        }

        private void OnJump()
        {
            var velocity = rigidbody2D.velocity;
            _lastJumpTime = Time.time;
            rigidbody2D.velocity = new Vector2(velocity.x, jumpSpeed);
        }
    }
}
