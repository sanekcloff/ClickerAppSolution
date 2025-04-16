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
            _statsComponent1 = new();
            _statsComponent2 = new();

            _statsComponent1.Damage.DealDamage(_statsComponent2);
            _statsComponent1.Damage.DealDamage(_statsComponent2);
            _statsComponent1.Damage.DealDamage(_statsComponent2);
        }
        private StatsComponentBase _statsComponent1;
        private StatsComponentBase _statsComponent2;
    }
}
