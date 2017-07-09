using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MHMonstersElements
{
    public class MH
    {
        public enum ElementType
        {
            None = -1,
            Fire,
            Water,
            Thunder,
            Ice,
            Dragon
        }

        public enum SharpnessType
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            White,
            Purple
        }

        public enum WeaponClass
        {
            GreatSword,
            LongSword,
            SwordAndShield,
            DualBlades,
            Hammer,
            HuntingHorn,
            Lance,
            Gunlance,
            ChargeBlade,
            SwitchAxe,
            LightBowGun,
            HeavyBoxGun,
            Bow
        }

        public class SharpnessRawMultipliers
        {
            public const float Red = 0.5f;
            public const float Orange = 0.75f;
            public const float Yellow = 1.0f;
            public const float Green = 1.05f;
            public const float Blue = 1.2f;
            public const float White = 1.32f;
            public const float Purple = 1.44f;
        }

        public class SharpnessElementalMultipliers
        {
            public const float Red = 0.25f;
            public const float Orange = 0.5f;
            public const float Yellow = 0.75f;
            public const float Green = 1.0f;
            public const float Blue = 1.0625f;
            public const float White = 1.125f;
            public const float Purple = 1.2f;
        }

        public class WeaponClassMultipliers
        {
            public const float GreatSword = 4.8f;
            public const float LongSword = 3.3f;
            public const float SwordAndShield = 1.4f;
            public const float DualBlades = 1.4f;
            public const float Hammer = 5.2f;
            public const float HuntingHorn = 5.2f;
            public const float Lance = 2.3f;
            public const float Gunlance = 2.3f;
            public const float SwitchAxe = 5.4f;
            public const float ChargeBlade = 5.4f;
            public const float LightBowGun = 1.3f;
            public const float HeavyBoxGun = 1.5f;
            public const float Bow = 1.2f;
        }

        public class AttackTypeMultipliers
        {
            public const float SwordAndShield = 0.14f;
            public const float GreatSword = 0.65f;
            public const float Lance = 0.25f;
            public const float Hammer = 0.37f;
            public const float LongSword = 0.27f;
            public const float ChargeBlade = 0.44f;
            public const float SwitchAxe = 0.29f;

            public const float DualBlades = 0.2f;
            public const float HuntingHorn = 0.3f;
            public const float Gunlance = 0.25f;

            public const float LightBowGun = 1.0f;
            public const float HeavyBoxGun = 1.0f;
            public const float Bow = 1.0f;
        }

        public static string GetWeaponClassDisplayName(WeaponClass weapon)
        {
            switch (weapon)
            {
                case WeaponClass.GreatSword: return "Great Sword";
                case WeaponClass.LongSword: return "Long Sword";
                case WeaponClass.SwordAndShield: return "Sword and Shield";
                case WeaponClass.DualBlades: return "Dual Blades";
                case WeaponClass.Hammer: return "Hammer";
                case WeaponClass.HuntingHorn: return "Hunting Horn";
                case WeaponClass.Lance: return "Lance";
                case WeaponClass.Gunlance: return "Gunlance";
                case WeaponClass.ChargeBlade: return "Charge Blade";
                case WeaponClass.SwitchAxe: return "Switch Axe";
                case WeaponClass.LightBowGun: return "Ligh Bowgun";
                case WeaponClass.HeavyBoxGun: return "Heavy Bowgun";
                case WeaponClass.Bow: return "Bow";
            }

            return null;
        }

        public static float GetRawSharpnessMultiplier(SharpnessType sharpness)
        {
            switch (sharpness)
            {
                case SharpnessType.Red: return SharpnessRawMultipliers.Red;
                case SharpnessType.Orange: return SharpnessRawMultipliers.Orange;
                case SharpnessType.Yellow: return SharpnessRawMultipliers.Yellow;
                case SharpnessType.Green: return SharpnessRawMultipliers.Green;
                case SharpnessType.Blue: return SharpnessRawMultipliers.Blue;
                case SharpnessType.White: return SharpnessRawMultipliers.White;
                case SharpnessType.Purple: return SharpnessRawMultipliers.Purple;
            }

            return 1.0f;
        }

        public static float GetElementalSharpnessMultiplier(SharpnessType sharpness)
        {
            switch (sharpness)
            {
                case SharpnessType.Red: return SharpnessElementalMultipliers.Red;
                case SharpnessType.Orange: return SharpnessElementalMultipliers.Orange;
                case SharpnessType.Yellow: return SharpnessElementalMultipliers.Yellow;
                case SharpnessType.Green: return SharpnessElementalMultipliers.Green;
                case SharpnessType.Blue: return SharpnessElementalMultipliers.Blue;
                case SharpnessType.White: return SharpnessElementalMultipliers.White;
                case SharpnessType.Purple: return SharpnessElementalMultipliers.Purple;
            }

            return 1.0f;
        }

        public static float GetWeaponClassMultiplier(WeaponClass weapon)
        {
            switch (weapon)
            {
                case WeaponClass.GreatSword: return WeaponClassMultipliers.GreatSword;
                case WeaponClass.LongSword: return WeaponClassMultipliers.LongSword;
                case WeaponClass.SwordAndShield: return WeaponClassMultipliers.SwordAndShield;
                case WeaponClass.DualBlades: return WeaponClassMultipliers.DualBlades;
                case WeaponClass.Hammer: return WeaponClassMultipliers.Hammer;
                case WeaponClass.HuntingHorn: return WeaponClassMultipliers.HuntingHorn;
                case WeaponClass.Lance: return WeaponClassMultipliers.Lance;
                case WeaponClass.Gunlance: return WeaponClassMultipliers.Gunlance;
                case WeaponClass.ChargeBlade: return WeaponClassMultipliers.ChargeBlade;
                case WeaponClass.SwitchAxe: return WeaponClassMultipliers.SwitchAxe;
                case WeaponClass.LightBowGun: return WeaponClassMultipliers.LightBowGun;
                case WeaponClass.HeavyBoxGun: return WeaponClassMultipliers.HeavyBoxGun;
                case WeaponClass.Bow: return WeaponClassMultipliers.Bow;
            }

            return 1.0f;
        }

        public static float GetAttackTypeMultiplier(WeaponClass weapon)
        {
            switch (weapon)
            {
                case WeaponClass.GreatSword: return AttackTypeMultipliers.GreatSword;
                case WeaponClass.LongSword: return AttackTypeMultipliers.LongSword;
                case WeaponClass.SwordAndShield: return AttackTypeMultipliers.SwordAndShield;
                case WeaponClass.DualBlades: return AttackTypeMultipliers.DualBlades;
                case WeaponClass.Hammer: return AttackTypeMultipliers.Hammer;
                case WeaponClass.HuntingHorn: return AttackTypeMultipliers.HuntingHorn;
                case WeaponClass.Lance: return AttackTypeMultipliers.Lance;
                case WeaponClass.Gunlance: return AttackTypeMultipliers.Gunlance;
                case WeaponClass.ChargeBlade: return AttackTypeMultipliers.ChargeBlade;
                case WeaponClass.SwitchAxe: return AttackTypeMultipliers.SwitchAxe;
                case WeaponClass.LightBowGun: return AttackTypeMultipliers.LightBowGun;
                case WeaponClass.HeavyBoxGun: return AttackTypeMultipliers.HeavyBoxGun;
                case WeaponClass.Bow: return AttackTypeMultipliers.Bow;
            }

            return 1.0f;
        }

        public static int ComputeSimpleDamage(Weapon weapon, bool sharpnessPlusOne, int[] monsterElemZones)
        {
            return ComputeSimpleDamage(
                weapon.RawDamage,
                weapon.Affinity,
                sharpnessPlusOne ? weapon.SharpnessPlusOne : weapon.Sharpness,
                weapon.WeaponClass,
                weapon.ElementDamage,
                weapon.ElementType,
                monsterElemZones);
        }

        private static int ComputeSimpleDamage(int attack, int affinity, SharpnessType sharpness, WeaponClass weapon, int element, ElementType elementType, int[] monsterElemZones)
        {
            //var usedAffinity = 1.0f;
            var usedAffinity = 1.0f + (0.25f * affinity / 100.0f);

            var rawDamage = attack * usedAffinity * GetAttackTypeMultiplier(weapon) * GetRawSharpnessMultiplier(sharpness) / GetWeaponClassMultiplier(weapon);
            if (weapon == WeaponClass.Bow)
                rawDamage *= 0.225f;

            var elemDamage = 0.0f;
            if (elementType != ElementType.None)
                elemDamage = element * GetElementalSharpnessMultiplier(sharpness) * (monsterElemZones[(int)elementType] / 100.0f) / 10.0f;

            return (int)(rawDamage + elemDamage);
        }
    }

    public class Monster
    {
        public string Name { get; private set; }

        public int FireWeakness { get; private set; }
        public int WaterWeakness { get; private set; }
        public int IceWeakness { get; private set; }
        public int ThunderWeakness { get; private set; }
        public int DragonWeakness { get; private set; }

        public Monster(string name, int fireWeakness, int waterWeakness, int iceWeakness, int thunderWeakness, int dragonWeakness)
        {
            Name = name;
            FireWeakness = fireWeakness > 0 ? fireWeakness : -1;
            WaterWeakness = waterWeakness > 0 ? waterWeakness : -1;
            IceWeakness = iceWeakness > 0 ? iceWeakness : -1;
            ThunderWeakness = thunderWeakness > 0 ? thunderWeakness : -1;
            DragonWeakness = dragonWeakness > 0 ? dragonWeakness : -1;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0} [", Name);

            var elements = new List<string>();

            if (FireWeakness > 0)
                elements.Add(string.Format("Fire: {0}", FireWeakness));
            if (WaterWeakness > 0)
                elements.Add(string.Format("Water: {0}", WaterWeakness));
            if (IceWeakness > 0)
                elements.Add(string.Format("Ice: {0}", IceWeakness));
            if (ThunderWeakness > 0)
                elements.Add(string.Format("Thunder: {0}", ThunderWeakness));
            if (DragonWeakness > 0)
                elements.Add(string.Format("Dragon: {0}", DragonWeakness));

            sb.Append(string.Join(", ", elements));

            sb.Append("]");

            return sb.ToString();
        }

        public static Monster LoadMonster(XmlElement node)
        {
            if (node == null || node.Name != "Monster")
                return null;

            var attr = node.Attributes["Name"];
            if (attr == null)
                return null;

            var name = attr.Value.Trim();

            if (name.Length == 0)
                return null;

            int fire = 0;
            int water = 0;
            int ice = 0;
            int thunder = 0;
            int dragon = 0;

            attr = node.Attributes["Fire"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out fire) == false)
                    return null;
            }

            attr = node.Attributes["Water"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out water) == false)
                    return null;
            }

            attr = node.Attributes["Ice"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out ice) == false)
                    return null;
            }

            attr = node.Attributes["Thunder"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out thunder) == false)
                    return null;
            }

            attr = node.Attributes["Dragon"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out dragon) == false)
                    return null;
            }

            return new Monster(name, fire, water, ice, thunder, dragon);
        }
    }

    public class Weapon
    {
        public string Name { get; private set; }
        public MH.WeaponClass WeaponClass { get; private set; }
        public int RawDamage { get; private set; }
        public int ElementDamage { get; private set; }
        public MH.ElementType ElementType { get; private set; }
        public int Affinity { get; private set; }
        public MH.SharpnessType Sharpness { get; private set; }
        public MH.SharpnessType SharpnessPlusOne { get; private set; }

        public Weapon(string name, MH.WeaponClass weaponClass, int rawDamage, int affinity, int elemDamage, MH.ElementType elemType, MH.SharpnessType sharpness, MH.SharpnessType sharpnessPlusOne)
        {
            Name = name;
            WeaponClass = weaponClass;
            RawDamage = rawDamage;
            Affinity = affinity;
            ElementDamage = elemDamage;
            ElementType = elemType;

            Sharpness = MH.SharpnessType.Green;
            SharpnessPlusOne = MH.SharpnessType.Green;

            if ((weaponClass == MH.WeaponClass.Bow ||
                weaponClass == MH.WeaponClass.LightBowGun ||
                weaponClass == MH.WeaponClass.HeavyBoxGun) == false)
            {
                Sharpness = sharpness;
                SharpnessPlusOne = sharpnessPlusOne;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Name, WeaponClass);
        }

        public static Weapon LoadWeapon(XmlElement node)
        {
            MH.WeaponClass weaponClass;
            if (Enum.TryParse(node.Name, out weaponClass) == false)
                return null;

            var attr = node.Attributes["Name"];
            if (attr == null)
                return null;

            var weaponName = attr.Value.Trim();
            if (weaponName.Length == 0)
                return null;

            attr = node.Attributes["Raw"];
            if (attr == null)
                return null;

            uint rawDamage;
            if (uint.TryParse(attr.Value.Trim(), out rawDamage) == false)
                return null;

            uint elemDamage = 0;

            attr = node.Attributes["Element"];
            if (attr != null)
            {
                if (uint.TryParse(attr.Value.Trim(), out elemDamage) == false)
                    return null;
            }

            int affinity = 0;

            attr = node.Attributes["Affinity"];
            if (attr != null)
            {
                if (int.TryParse(attr.Value.Trim(), out affinity) == false)
                    return null;
            }

            MH.ElementType elementType = MH.ElementType.None;

            attr = node.Attributes["ElementType"];
            if (attr != null)
            {
                if (Enum.TryParse(attr.Value.Trim(), out elementType) == false)
                    return null;
            }

            MH.SharpnessType sharpness = MH.SharpnessType.Green;
            MH.SharpnessType sharpnessPlusOne = MH.SharpnessType.Green;

            attr = node.Attributes["Sharpness"];
            if (attr != null)
            {
                if (Enum.TryParse(attr.Value.Trim(), out sharpness) == false)
                    return null;
            }

            attr = node.Attributes["SharpnessPlusOne"];
            if (attr != null)
            {
                if (Enum.TryParse(attr.Value.Trim(), out sharpnessPlusOne) == false)
                    return null;
            }
            else
                sharpnessPlusOne = sharpness;

            return new Weapon(weaponName, weaponClass, (int)rawDamage, affinity, (int)elemDamage, elementType, sharpness, sharpnessPlusOne);
        }
    }
}
