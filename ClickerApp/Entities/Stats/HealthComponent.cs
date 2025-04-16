using ClickerApp.Utils.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class HealthComponent : ComponentBase
    {
        private class HealthData
        {
            public HealthData(float baseHealth, float perLvlHealth, float minHealth)
            {
                _baseHealth = baseHealth;
                _perLvlHealth = perLvlHealth;
                CurrentHealth = MaxHealth;
                MinHealth = minHealth;
                Debug.WriteLine($"{this} created!");
            }

            private float _baseHealth;
            private float _perLvlHealth;
            private int _lvlMultiplier = 1;

            public float CurrentHealth { get; set; }
            public float MaxHealth => _baseHealth + _perLvlHealth * LvlMultiplier;
            public int LvlMultiplier => _lvlMultiplier - 1;

            public readonly float MinHealth;

            public void IncreeseLvlMupltiplier(int level)
            {
                _lvlMultiplier = level;
                Debug.WriteLine($" {this.GetType().Name} - Level multiplier changed!");
                ResetHealth();
            }
            private void ResetHealth()
            {
                CurrentHealth = MaxHealth;
                Debug.WriteLine($"{this.GetType().Name} - health reseted!");
            }
        }

        public HealthComponent(ComponentBase owner = null!, float baseHealth = 100, float perLvlHealth = 10, float minHealth = 0) : base(owner)
        {
            _healthData = new HealthData(baseHealth, perLvlHealth, minHealth);
            Debug.WriteLine($"{this} created!");
        }
        private HealthData _healthData;

        public float MinHealth => _healthData.MinHealth;
        public float MaxHealth => _healthData.MaxHealth;
        public float CurrentHealth { get => _healthData.CurrentHealth; set { Console.WriteLine(); } }

        public bool IsDead => _healthData.CurrentHealth == _healthData.MinHealth;
        public bool IsAlive => _healthData.CurrentHealth > _healthData.MinHealth;
        public bool IsFullHealth => _healthData.CurrentHealth == _healthData.MaxHealth;
        public bool TakeDamage(float dmg)
        {
            if (IsDead) return false;

            var diff = _healthData.CurrentHealth - dmg;
            if (diff >= 0)
            {
                _healthData.CurrentHealth = diff;
            }
            else
            {
                _healthData.CurrentHealth = _healthData.MinHealth;
            }
            Debug.WriteLine($"{this} - taked {dmg} damage!");
            return true;
        }
        public void Heal()
        {
            if (IsDead) return;

            if (IsFullHealth) return;

            _healthData.CurrentHealth = Math.Clamp(_healthData.CurrentHealth + _healthData.MaxHealth * 0.2f, _healthData.MinHealth, _healthData.MaxHealth);
            Debug.WriteLine($"{this} healed!");
        }
        public void LvlUp(int level)
        {
            Debug.WriteLine($"{this} - Level up!");
            _healthData.IncreeseLvlMupltiplier(level);
        }
    }

}
