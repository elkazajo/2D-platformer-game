using System;
using System.Collections.Generic;
using Player_Controller.Player_Behaviours;
using UnityEngine;

namespace Player_Controller.Player_Inputs
{
    public class InputState : MonoBehaviour
    {
        public Directions direction = Directions.FaceRight;
        public float absVelocityX;
        public float absVelocityY;
        
        private Dictionary<Buttons, ButtonState> _buttonStates = new Dictionary<Buttons, ButtonState>();
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            absVelocityX = Math.Abs(_rigidbody2D.velocity.x);
            absVelocityY = Math.Abs(_rigidbody2D.velocity.y);
        }

        public void SetButtonValue(Buttons key, bool value)
        {
            if (!_buttonStates.ContainsKey(key))
            {
                _buttonStates.Add(key, new ButtonState());
            }

            var state = _buttonStates[key];

            if (state.ButtonStateValue && !value)
            {
                state.HoldTime = 0;
            }
            else if (state.ButtonStateValue && value) 
            {
                state.HoldTime += Time.deltaTime;
            }
            state.ButtonStateValue = value;
        }

        public bool GetButtonValue(Buttons key)
        {
            if (_buttonStates.ContainsKey(key))
            {
                return _buttonStates[key].ButtonStateValue;
            }

            return false;
        }
        
        public float GetButtonHoldTime(Buttons key)
        {
            if (_buttonStates.ContainsKey(key))
            {
                return _buttonStates[key].HoldTime;
            }

            return 0;
        }
    }
}
