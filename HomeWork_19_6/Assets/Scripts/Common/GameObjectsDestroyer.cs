using UnityEngine;

namespace Common
{
    public class GameObjectsDestroyer : MonoBehaviour
    {
        private void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}
