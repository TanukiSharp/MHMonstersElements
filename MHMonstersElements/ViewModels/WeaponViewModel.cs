using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHMonstersElements.ViewModels
{
    public class WeaponViewModel : ViewModelBase
    {
        public Weapon Weapon { get; private set; }

        public string Name { get { return Weapon.Name; } }
        public int RawDamage { get { return Weapon.RawDamage; } }
        public int Affinity { get { return Weapon.Affinity; } }
        public int ElementDamage { get { return Weapon.ElementDamage; } }
        public MH.ElementType ElementType { get { return Weapon.ElementType; } }
        public string ElementName { get { return Weapon.ElementType.ToString(); } }

        private MH.SharpnessType sharpnessType;
        public MH.SharpnessType SharpnessType
        {
            get { return sharpnessType; }
            private set { SetValue(ref sharpnessType, value); }
        }

        public bool HasElement { get; private set; }
        public string ClassImagePath { get; private set; }
        public string ElementImagePath { get; private set; }

        private bool isSharpnessPlusOne;
        public void SetSharpnessPlusOne(bool value)
        {
            isSharpnessPlusOne = value;
            SharpnessType = isSharpnessPlusOne ? Weapon.SharpnessPlusOne : Weapon.Sharpness;
        }

        private int damageRate;
        public int DamageRate
        {
            get { return damageRate; }
            set { SetValue(ref damageRate, value); }
        }

        private string damageRateText;
        public string DamageRateText
        {
            get { return damageRateText; }
            set { SetValue(ref damageRateText, value); }
        }

        private bool isVisible = true;
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetValue(ref isVisible, value); }
        }

        public WeaponViewModel(Weapon weapon)
        {
            Weapon = weapon;

            SetSharpnessPlusOne(false);

            HasElement = weapon.ElementType != MH.ElementType.None && weapon.ElementDamage > 0;
            ClassImagePath = GetWeaponImagePath(weapon.WeaponClass);
            ElementImagePath = string.Format("images\\common\\{0}.png", weapon.ElementType);
        }

        private string GetWeaponImagePath(MH.WeaponClass weapon)
        {
            switch (weapon)
            {
                case MH.WeaponClass.GreatSword: return "images\\common\\GS-Icon.png";
                case MH.WeaponClass.LongSword: return "images\\common\\LS-Icon.png";
                case MH.WeaponClass.SwordAndShield: return "images\\common\\SnS-Icon.png";
                case MH.WeaponClass.DualBlades: return "images\\common\\DS-Icon.png";
                case MH.WeaponClass.Hammer: return "images\\common\\Hammer-Icon.png";
                case MH.WeaponClass.HuntingHorn: return "images\\common\\HH-Icon.png";
                case MH.WeaponClass.Lance: return "images\\common\\Lance-Icon.png";
                case MH.WeaponClass.Gunlance: return "images\\common\\GL-Icon.png";
                case MH.WeaponClass.ChargeBlade: return "images\\common\\CB-Icon.png";
                case MH.WeaponClass.SwitchAxe: return "images\\common\\SA-Icon.png";
                case MH.WeaponClass.LightBowGun: return "images\\common\\LBG-Icon.png";
                case MH.WeaponClass.HeavyBoxGun: return "images\\common\\HBG-Icon.png";
                case MH.WeaponClass.Bow: return "images\\common\\Bow-Icon.png";
            }

            return null;
        }
    }
}
