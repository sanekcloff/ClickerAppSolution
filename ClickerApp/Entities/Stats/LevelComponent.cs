using ClickerApp.Utils.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class LevelComponent : ComponentBase
    {
        private class LevelData
        {
            public LevelData(int maxExp)
            {
                _currentExp = MIN_EXP;
                _level = 1;
                _maxExp = maxExp;
                Debug.WriteLine("Level data created!");
            }

            private int _level;
            private int _maxExp;
            private int _currentExp;

            public const int MIN_EXP = 0;
            public int Level => _level;
            public int MaxExp => _maxExp;
            public int CurrentExp => _currentExp;
            public bool CanLvlUp => _currentExp >= _maxExp;

            public void AddExp(int value)
            {
                if (value > 0)
                {
                    _currentExp += value;
                    Debug.WriteLine($"Added {value} exp!");
                }
            }
            public void StartIncreeseLevel()
            {
                while (CanLvlUp)
                {
                    _currentExp = IncreeseLevel();
                    _maxExp = (int)(_maxExp * 1.5f);
                }
            }
            private int IncreeseLevel()
            {
                _level++;
                // 0 = 100 - 100
                // 150 = 250 - 100
                Debug.WriteLine($" {this.GetType().Name} - Level upped!");
                return _currentExp - _maxExp;
            }

        }

        #region Delegates & Events
        public delegate void LevelHandler(int level);
        public event LevelHandler LevelUp;
        #endregion
        public LevelComponent(ComponentBase owner, int level = 1, int maxExp = 100) : base (owner)
        {
            _levelData = new LevelData( maxExp);
            Debug.WriteLine("Level component created!");
            
        }

        private LevelData _levelData;

        public int MaxExp => _levelData.MaxExp;
        public int CurrentExp => _levelData.CurrentExp;
        public int CurrentLevel => _levelData.Level;
        public bool CanLvlUp => _levelData.CanLvlUp;

        public void LvlUp()
        {
            if (!_levelData.CanLvlUp) return;

            _levelData.StartIncreeseLevel();
            LevelUp?.Invoke(_levelData.Level);
            Debug.WriteLine("Level increesed!");
        }
        public void AddExp(int value)
        {
            _levelData.AddExp(value);
        }
    }
    
}
