using System;
using TestLibraryOne;
using TestLibraryTwo;

namespace TestLibraryThree
{
    public class TestObjects
    {
        public static Animal Whale = new Whale
        {
            Limbs = {
                    new Fin {  Length = 12.1m, Shiney = "shine"},
                    new Arm { Elbow = "bends", Hand = "None", Length = 12.5m}
                },
            BirthDate = new DateTime(2001, 12, 10),
            Genus = "Mammal",
            IsFlipper = false,
            Key = new Guid("4EE8C4BE-75CA-45E7-8333-D8655E2527A8"),
            Sex = Sex.Male,
            Species = "White Whale",
            Weight = 500.34m,
        };
        public static string whale = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Animal xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:type=""Whale"">
  <Genus>Mammal</Genus>
  <Sex>Male</Sex>
  <Weight>500.34</Weight>
  <Key>4ee8c4be-75ca-45e7-8333-d8655e2527a8</Key>
  <BirthDate>2001-12-10T00:00:00</BirthDate>
  <Species>White Whale</Species>
  <Limbs>
    <Limb xsi:type=""Fin"">
      <Length>12.1</Length>
      <Shiney>shine</Shiney>
    </Limb>
    <Limb xsi:type=""Arm"">
      <Length>12.5</Length>
      <Hand>None</Hand>
      <Elbow>bends</Elbow>
    </Limb>
  </Limbs>
  <IsFlipper>false</IsFlipper>
</Animal>";

        public static Animals Animals = new Animals
        {
            Herd = {
                new Human{
                    Limbs = {
                        new Arm { Hand = "Amputated"},
                        new Leg { Foot = "Gone"},
                        new Arm { Length = 12.12m},
                        new Leg { Knee = "Busted"},
                    },
                    FirstName = "Joe",
                    LastName = "Smith",
                },
                new Canine {
                    Name = "Rover",
                    Breed = "German Shepherd",
                    Sex = Sex.Male
                },
            }
        };

        public static string animals = @"<?xml version=""1.0"" encoding=""utf-16""?>
<Animals xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Herd>
    <Animal xsi:type=""Human"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs>
        <Limb xsi:type=""Arm"">
          <Length>0</Length>
          <Hand>Amputated</Hand>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Foot>Gone</Foot>
        </Limb>
        <Limb xsi:type=""Arm"">
          <Length>12.12</Length>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Knee>Busted</Knee>
        </Limb>
      </Limbs>
      <FirstName>Joe</FirstName>
      <LastName>Smith</LastName>
    </Animal>
    <Animal xsi:type=""Canine"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs />
      <Name>Rover</Name>
      <Breed>German Shepherd</Breed>
    </Animal>
  </Herd>
</Animals>";

        public static BionicAnimals BionicAnimals = new BionicAnimals
        {
            Herd = {
                new Human{
                    Limbs = {
                        new Arm { Hand = "Amputated"},
                        new Leg { Foot = "Gone"},
                        new Arm { Length = 12.12m},
                        new Leg { Knee = "Busted"},
                    },
                    FirstName = "Joe",
                    LastName = "Smith",
                },
                new Canine {
                    Name = "Rover",
                    Breed = "German Shepherd",
                    Sex = Sex.Male
                },
            },
            Parts =
            {
                new BionicArm { Manufacturer = "NextGen", ModelNumber="xyz21",},
                new BionicMan { FirstName = "Steve", LastName = "Austin", Sex = Sex.Male, Manufacturer = "Tv"},
                new BionicLeg { IsLeft = "not really", Manufacturer = "71234",},
            },
        };

        public static string bionicAnimals = @"<?xml version=""1.0"" encoding=""utf-16""?>
<BionicAnimals xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Herd>
    <Animal xsi:type=""Human"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs>
        <Limb xsi:type=""Arm"">
          <Length>0</Length>
          <Hand>Amputated</Hand>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Foot>Gone</Foot>
        </Limb>
        <Limb xsi:type=""Arm"">
          <Length>12.12</Length>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Knee>Busted</Knee>
        </Limb>
      </Limbs>
      <FirstName>Joe</FirstName>
      <LastName>Smith</LastName>
    </Animal>
    <Animal xsi:type=""Canine"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs />
      <Name>Rover</Name>
      <Breed>German Shepherd</Breed>
    </Animal>
  </Herd>
  <Parts>
    <Bionics xsi:type=""BionicArm"">
      <Manufacturer>NextGen</Manufacturer>
      <ModelNumber>xyz21</ModelNumber>
    </Bionics>
    <Bionics xsi:type=""BionicMan"">
      <Manufacturer>Tv</Manufacturer>
      <FirstName>Steve</FirstName>
      <LastName>Austin</LastName>
      <Sex>Male</Sex>
    </Bionics>
    <Bionics xsi:type=""BionicLeg"">
      <Manufacturer>71234</Manufacturer>
      <IsLeft>not really</IsLeft>
    </Bionics>
  </Parts>
</BionicAnimals>";

        public static BionicAnimals2 BionicAnimals2 = new BionicAnimals2
        {
            Herd = {
                new Human{
                    Limbs = {
                        new Arm { Hand = "Amputated"},
                        new Leg { Foot = "Gone"},
                        new Arm { Length = 12.12m},
                        new Leg { Knee = "Busted"},
                    },
                    FirstName = "Joe",
                    LastName = "Smith",
                },
                new Canine {
                    Name = "Rover",
                    Breed = "German Shepherd",
                    Sex = Sex.Male
                },
            },
            Parts =
            {
                new BionicArm { Manufacturer = "NextGen", ModelNumber="xyz21",},
                new BionicMan { FirstName = "Steve", LastName = "Austin", Sex = Sex.Male, Manufacturer = "Tv"},
                new BionicLeg { IsLeft = "not really", Manufacturer = "71234",},
            },
        };

        public static string bionicAnimals2 = @"<?xml version=""1.0"" encoding=""utf-16""?>
<BionicAnimals2 xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Herd>
    <Animal xsi:type=""Human"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs>
        <Limb xsi:type=""Arm"">
          <Length>0</Length>
          <Hand>Amputated</Hand>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Foot>Gone</Foot>
        </Limb>
        <Limb xsi:type=""Arm"">
          <Length>12.12</Length>
        </Limb>
        <Limb xsi:type=""Leg"">
          <Length>0</Length>
          <Knee>Busted</Knee>
        </Limb>
      </Limbs>
      <FirstName>Joe</FirstName>
      <LastName>Smith</LastName>
    </Animal>
    <Animal xsi:type=""Canine"">
      <Sex>Male</Sex>
      <Weight>0</Weight>
      <Key>00000000-0000-0000-0000-000000000000</Key>
      <BirthDate>0001-01-01T00:00:00</BirthDate>
      <Limbs />
      <Name>Rover</Name>
      <Breed>German Shepherd</Breed>
    </Animal>
  </Herd>
  <Parts>
    <Bionics xsi:type=""BionicArm"">
      <Manufacturer>NextGen</Manufacturer>
      <ModelNumber>xyz21</ModelNumber>
    </Bionics>
    <Bionics xsi:type=""BionicMan"">
      <Manufacturer>Tv</Manufacturer>
      <FirstName>Steve</FirstName>
      <LastName>Austin</LastName>
      <Sex>Male</Sex>
    </Bionics>
    <Bionics xsi:type=""BionicLeg"">
      <Manufacturer>71234</Manufacturer>
      <IsLeft>not really</IsLeft>
    </Bionics>
  </Parts>
</BionicAnimals2>";
    }
}