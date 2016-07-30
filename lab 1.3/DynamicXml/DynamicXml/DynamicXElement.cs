using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement: DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }
        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name.Equals("AddMoons"))
            {
                return AddMoons(_element,out result);
            }
            else
            {
                //What happens if '_element.Element' returns null?
                dynamic e = _element.Element(binder.Name);
                result = new DynamicXElement(e);
                return e != null ? true : false;
            }
        }

        private bool AddMoons(XElement _element,out object result)
        {
            int i = 0;
            foreach (XElement x in _element.Elements())
            {
                foreach (XElement n in x.Elements("Moons"))
                {
                    n.AddFirst(new XElement("Moon"));
                    n.Element("Moon").Value = "Moon" + (++i);
                }
            }
            result = _element;
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {      
            if(!(indexes.Length == 2 && indexes[0] is string && indexes[1] is int))
            {
                //Very good! - consider 'System.ArgumentException'
                throw new Exception("Exception: Bad Indexes!!");
            }
            //What happens if '_element.Elements' returns an empty collection?
            var children = _element.Elements((string)indexes[0]);
            result = new DynamicXElement(children.ToArray().ElementAt((int)indexes[1]));
            return result != null ? true : false;
        }
        
        public override string ToString()
        {
            return _element.Value;
        }
    }
}
