using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats.Instances
{
    public class StatsComponentBase
    {
        public StatsComponentBase()
        {
            _level = new LevelComponent();
            _health = new HealthComponent();
            _damage = new DamageComponent();

            _level.LevelUp += _health.LvlUp;
            _level.LevelUp += _damage.LvlUp;
        }

        private LevelComponent _level;
        private HealthComponent _health;
        private DamageComponent _damage;

        public LevelComponent Level => _level;
        public HealthComponent Health => _health;
        public DamageComponent Damage => _damage;
    }
}