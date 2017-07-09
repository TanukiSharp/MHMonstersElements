using PresentationToolKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHMonstersElements.ViewModels
{
    public class ElementViewModel : ViewModelBase
    {
        public string ElementName { get; private set; }
        public string ImagePath { get; private set; }
        public int Value { get; private set; }

        public ElementViewModel(string elementName, int value)
        {
            ElementName = elementName;
            ImagePath = string.Format("images\\common\\{0}.png", elementName);
            Value = value;
        }
    }
}
