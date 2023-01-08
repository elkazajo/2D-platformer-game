using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class WallJump : AbstractBehaviour
    {
        public Vector2 jumpVelocity = new Vector2(50, 200);
        public bool isJumpingOfWall;
        public float resetDelay = 0.2f;

        private float _timeElapsed = 0;
        
        void Update()
        {
            if (collisionState.isOnWall && !collisionState.isGrounded)
            {
                var canJump = inputState.GetButtonValue(inputButtons[0]);

                if (canJump && !isJumpingOfWall)
                {
                    inputState.direction = inputState.direction == Directions.FaceRight
                        ? Directions.FaceLeft
                        : Directions.FaceRight;
                    rigidbody2D.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);
                    ToggleScripts(false);
                    isJumpingOfWall = true;
                }
            }

            if (isJumpingOfWall)
            {
                _timeElapsed += Time.deltaTime;

                if (_timeElapsed > resetDelay)
                {
                    ToggleScripts(true);
                    isJumpingOfWall = false;
                    _timeElapsed = 0;
                }
            }
        }
    }
}
