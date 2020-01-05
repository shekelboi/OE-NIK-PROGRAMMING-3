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
    using Languages.Logic.Logics;
    using Languages.Repository;

    [TestFixture]
    class Test
    {
        /// <summary>
        /// Testing get all.
        /// </summary>
        [Test]
        public void TestLanguagesByDifficulty()
        {
            Mock<ILanguageLogic> mock = new Mock<ILanguageLogic>();
            List<QLanguagesByDifficulty> l = new List<QLanguagesByDifficulty>()
            {
                new QLanguagesByDifficulty("Easy", 1),
                new QLanguagesByDifficulty("Hard", 4),
            };

            Mock<IRepository<language>> mLang = new Mock<IRepository<language>>();

            List<language> langList = new List<language>()
            {
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Easy" },
            };

            mLang.Setup(m => m.GetAll()).Returns(langList.AsQueryable());

            ILogic<language> il = new LanguageLogic(mLang.Object);
            ILanguageLogic il2 = new LanguageLogic(mLang.Object);

            Assert.That(il.GetAll().Where(x => x.difficulty == "Hard").Count() == 4);
            Assert.That(il2.LanguagesByDifficulty().Where(x => x.Difficulty == "Hard").First().Sum == 4);
        }

        /// <summary>
        /// Testing adding a country.
        /// </summary>
        [Test]
        public void RemoveCountry()
        {
            Mock<IRepository<country>> mock = new Mock<IRepository<country>>();

            mock.Setup(m => m.GetAll()).Returns(new List<country>()
            {
                new country { name = "test1" },
                new country { name = "test2" },
                new country { name = "test3" },
                new country { name = "test4" },
                new country { name = "test5" },
            }.AsQueryable());

            ILogic<country> il = new CountryLogic(mock.Object);

            il.Insert(new country { name = "test6" });
            Logic.DB.SaveChanges();

            Assert.That(il.GetOne(6).name == "test6");
        }

        /// <summary>
        /// Testing removing a language.
        /// </summary>
        [Test]
        public void RemoveLanguageTest()
        {
            Mock<IRepository<language>> mock = new Mock<IRepository<language>>();

            mock.Setup(m => m.GetAll()).Returns(new List<language>()
            {
                new language { id = 1, name = "test1" },
                new language { id = 2, name = "test2" },
                new language { id = 3, name = "test3" },
                new language { id = 4, name = "test4" },
                new language { id = 5, name = "test5" },
            }.AsQueryable());

            ILogic<language> il = new LanguageLogic(mock.Object);

            Console.WriteLine(il.GetAll().First().id);
            Assert.That(il.GetOne(5) != null);

            il.Remove(il.GetAll().Last().id);
            Logic.DB.SaveChanges();

            Console.WriteLine(il.GetAll().First().id);
            Assert.That(il.GetOne(5) is null);
        }
    }
}