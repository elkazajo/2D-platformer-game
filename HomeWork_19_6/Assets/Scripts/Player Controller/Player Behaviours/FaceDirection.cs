using UnityEngine;

namespace Player_Controller.Player_Behaviours
{
    public class FaceDirection : AbstractBehaviour
    {
        void Update()
        {
            var right = inputState.GetButtonValue(inputButtons[0]);
            var left = inputState.GetButtonValue(inputButtons[1]);

            if (right)
            {
                inputState.direction = Directions.FaceRight;
            }
            else if(left)
            {
                inputState.direction = Directions.FaceLeft;
            }

            transform.localScale = new Vector3((float)inputState.direction, 1,1);
        }
    }
}
