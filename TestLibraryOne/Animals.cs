using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestLibraryOne
{

    [Serializable]
    [SerializableExtraType(typeof(Animal), typeof(Limb))]
    public abstract class Animal
    {
        public string Genus { get; set; }
        public Sex Sex { get; set; }
        public decimal Weight { get; set; }
        public Guid Key { get; set; }
        public DateTime BirthDate { get; set; }
    }

    [Serializable]
    public abstract class Mammal : Animal
    {
        public string Species { get; set; }

        private List<Limb> _Limbs = new List<Limb>();

        public List<Limb> Limbs { get { return _Limbs; } }
    }

    [Serializable]
    public class Human : Mammal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    [Serializable]
    public class Canine : Mammal
    {
        public string Name { get; set; }
        public string Breed { get; set; }
    }

    [Serializable]
    [SerializableExtraType(typeof(Animal), typeof(Limb))]
    public abstract class Limb
    {
        public decimal Length { get; set; }
    }

    [Serializable]
    public class Arm : Limb
    {
        public string Hand { get; set; }
        public string Elbow { get; set; }
    }

    [Serializable]
    public class Leg : Limb
    {
        public string Foot { get; set; }
        public string Knee { get; set; }
    }

    public enum Sex
    {
        Male,
        Female,
    }
}
