using System;
using Player_Controller.Collision;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public abstract class AbstractBehaviour : MonoBehaviour
    {
        public Buttons[] inputButtons;
        public MonoBehaviour[] disableScripts;

        protected InputState inputState;
        protected Rigidbody2D rigidbody2D;
        protected CollisionState collisionState;

        protected virtual void Awake()
        {
            inputState = GetComponent<InputState>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            collisionState = GetComponent<CollisionState>();
        }

        protected void ToggleScripts(bool value)
        {
            foreach (var script in disableScripts)
            {
                script.enabled = value;
            }
        }
    }
}
