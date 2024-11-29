using System.Collections;
using UnityEngine;

namespace Version_1
{
    public abstract class Weapon : MonoBehaviour
    {

        [SerializeField] private WeaponStats stats;
        
        private bool _isShooting;
        private bool _isOnCooldown;
        private Coroutine _firingRoutine;
        
        public void SetFiringState(bool readValueAsButton)
        {
            _isShooting = readValueAsButton;
            if (readValueAsButton && _firingRoutine == null)
                _firingRoutine = StartCoroutine(FiringTimer());
        }

        private IEnumerator ShootingCooldown()
        {
            _isOnCooldown = true;
            yield return stats.TimeBetweenShots;
            _isOnCooldown = false;
        }

        private IEnumerator FiringTimer()
        {
            do
            {
                if (CanFire())
                {
                    Fire();
                    yield return ShootingCooldown();
                }
            } while (_isShooting && stats.IsFullyAuto);

            _firingRoutine = null;
        }

        protected abstract void Fire(); 
        
        private bool CanFire()
        {
            //And had ammo or wtevr
            return !_isOnCooldown;
        }

    }
}
