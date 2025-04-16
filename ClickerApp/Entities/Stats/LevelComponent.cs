using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerApp.Entities.Stats
{
    public class LevelComponent
    {

        private class LevelData
        {
            public LevelData(int level, int maxExp)
            {
                _currentExp = MIN_EXP;
                _level = level;
                _maxExp = maxExp;
                Debug.WriteLine("Level data created!");
            }

            private int _level;
            private int _maxExp;
            private int _currentExp;

            public const int MIN_EXP = 0;
            public int Level => _level;
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
        public LevelComponent(int level = 1, int maxExp = 100)
        {
            _levelData = new LevelData(level, maxExp);
            Debug.WriteLine("Level component created!");
        }

        private LevelData _levelData;

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
