using System;
using UnityEngine;

namespace Version_1
{
    public class Zombie : MonoBehaviour, IDamagable
    {
        [SerializeField] private float health;
        [SerializeField] private int score;
        [SerializeField] private float speed;
        public static event Action<Zombie> OnDeath;

        //WE want all the zombies to move to the player.
        private void FixedUpdate()
        {
            //Calculate the direction vecotr
            Vector3 target = Player.PlayerLocation - transform.position;
            transform.LookAt(target, Vector3.up);
            transform.Translate(target.normalized *  (speed * Time.deltaTime), Space.World);
        }

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
