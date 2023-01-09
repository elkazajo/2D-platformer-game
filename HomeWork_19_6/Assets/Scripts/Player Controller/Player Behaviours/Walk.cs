using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class Walk : AbstractBehaviour
    {
        public float speed = 3f;
        public float runMultiplier = 2f;
        public bool isRunning;

        void Update()
        {
            isRunning = false;
        
            var right = inputState.GetButtonValue(inputButtons[0]);
            var left = inputState.GetButtonValue(inputButtons[1]);
            var run = inputState.GetButtonValue(inputButtons[2]);

            if (right || left)
            {
                var tempSpeed = speed;

                if (run && runMultiplier > 0)
                {
                    tempSpeed *= runMultiplier;
                    isRunning = true;
                }
            
                var velocityX = tempSpeed * (float)inputState.direction;

                rigidbody2D.velocity = new Vector2(velocityX, rigidbody2D.velocity.y);
            }
        }
    }
}
