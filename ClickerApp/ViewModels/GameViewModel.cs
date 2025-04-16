using ClickerApp.Entities.Base;
using ClickerApp.Entities.Stats.Instances;
using ClickerApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public GameViewModel()
        {
            _player = new PlayerBase("Loloshka", new StatsComponentBase(), 4);
            RespawnEnemy();

            Attack = new RelayCommand(o =>
            {
                _player.Component.Damage.DealDamage(_enemy!.Component.Health);
                OnPropertyChanged(nameof(Enemy));
                if (IsEnemyDead)
                    RespawnEnemy();
            });
            Heal = new RelayCommand(o => 
            {
                _player.Component.Health.Heal();
            });
        }
        private PlayerBase _player;
        private EnemyBase? _enemy = null!;

        public PlayerBase Player => _player;
        public EnemyBase? Enemy => _enemy;

        public bool IsEnemyExist => _enemy != null;
        public bool IsEnemyDead => _enemy!.Component.Health.IsDead;

        public RelayCommand Attack { get; }
        public RelayCommand Heal { get; }

        public void RespawnEnemy()
        {
            if (IsEnemyExist) return;

            _enemy = EnemyBase.CreateEnemy();
            OnPropertyChanged(nameof(Enemy));
        }
    }
}
