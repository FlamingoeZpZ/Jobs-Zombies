using System;
using UnityEngine;
using Version_1;

namespace Version_3__Jobs_
{
    public class Zombie2 : MonoBehaviour, IDamagable
    {
        [SerializeField] private float health;
        [SerializeField] private int score;
        [SerializeField] private float speed;
        public static event Action<Zombie2> OnDeath;
        
        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }

        public int GetScore()
        {
            return score;
        }
    }
}
