namespace Languages.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Languages.Data;
    using Languages.Logic;
    using Languages.Repository;

    [TestFixture]
    class Test
    {
        [Test]
        public void TestGetAll()
        {
            Mock<ILogic> mock = new Mock<ILogic>();

            mock.Setup(x => x.LanguageFamilies()).Returns(new List<QLanguageFamilies>());
            List<country> countries = new List<country>();
            countries.Add(new country() { area = 12345678, capital = "Ulaanbaatar", continent = "Asia", name = "Mongolia", population = 3500000, });

            Assert.AreEqual(1, 1);
        }
    }
}
