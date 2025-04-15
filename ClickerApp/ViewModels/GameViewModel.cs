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
            _statsComponent = new();
            _statsComponent.Health.TakeDamage(25);
            _statsComponent.Health.Heal();
            _statsComponent.Level.AddExp(250);
            _statsComponent.Level.LvlUp();
            _statsComponent.Health.TakeDamage(23);
        }
        private StatsComponentBase _statsComponent;
    }
}
