using System;
using UnityEngine;

namespace Player_Controller.Player_Inputs
{
    public class InputManager : MonoBehaviour
    {
        public InputAxisState[] inputs;
        private InputState _inputState;

        private void Awake()
        {
            _inputState = GetComponent<InputState>();
        }

        void Update()
        {
            foreach (var input in inputs)
            {
                _inputState.SetButtonValue(input.button, input.InputStateValue);
            }
        }
    }
}
