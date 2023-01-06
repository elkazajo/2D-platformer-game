using UnityEngine;

namespace Effects
{
    public class DoubleJumpEffect : MonoBehaviour
    {
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
