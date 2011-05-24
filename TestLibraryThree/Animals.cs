using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TestLibraryOne;

namespace TestLibraryThree
{
    [Serializable]
    public class Animals
    {
        private List<Animal> _Herd = new List<Animal>();

        public List<Animal> Herd { get { return _Herd; } }
    }

    [Serializable]
    public class BionicAnimals
    {
        private List<Animal> _Herd = new List<Animal>();
        private List<Bionics> _Parts = new List<Bionics>();

        public List<Animal> Herd { get { return _Herd; } }

        public List<Bionics> Parts { get { return _Parts; } }
    }

    [SerializableExtraType(typeof(Animal), typeof(Bionics))]
    public class BionicAnimals2
    {
        private List<Animal> _Herd = new List<Animal>();
        private List<Bionics> _Parts = new List<Bionics>();

        public List<Animal> Herd { get { return _Herd; } }

        public List<Bionics> Parts { get { return _Parts; } }
    }
}