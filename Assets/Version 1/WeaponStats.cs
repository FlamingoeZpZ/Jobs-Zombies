using System;
using UnityEngine;

namespace Version_1
{
    [CreateAssetMenu(order = 1, menuName = "WeaponStats", fileName = "WeaponStats")]
    public class WeaponStats : ScriptableObject
    {
        [SerializeField] private float timeBetweenShots;
        [field: SerializeField] public bool IsFullyAuto { get; private set; }
        
        public WaitForSeconds TimeBetweenShots { get; private set; }

        private void OnValidate()
        {
            TimeBetweenShots = new WaitForSeconds(timeBetweenShots);
        }
    }
}
