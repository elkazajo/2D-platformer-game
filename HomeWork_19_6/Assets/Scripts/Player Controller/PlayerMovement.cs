using Player_Controller.Player_Inputs;
using UnityEngine;

namespace Player_Controller
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        public Buttons[] input;
    
        private Rigidbody2D _rb2d;
        private InputState _inputState;
    
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _inputState = GetComponent<InputState>();
        }

        void Update()
        {
            var right = _inputState.GetButtonValue(input[0]);
            var left = _inputState.GetButtonValue(input[1]);
            var velocityX = speed;

            if (right || left)
            {
                velocityX *= left ? -1 : 1;
            }
            else
            {
                velocityX = 0;
            }

            _rb2d.velocity = new Vector2(velocityX, _rb2d.velocity.y);
        }
    }
}
