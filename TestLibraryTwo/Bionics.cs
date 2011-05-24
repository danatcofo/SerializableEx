using System;
using System.Xml.Serialization;
using TestLibraryOne;

namespace TestLibraryTwo
{
    [Serializable]
    [SerializableExtraType(typeof(Bionics))]
    public class BionicMan : Bionics
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Sex Sex { get; set; }
    }
}