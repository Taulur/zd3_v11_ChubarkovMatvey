using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AirplaneQuality()
        {
            Airplane airplane = new Airplane("Вертолет", 1952, 5, 10, 2.5);
            airplane.SetQuality();
            Assert.AreEqual(20, airplane.Quality);
        }
        [TestMethod]
        public void SpecialQuality()
        {
            SpecialAirplane airplane = new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5, 10);
            airplane.SetQuality();
            Assert.AreEqual(1 / 1.3 * 10, airplane.Quality);
        }

        [TestMethod]
        public void AirplaneGetInfo()
        {
            Airplane airplane = new Airplane("Вертолет", 1952, 5, 10, 2.5);
            airplane.SetQuality();
            Assert.AreEqual("Вертолет,1952,5,10,2,5,20", airplane.GetInfo());
        }
        [TestMethod]
        public void SpecialGetInfo()
        {
            SpecialAirplane airplane = new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5,10);
            airplane.SetQuality();
            Assert.AreEqual($"Вертолет,1952,5,10,2,5,{1/1.3*10},10", airplane.GetInfo());
        }
        [TestMethod]
        public void Add1()
        {
            List<Airplane> expected = new List<Airplane>();
            expected.Add(new Airplane("Вертолет", 1952, 5, 10, 2.5));


            Company now = new Company();
            List<Airplane> list = now.GetAirplaneList();
            now.AddAirplane("Вертолет", 1952, 5, 10, 2.5);


            Assert.AreEqual(list[0].GetInfo(), expected[0].GetInfo());
        }
        [TestMethod]
        public void Add2()
        {
            List<Airplane> expected = new List<Airplane>();
            expected.Add(new Airplane("Вертолет", 1952, 5, 10, 2.5));


            Company now = new Company();
            List<Airplane> list = now.GetAirplaneList();
            Airplane airplane = new Airplane("Вертолет", 1952, 5, 10, 2.5);
            now.AddAirplane(airplane);


            Assert.AreEqual(list[0].GetInfo(), expected[0].GetInfo());
        }
        [TestMethod]
        public void Add3()
        {
            Dictionary<string, SpecialAirplane> expected = new Dictionary<string, SpecialAirplane>();
            expected.Add("Вертолет",new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5, 10));


            Company now = new Company();
            Dictionary<string, SpecialAirplane> list = now.GetAirplaneDictionary();
            SpecialAirplane airplane = new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5, 10);
            now.AddAirplane(airplane.Name,airplane);


            Assert.AreEqual(list["Вертолет"].GetInfo(), expected["Вертолет"].GetInfo());
        }
        [TestMethod]
        public void Remove1()
        {
            Company expected = new Company();
            expected.AddAirplane("Вертолет", 1952, 5, 10, 2.5);
           

            Company company = new Company();
            Airplane airplane = new Airplane("Самолет", 1952, 5, 10, 2.5);
            company.AddAirplane(airplane);
            company.AddAirplane("Вертолет", 1952, 5, 10, 2.5);
            company.RemoveAirplane(airplane);

            Assert.AreEqual(company.GetAirplaneList()[0].GetInfo(), expected.GetAirplaneList()[0].GetInfo());
        }
        [TestMethod]
        public void Remove2()
        {
            Company expected = new Company();
            expected.AddAirplane("Вертолет", 1952, 5, 10, 2.5);


            Company company = new Company();
            company.AddAirplane("Самолет", 1952, 5, 10, 2.5);
            company.AddAirplane("Вертолет", 1952, 5, 10, 2.5);
            company.RemoveAirplane(0);

            Assert.AreEqual(company.GetAirplaneList()[0].GetInfo(), expected.GetAirplaneList()[0].GetInfo());
        }
        [TestMethod]
        public void Remove3()
        {
            Company expected = new Company();
            SpecialAirplane airplane = new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5, 10);
            expected.AddAirplane(airplane.Name,airplane);


            Company company = new Company();
            SpecialAirplane airplane1 = new SpecialAirplane("Самолет", 1952, 5, 10, 2.5, 10);
            company.AddAirplane(airplane1.Name, airplane1);
            SpecialAirplane airplane2 = new SpecialAirplane("Вертолет", 1952, 5, 10, 2.5, 10);
            company.AddAirplane(airplane2.Name, airplane2);
            company.RemoveAirplane(airplane1.Name);

            Assert.AreEqual(company.GetAirplaneDictionary()["Вертолет"].GetInfo(), expected.GetAirplaneDictionary()["Вертолет"].GetInfo());
        }


    }
}
