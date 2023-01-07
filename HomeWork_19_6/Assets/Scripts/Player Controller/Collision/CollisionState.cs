using Player_Controller.Player_Behaviours;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Player_Controller.Collision
{
    public class CollisionState : MonoBehaviour
    {
        public LayerMask collisionLayer;
        public bool isGrounded;
        public bool isOnWall;
        public Vector2 bottomPosition = Vector2.zero;
        public Vector2 rightPosition = Vector2.zero;
        public Vector2 leftPosition = Vector2.zero;
        public float collisionRadius = 10f;
    
        public Color debugCollisionColor = Color.red;

        private InputState _inputState;
        
        void Awake()
        {
            _inputState = GetComponent<InputState>();
        }

        private void FixedUpdate()
        {
            var position = bottomPosition;
            position.x += transform.position.x;
            position.y += transform.position.y;

            isGrounded = Physics2D.OverlapCircle(position, collisionRadius, collisionLayer);

            position = _inputState.direction == Directions.FaceRight ? rightPosition : leftPosition;
            position.x += transform.position.x;
            position.y += transform.position.y;

            isOnWall = Physics2D.OverlapCircle(position, collisionRadius, collisionLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = debugCollisionColor;

            var positions = new Vector2[] { bottomPosition, rightPosition, leftPosition };

            foreach (var position in positions)
            {
                var pos = position;
                pos.x += transform.position.x;
                pos.y += transform.position.y;
        
                Gizmos.DrawWireSphere(pos, collisionRadius);
            }
        }
    }
}
