namespace Player_Controller.Player_Behaviours
{
    public class StickToWall : AbstractBehaviour
    {
        public bool onWallDetected;

        protected float defaultGravityScale;
        protected float defaultDrag;

        void Start()
        {
            defaultGravityScale = rigidbody2D.gravityScale;
            defaultDrag = rigidbody2D.drag;
        }

        protected virtual void Update()
        {
            if (collisionState.isOnWall)
            {
                if (!onWallDetected)
                {
                    OnStick();
                    ToggleScripts(false);
                    onWallDetected = true;
                }
            }
            else
            {
                if (onWallDetected)
                {
                    OffWall();
                    ToggleScripts(true);
                    onWallDetected = false;
                }
            }
        }

        protected virtual void OnStick()
        {
            if (!collisionState.isGrounded && rigidbody2D.velocity.y > 0)
            {
                rigidbody2D.gravityScale = 0;
                rigidbody2D.drag = 100;
            }
        }

        protected virtual void OffWall()
        {
            if (rigidbody2D.gravityScale != defaultGravityScale)
            {
                rigidbody2D.gravityScale = defaultGravityScale;
                rigidbody2D.drag = defaultDrag;
            }
        }
    }
}
