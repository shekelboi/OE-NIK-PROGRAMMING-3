// <copyright file="Test.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Languages.Data;
    using Languages.Logic;
    using Languages.Logic.Logics;
    using Languages.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class.
    /// </summary>
    [TestFixture]
    public class Test
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
            Mock<IRepository<language>> mock = new Mock<IRepository<language>>(MockBehavior.Loose);

            IQueryable<language> l = new List<language>()
            {
                new language { id = 1, name = "test1" },
                new language { id = 2, name = "test2" },
                new language { id = 3, name = "test3" },
                new language { id = 4, name = "test4" },
                new language { id = 5, name = "test5" },
            }.AsQueryable();
            mock.Setup(x => x.GetAll()).Returns(l);

            ILogic<language> il = new LanguageLogic(mock.Object);
            mock.Object.Remove(1);
            Console.WriteLine(il.GetAll().First().name);
            Assert.That(il.GetAll().First().name == "test2");
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