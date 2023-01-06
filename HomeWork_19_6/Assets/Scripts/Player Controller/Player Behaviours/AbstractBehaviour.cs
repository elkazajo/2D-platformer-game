using System;
using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public abstract class AbstractBehaviour : MonoBehaviour
    {
        public Buttons[] inputButtons;

        protected InputState inputState;
        protected Rigidbody2D rigidbody2D;

        protected virtual void Awake()
        {
            inputState = GetComponent<InputState>();
            rigidbody2D = GetComponent<Rigidbody2D>();
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
