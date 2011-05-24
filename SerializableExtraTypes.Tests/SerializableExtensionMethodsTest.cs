using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibraryOne;
using TestLibraryThree;

namespace SerializableExtraTypes.Tests
{
    /// <summary>
    ///This is a test class for SerializableExtensionMethodsTest and is intended
    ///to contain all SerializableExtensionMethodsTest Unit Tests
    ///</summary>
    [TestClass(), System.Runtime.InteropServices.GuidAttribute("0242E3D8-F7EB-4AC2-B78A-948D1B1EC2BD")]
    public class SerializableExtensionMethodsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion Additional test attributes

        #region SerializeEx

        /// <summary>
        ///A test for SerializeEx
        ///</summary>
        public void SerializeExTestHelper<T>(T obj, string expected)
        {
            string actual = SerializableExtensionMethods.SerializeEx<T>(obj);
            Assert.AreEqual(expected, actual);
        }

        public void SerializeExTestHelper<T>(T obj, string expected, params Type[] root)
        {
            string actual = SerializableExtensionMethods.SerializeEx<T>(obj, root);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SerializeExTest()
        {
            SerializeExTestHelper<Animal>(TestObjects.Whale, TestObjects.whale);
        }

        [TestMethod()]
        public void SerializeExTest_DifferentRoot()
        {
            SerializeExTestHelper(TestObjects.Animals, TestObjects.animals, typeof(Animal));
        }

        [TestMethod]
        public void SerializeExTest_MulitRoots()
        {
            SerializeExTestHelper(TestObjects.BionicAnimals, TestObjects.bionicAnimals, typeof(Animal), typeof(Bionics));
        }

        [TestMethod]
        public void SerializeExTest_3LevelsDeep()
        {
            SerializeExTestHelper(TestObjects.BionicAnimals2, TestObjects.bionicAnimals2);
        }

        #endregion SerializeEx

        #region DeserializeEx

        /// <summary>
        ///A test for DeserializeEx
        ///</summary>
        public void DeserializeExTestHelper<T>(T expected, string xml)
        {
            string actual;
            actual = SerializableExtensionMethods.DeserializeEx<T>(xml).SerializeEx();
            Assert.AreEqual(xml, actual);
        }

        public void DeserializeExTestHelper<T>(T expected, string xml, params Type[] root)
        {
            string actual;
            actual = SerializableExtensionMethods.DeserializeEx<T>(xml, root).SerializeEx(root);
            Assert.AreEqual(xml, actual);
        }

        [TestMethod]
        public void DeserializeExTest()
        {
            DeserializeExTestHelper(TestObjects.Whale, TestObjects.whale);
        }

        [TestMethod()]
        public void DeserializeExTest_DifferentRoot()
        {
            SerializeExTestHelper(TestObjects.Animals, TestObjects.animals, typeof(Animal));
        }

        [TestMethod]
        public void DeserializeExTest_MulitRoots()
        {
            DeserializeExTestHelper(TestObjects.BionicAnimals, TestObjects.bionicAnimals, typeof(Animal), typeof(Bionics));
        }

        [TestMethod]
        public void DeserializeExTest_3LevelsDeep()
        {
            DeserializeExTestHelper(TestObjects.BionicAnimals2, TestObjects.bionicAnimals2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DeserializeExTest_MismatchType()
        {
            DeserializeExTestHelper(TestObjects.BionicAnimals, TestObjects.bionicAnimals2);
        }

        #endregion DeserializeEx
    }
}