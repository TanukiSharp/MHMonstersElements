using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Diagnostics;

namespace MHMonstersElements.ViewModels
{
    public class RootViewModel : ViewModelBase
    {
        public static readonly string[] ElementNames = new[] { "Fire", "Water", "Thunder", "Ice", "Dragon" };

        public string Title { get; private set; }
        public string FullVersion { get; private set; }

        public RootViewModel()
        {
            Title = "Tanuki's MH Monsters Elements";

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Title += string.Format(" v{0}.{1}", version.Major, version.Minor);

            FullVersion = string.Format("version {0}.{1} Build {2} Revision {3}",
                version.Major, version.Minor, version.Build, version.Revision);

            CopyVersionCommand = new AnonymousCommand(() => Clipboard.SetText(FullVersion));

            LoadMonsters();
            LoadWeapons();

            ProcessFilter();
        }

        public ICommand CopyVersionCommand { get; private set; }

        private string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                if (SetValue(ref filter, value))
                    ProcessFilter();
            }
        }

        private MonsterViewModel[] monsters;
        public MonsterViewModel[] Monsters
        {
            get { return monsters; }
            set { SetValue(ref monsters, value); }
        }

        private ElementViewModel[] totalElements;
        public ElementViewModel[] TotalElements
        {
            get { return totalElements; }
            set { SetValue(ref totalElements, value); }
        }

        private bool isSharpnessPlusOne;
        public bool IsSharpnessPlusOne
        {
            get { return isSharpnessPlusOne; }
            set
            {
                if (SetValue(ref isSharpnessPlusOne, value))
                    ProcessFilter();
            }
        }

        public WeaponsRootViewModel Weapons { get; private set; }

        private IEnumerable<Tuple<string, IEnumerable<WeaponViewModel>>> recommendedWeapons;
        public IEnumerable<Tuple<string, IEnumerable<WeaponViewModel>>> RecommendedWeapons
        {
            get { return recommendedWeapons; }
            set { SetValue(ref recommendedWeapons, value); }
        }

        private void ProcessFilter()
        {
            if (Monsters == null)
                return;

            if (string.IsNullOrWhiteSpace(Filter))
            {
                foreach (var m in Monsters)
                    m.IsVisible = true;
            }
            else
            {
                var filters = Filter.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(f => string.IsNullOrWhiteSpace(f) == false)
                    .Select(f => f.ToLowerInvariant().Trim())
                    .ToArray();

                foreach (var m in Monsters)
                {
                    var name = m.Name.ToLowerInvariant();
                    m.IsVisible = filters.Any(f =>
                        {
                            if (f.StartsWith("="))
                                return name == f.Substring(1).Trim();
                            else
                                return name.Contains(f);
                        });
                }
            }

            var totals = new int[5];

            foreach (var monster in Monsters)
            {
                if (monster.IsVisible == false)
                    continue;

                for (var i = 0; i < totals.Length; i++)
                {
                    var elem = monster.Elements.FirstOrDefault(e => e.ElementName == ElementNames[i]);
                    if (elem != null)
                        totals[i] += elem.Value;
                }
            }

            TotalElements = CreateElements(totals);

            Weapons.SetElements(totals);
        }

        private void LoadMonsters()
        {
            var path = Path.GetFullPath("monsters");

            if (Directory.Exists(path) == false)
            {
                MessageBox.Show("The 'monsters' directory must exist and contains 'xml' files.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);

            var monsterList = new List<Monster>();

            foreach (var file in files.Where(x => Path.GetExtension(x) == ".xml"))
            {
                var doc = new XmlDocument();

                try
                {
                    doc.Load(file);
                    var nodes = doc.DocumentElement.ChildNodes
                        .OfType<XmlElement>();

                    foreach (var node in nodes)
                    {
                        var m = Monster.LoadMonster(node);
                        if (m != null &&
                            (m.FireWeakness > 0 || m.WaterWeakness > 0 || m.IceWeakness > 0 || m.ThunderWeakness > 0 || m.DragonWeakness > 0))
                            monsterList.Add(m);
                    }

                    Monsters = monsterList.Select(m => new MonsterViewModel(m)).ToArray();
                }
                catch (Exception ex)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Error loading 'monsters.xml' file.");
                    sb.AppendLine();
                    sb.AppendLine(ex.GetType().FullName);
                    sb.AppendLine(ex.Message);

                    MessageBox.Show(sb.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadWeapons()
        {
            var weaponList = new List<Weapon>();

            string[] filenames = null;

            var path = Path.GetFullPath("weapons");

            try
            {
                filenames = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Cannot retrieve weapon files.");
                sb.AppendLine();
                sb.AppendLine(ex.GetType().FullName);
                sb.AppendLine(ex.Message);

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Weapons = null;
                return;
            }

            foreach (var file in filenames.Where(x => Path.GetExtension(x) == ".xml"))
            {
                var doc = new XmlDocument();

                try
                {
                    doc.Load(file);
                    var nodes = doc.DocumentElement.ChildNodes
                        .OfType<XmlElement>();

                    foreach (var node in nodes)
                    {
                        var w = Weapon.LoadWeapon(node);
                        if (w != null)
                            weaponList.Add(w);
                    }
                }
                catch (Exception ex)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(string.Format("Error loading '{0}' file.", Path.GetFileName(file)));
                    sb.AppendLine();
                    sb.AppendLine(ex.GetType().FullName);
                    sb.AppendLine(ex.Message);

                    MessageBox.Show(sb.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            //weapons = weaponList.ToArray();
            Weapons = new WeaponsRootViewModel(weaponList);
        }

        public static ElementViewModel[] CreateElements(int[] elementsArray)
        {
            var max = elementsArray.Max();

            return elementsArray
                .Select((v, i) => new { Value = v, Index = i })
                .Where(item => item.Value > 0)
                .Select(item => new ElementViewModel(
                    ElementNames[item.Index],
                    item.Value))
                .OrderByDescending(evm => evm.Value)
                .ToArray();
        }

        public static double ComputePercent(int value, int max)
        {
            return Math.Round(value * 100.0 / max, 2);
        }
    }
}
