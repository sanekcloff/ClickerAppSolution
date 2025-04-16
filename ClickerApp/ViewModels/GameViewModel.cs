using ClickerApp.Entities.Base;
using ClickerApp.Entities.Stats.Instances;
using ClickerApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
                if (Player.HealthPotions <= 0) return;
                _player.Component.Health.Heal();
                _player.HealthPotions--;
                OnPropertyChanged(nameof(Player));
            });

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(5);
            _dispatcherTimer.Tick += Timer_Tick;
            _dispatcherTimer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (Player.Component.Health.IsDead)
            {
                _dispatcherTimer.Stop();
                MessageBox.Show($"THE END! SCORE IS {_score}");
                Environment.Exit(0);
            }
            _enemy!.Component.Damage.DealDamage(_player.Component.Health);
            OnPropertyChanged(nameof(Enemy));
            OnPropertyChanged(nameof(Player));
        }

        private DispatcherTimer _dispatcherTimer;
        private PlayerBase _player;
        private EnemyBase? _enemy = null!;
        private int _score = 0;

        public PlayerBase Player => _player;
        public EnemyBase? Enemy => _enemy;

        public bool IsEnemyExist => _enemy != null;
        public bool IsEnemyDead => _enemy!.Component.Health.IsDead;

        public RelayCommand Attack { get; }
        public RelayCommand Heal { get; }

        public void RespawnEnemy()
        {
            _enemy = EnemyBase.CreateEnemy(_player.Component.Level.CurrentLevel);
            _score = 0;
            if (_player.Component.Level.CurrentLevel % 5 == 0)
                _player.HealthPotions++;

            OnPropertyChanged(nameof(Enemy));
            OnPropertyChanged(nameof(Player));
        }
    }
}
