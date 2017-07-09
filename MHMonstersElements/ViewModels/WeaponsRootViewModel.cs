using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHMonstersElements.ViewModels
{
    public class WeaponsRootViewModel : ViewModelBase
    {
        public WeaponGroupViewModel[] WeaponGroups { get; private set; }

        public WeaponsRootViewModel(IEnumerable<Weapon> allWeapons)
        {
            WeaponGroups = allWeapons
                .GroupBy(x => x.WeaponClass)
                .Select(x => new WeaponGroupViewModel(x.Key, x))
                .ToArray();
        }

        private bool isSharpnessPlusOne;
        public bool IsSharpnessPlusOne
        {
            get { return isSharpnessPlusOne; }
            set
            {
                if (SetValue(ref isSharpnessPlusOne, value))
                {
                    foreach (var group in WeaponGroups)
                        group.SetSharpnessPlusOne(value);
                    SetElements(lastElements);
                }
            }
        }

        private int[] lastElements;
        public void SetElements(int[] elements)
        {
            lastElements = elements;
            foreach (var group in WeaponGroups)
                group.SetElements(elements);
        }
    }
}
