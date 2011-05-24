using System;
using System.Xml.Serialization;

namespace TestLibraryOne
{
    [Serializable]
    [SerializableExtraType(typeof(Bionics))]
    public abstract class Bionics
    {
        public string Manufacturer { get; set; }
    }

    [Serializable]
    public class BionicArm : Bionics
    {
        public string ModelNumber { get; set; }
    }

    [Serializable]
    public class BionicLeg : Bionics
    {
        public string IsLeft { get; set; }
    }
}