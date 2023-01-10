using UnityEngine;

namespace Effects
{
    public class GameObjectsDestroyer : MonoBehaviour
    {
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
