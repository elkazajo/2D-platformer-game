using System;
using Player_Controller.Collision;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public abstract class AbstractBehaviour : MonoBehaviour
    {
        public Buttons[] inputButtons;

        protected InputState inputState;
        protected Rigidbody2D rigidbody2D;
        protected CollisionState collisionState;

        protected virtual void Awake()
        {
            inputState = GetComponent<InputState>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            collisionState = GetComponent<CollisionState>();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
