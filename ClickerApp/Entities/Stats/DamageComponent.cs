﻿using ClickerApp.Entities.Stats.Instances;
using ClickerApp.Utils.Abstract;
using ClickerApp.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class DamageComponent : ComponentBase
    {
        private class DamageData
        {
            public DamageData(float damageBase, float damagePerLvl)
            {
                _damageBase = damageBase;
                _damagePerLvl = damagePerLvl;
            }
            private float _damageBase;
            private float _damagePerLvl;
            private float _damageMultiplier = 1;

            public float Damage => _damageBase + _damagePerLvl * DamegeMultiplier;
            public float DamegeMultiplier => _damageMultiplier - 1;

            public void IncreeseDamageMupltiplier(int level)
            {
                _damageMultiplier = level;
                Debug.WriteLine($"{this.GetType().Name} - multiplier was changed!");
            }
        }

        public DamageComponent(ComponentBase owner = null!, float damageBase = 10, float damagePerLvl = 2) : base(owner)
        {
            _damageData = new DamageData(damageBase, damagePerLvl);
        }

        private DamageData _damageData;

        public void DealDamage(HealthComponent targetHealthComponent)
        {

            var isTakeDamage = targetHealthComponent.TakeDamage(_damageData.Damage);
            if (isTakeDamage)
            {
                Debug.WriteLine($"{this.GetType().Name} - dealed {_damageData.Damage} damage!");
                if (!targetHealthComponent.IsDead) return;

                var statComponent = Owner as StatsComponentBase;
                if (statComponent != null)
                {
                    statComponent.Level.AddExp(50);
                    if (statComponent.Level.CanLvlUp)
                    {
                        statComponent.Level.LvlUp();
                    }
                }
            }
            else
            {
                Debug.WriteLine($"{this.GetType().Name} - doesn't dealed {_damageData.Damage} damage!");
            }
        }

        public void LvlUp(int level)
        {
            _damageData.IncreeseDamageMupltiplier(level);
        }
    }
}
