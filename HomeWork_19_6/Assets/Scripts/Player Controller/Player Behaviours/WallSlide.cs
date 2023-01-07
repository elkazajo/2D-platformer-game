using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class WallSlide : StickToWall
    {
        public float slideVelocity = -5f;
        public float slideMultiplier = 5f;
        public float dustSpawnDelay = 0.5f;
        
        public GameObject slideDust;

        private float _timeElapsed = 0;
        
        protected override void Update()
        {
            base.Update();

            if (onWallDetected && !collisionState.isGrounded)
            {
                var velocityY = slideVelocity;

                if (inputState.GetButtonValue(inputButtons[0]))
                {
                    velocityY *= slideMultiplier;
                }

                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, velocityY);
                
                if (_timeElapsed > dustSpawnDelay)
                {
                    var dust = Instantiate(slideDust);
                    var position = transform.position;
                    position.y += 0.2f;
                    dust.transform.position = position;
                    dust.transform.localScale = transform.localScale;
                    _timeElapsed = 0;
                }

                _timeElapsed += Time.deltaTime;
            }
        }

        protected override void OnStick()
        {
            rigidbody2D.velocity = Vector2.zero;
        }

        protected override void OffWall()
        {
            _timeElapsed = 0;
        }
    }
}
