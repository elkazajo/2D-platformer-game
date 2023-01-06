using UnityEngine;

namespace Player_Controller.Collision
{
    public class CollisionState : MonoBehaviour
    {
        public LayerMask collisionLayer;
        public bool isGrounded;
        public Vector2 bottomPosition = Vector2.zero;
        public float collisionRadius = 10f;
    
        public Color debugCollisionColor = Color.red;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void FixedUpdate()
        {
            var position = bottomPosition;
            position.x += transform.position.x;
            position.y += transform.position.y;

            isGrounded = Physics2D.OverlapCircle(position, collisionRadius, collisionLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = debugCollisionColor;
        
            var position = bottomPosition;
            position.x += transform.position.x;
            position.y += transform.position.y;
        
            Gizmos.DrawWireSphere(position, collisionRadius);
        }
    }
}
