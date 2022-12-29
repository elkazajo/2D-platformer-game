using UnityEngine;

namespace Player_Controller.Player_Inputs
{
    [System.Serializable]
    public class InputAxisState
    {
        public string axisName;
        public float offValue;
        public Buttons button;
        public Condition condition;

        public bool Value
        {
            get
            {
                var axisValue = Input.GetAxis(axisName);

                return condition switch
                {
                    Condition.GreaterThan => axisValue > offValue,
                    Condition.LessThan => axisValue < offValue,
                    _ => false
                };
            }
        }
    }
}