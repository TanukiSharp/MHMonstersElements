using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MHMonstersElements.ViewModels
{
    public class WeaponGroupViewModel : ViewModelBase
    {
        public const int DisplayedWeaponCountPerCategory = 7;

        public MH.WeaponClass Class { get; private set; }
        public string DisplayName { get; private set; }

        public WeaponViewModel[] Weapons { get; private set; }

        public WeaponGroupViewModel(MH.WeaponClass weaponClass, IEnumerable<Weapon> weapons)
        {
            Class = weaponClass;
            DisplayName = MH.GetWeaponClassDisplayName(Class);

            Weapons = weapons
                .Select(x => new WeaponViewModel(x))
                .ToArray();

            var view = (ICollectionViewLiveShaping)CollectionViewSource.GetDefaultView(Weapons);
            if (view.CanChangeLiveFiltering)
            {
                ((ICollectionView)view).Filter = x => ((WeaponViewModel)x).IsVisible;
                view.LiveFilteringProperties.Add("IsVisible");
                view.IsLiveFiltering = true;
            }
            if (view.CanChangeLiveSorting)
            {
                ((ICollectionView)view).SortDescriptions.Add(new SortDescription("DamageRate", ListSortDirection.Descending));
                view.LiveSortingProperties.Add("DamageRate");
                view.IsLiveSorting = true;
            }
        }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            private set { SetValue(ref isVisible, value); }
        }

        private bool isSharpnessPlusOne;
        public void SetSharpnessPlusOne(bool value)
        {
            isSharpnessPlusOne = value;
            foreach (var weapon in Weapons)
                weapon.SetSharpnessPlusOne(isSharpnessPlusOne);
        }

        public void SetElements(int[] elements)
        {
            if (elements.Any(x => x > 0))
            {
                var ratedWeapons = Weapons
                    .Select((wvm, i) => new { Rate = MH.ComputeSimpleDamage(wvm.Weapon, isSharpnessPlusOne, elements), Index = i })
                    .ToArray();

                var orderedSubset = ratedWeapons
                    .OrderByDescending(x => x.Rate)
                    .Take(DisplayedWeaponCountPerCategory)
                    .ToArray();

                var maxRate = orderedSubset.First().Rate;

                foreach (var weapon in Weapons)
                    weapon.IsVisible = false;

                var firstIndex = orderedSubset[0].Index;
                Weapons[firstIndex].DamageRate = maxRate;
                Weapons[firstIndex].DamageRateText = "MAX";
                Weapons[firstIndex].IsVisible = true;

                foreach (var x in orderedSubset.Skip(1))
                {
                    Weapons[x.Index].DamageRate = x.Rate;
                    Weapons[x.Index].DamageRateText = string.Format("{0:#.##} %", x.Rate * 100.0f / maxRate);
                    Weapons[x.Index].IsVisible = true;
                }
            }
            else
            {
                foreach (var weapon in Weapons)
                    weapon.IsVisible = false;
            }

            IsVisible = Weapons.Any(x => x.IsVisible);
        }
    }
}
