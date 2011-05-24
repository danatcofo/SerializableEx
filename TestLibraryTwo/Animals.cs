using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestLibraryOne;
using System.Xml.Serialization;

namespace TestLibraryTwo
{
    [Serializable]
    [SerializableExtraType(typeof(Animal), typeof(Limb))]
    public class Whale : Mammal
    {
        public bool IsFlipper { get; set; }
    }

    [Serializable]
    [SerializableExtraType(typeof(Animal), typeof(Limb))]
    public class Fin : Limb
    {
        public string Shiney { get; set; }
    }
}
