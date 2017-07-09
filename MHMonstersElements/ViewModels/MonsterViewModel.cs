using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MHMonstersElements.ViewModels
{
    public class MonsterViewModel : ViewModelBase
    {
        public string Name { get; private set; }
        public string ImagePath { get; private set; }

        public bool IsValid { get; private set; }

        private bool isVisible = true;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetValue(ref isVisible, value); }
        }

        public ElementViewModel[] Elements { get; private set; }

        public MonsterViewModel(Monster monster)
        {
            Name = monster.Name;

            var pathName = monster.Name;
            if (pathName.Contains("Alatreon") || pathName == "Dire Miralis")
                pathName = "Boss";
            ImagePath = string.Format("images\\monsters\\{0}.png", pathName);

            var array = new []
            {
                monster.FireWeakness,
                monster.WaterWeakness,
                monster.ThunderWeakness,
                monster.IceWeakness,
                monster.DragonWeakness
            };

            IsValid = array.Any(v => v > 0);

            Elements = RootViewModel.CreateElements(array);

            NavigateCommand = new AnonymousCommand(OnNavigate);
        }

        public ICommand NavigateCommand { get; private set; }

        private void OnNavigate()
        {
            Process.Start(string.Format("http://monsterhunter.wikia.com/wiki/{0}", Name.Replace(' ', '_')));
        }
    }
}
