using UnityEngine;

namespace Player_Controller.Player_Inputs
{
    public class InputManager : MonoBehaviour
    {
        public InputAxisState[] inputs;
        public InputState inputState;

        void Update()
        {
            foreach (var input in inputs)
            {
                inputState.SetButtonValue(input.button, input.InputStateValue);
            }
        }
    }
}
