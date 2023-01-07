using UnityEngine;

namespace Effects
{
    public class EffectsDestroyer : MonoBehaviour
    {
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
