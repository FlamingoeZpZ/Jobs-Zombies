using System;
using TMPro;
using UnityEngine;
using Version_3__Jobs_;

namespace Version_1
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;

        private int _currentScore;
        
        private void OnEnable()
        {
            Zombie.OnDeath += DefeatedZombie;
            Zombie2.OnDeath += DefeatedZombie2;
        }

        private void OnDisable()
        {
            Zombie.OnDeath -= DefeatedZombie;
            Zombie2.OnDeath -= DefeatedZombie2;
        }

        private void DefeatedZombie(Zombie zombie)
        {
            _currentScore += zombie.GetScore();
            score.text = _currentScore.ToString();
        }
        
        private void DefeatedZombie2(Zombie2 zombie)
        {
            _currentScore += zombie.GetScore();
            score.text = _currentScore.ToString();
        }
    }
}
