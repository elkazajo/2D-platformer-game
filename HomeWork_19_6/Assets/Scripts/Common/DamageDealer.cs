using UnityEngine;

namespace Common
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private string[] tags = { "Player", "Enemy" };

        private void OnTriggerEnter2D(Collider2D col)
        {
            Health health = col.gameObject.GetComponentInParent<Health>();

            if (col.gameObject.CompareTag(tags[0]))
            {
                if (health.currentHealth > 0 && health.canReceiveDamage)
                {
                    health.ReceiveDamage(damage);
                }
            }
        }
    }
}
