using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class HealthComponent
    {
        public HealthComponent(HealthData healthData)
        {
            _healthData = healthData;
        }
        public HealthComponent(float baseHealth = 100, float perLvlHealth = 10, float minHealth = 0)
        {
            _healthData = new HealthData(baseHealth, perLvlHealth, minHealth);
        }
        private HealthData _healthData;

        public bool IsDead => _healthData.CurrentHealth == _healthData.MinHealth;
        public bool IsAlive => _healthData.CurrentHealth > _healthData.MinHealth;
        public bool IsFullHealth => _healthData.CurrentHealth == _healthData.MaxHealth;
        public void TakeDamage(float dmg)
        {
            if (IsDead) return;

            var diff = _healthData.CurrentHealth - dmg;
            if (diff >= 0)
            {
                _healthData.CurrentHealth = diff;
            }
            else 
            {
                _healthData.CurrentHealth = _healthData.MinHealth;
            }
        }
        public void Heal()
        {
            if (IsDead) return;

            if (IsFullHealth) return;

            _healthData.CurrentHealth = Math.Clamp(_healthData.CurrentHealth + _healthData.MaxHealth * 0.2f, _healthData.MinHealth,_healthData.MaxHealth);
        }
        public void LvlUp()
        {
            Console.WriteLine("Level up!");
            _healthData.IncreeseLvlMupltiplier();
        }
    }
    public struct HealthData
    {
        public HealthData(float baseHealth, float perLvlHealth, float minHealth)
        {
            _baseHealth = baseHealth;
            _perLvlHealth = perLvlHealth;
            CurrentHealth = MaxHealth;
            MinHealth = minHealth;
        }
        private float _baseHealth;
        private float _perLvlHealth;
        private int _lvlMultiplier = 1;

        public float CurrentHealth { get; set; }
        public float MaxHealth => _baseHealth + _perLvlHealth * LvlMultiplier;
        public int LvlMultiplier => _lvlMultiplier - 1;

        public readonly float MinHealth;

        public void IncreeseLvlMupltiplier() => _lvlMultiplier++;
    }
}
