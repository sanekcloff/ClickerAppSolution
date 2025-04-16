using ClickerApp.Utils.Abstract;
using ClickerApp.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats.Instances
{
    public class StatsComponentBase : ComponentBase
    {
        public StatsComponentBase() : base(null!)
        {
            _level = new LevelComponent(this);
            _health = new HealthComponent(this);
            _damage = new DamageComponent(this);

            _level.LevelUp += _health.LvlUp;
            _level.LevelUp += _damage.LvlUp;
        }
        public StatsComponentBase((int level, int maxExp) levelComponent, (float @base, float perLvl) healthComponent, (float @base, float perLvl) damageComponent) : base (null!)
        {
            _level = new LevelComponent(this,levelComponent.level,levelComponent.maxExp);
            _health = new HealthComponent(this, healthComponent.@base,healthComponent.perLvl);
            _damage = new DamageComponent(this,damageComponent.@base, damageComponent.perLvl);

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