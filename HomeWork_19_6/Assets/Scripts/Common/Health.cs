using System.Collections;
using Player_Controller.Player_Behaviours;
using UnityEngine;

    public class Health : AbstractBehaviour
    {
        [SerializeField] private float maxHealth; 
        
        public bool isAlive;

        public float currentHealth;

        public bool receivedDamage;
        public bool canReceiveDamage;

        private SpriteRenderer spriteRenderer;
        private Material matRed;
        private Material matDeafault;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            matRed = Resources.Load("RedMat", typeof(Material)) as Material;
            matDeafault = spriteRenderer.material;
            currentHealth = maxHealth;            
            isAlive = true;
            receivedDamage = false;
            canReceiveDamage = true;
        }

        public void ReceiveDamage(float damage)
        {
            if (currentHealth > 0)
            {
                StartCoroutine(GotDamage(damage));
            }        
            CheckIsAlive();
        }

        private void CheckIsAlive()
        {
            if (currentHealth > 0)
            {
                isAlive = true;
                ToggleScripts(true);
            }
            else
            {
                isAlive = false;
                ToggleScripts(false);
            }
        }

        IEnumerator GotDamage(float damage)
        {
            currentHealth -= damage;
            receivedDamage = true;
            canReceiveDamage = false;
            yield return new WaitForSeconds(0.4f);
            receivedDamage = false;
            canReceiveDamage = true;
        }
    }

