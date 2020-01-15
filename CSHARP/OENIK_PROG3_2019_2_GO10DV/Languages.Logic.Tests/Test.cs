// <copyright file="Test.cs" company="Barta Zoltán Kevin">
// Copyright (c) Barta Zoltán Kevin. All rights reserved.
// </copyright>

namespace Languages.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// Testing the  query.
        /// </summary>
        [Test]
        public void TestNumberOfSpeakers()
        {
            Mock<IRepository<language>> mLang = new Mock<IRepository<language>>();

            List<language> langList = new List<language>()
            {
                new language() { difficulty = "Hard", number_of_speakers = 100 },
                new language() { difficulty = "Hard", number_of_speakers = 100 },
                new language() { difficulty = "Hard", number_of_speakers = 100 },
                new language() { difficulty = "Hard", number_of_speakers = 100 },
                new language() { difficulty = "Easy", number_of_speakers = 100 },
                new language() { difficulty = "Easy", number_of_speakers = 100 },
            };

            mLang.Setup(m => m.GetAll()).Returns(langList.AsQueryable());

            ILogic<language> il = new LanguageLogic(mLang.Object);
            ILanguageLogic il2 = new LanguageLogic(mLang.Object);

            var actualResults = il2.NumberOfSpeakers();

            foreach (var item in actualResults)
            {
                Console.WriteLine(item.Difficulty + "  " + item.NumberOfSpeakers);
            }

            var expectedResults = new List<QNumberOfSpeakers>()
            {
                new QNumberOfSpeakers("Hard", 400),
                new QNumberOfSpeakers("Easy", 200),
            };

            // Assert
            for (int i = 0; i < actualResults.ToList().Count; i++)
            {
                Assert.That(actualResults.ToList()[i].Difficulty == expectedResults[i].Difficulty);
                Assert.That(actualResults.ToList()[i].NumberOfSpeakers == expectedResults[i].NumberOfSpeakers);
            }
        }

        /// <summary>
        /// Testing the LanguagesByDifficulty() query.
        /// </summary>
        [Test]
        public void TestLanguagesByDifficulty()
        {
            Mock<IRepository<language>> mLang = new Mock<IRepository<language>>();

            List<language> langList = new List<language>()
            {
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Hard" },
                new language() { difficulty = "Easy" },
                new language() { difficulty = "Easy" },
            };

            mLang.Setup(m => m.GetAll()).Returns(langList.AsQueryable());

            ILogic<language> il = new LanguageLogic(mLang.Object);
            ILanguageLogic il2 = new LanguageLogic(mLang.Object);

            var actualResults = il2.LanguagesByDifficulty();

            foreach (var item in actualResults)
            {
                Console.WriteLine(item.Difficulty + "  " + item.Sum);
            }

            var expectedResults = new List<QLanguagesByDifficulty>()
            {
                new QLanguagesByDifficulty("Hard", 4),
                new QLanguagesByDifficulty("Easy", 2),
            };

            // Assert
            for (int i = 0; i < actualResults.ToList().Count; i++)
            {
                Assert.That(actualResults.ToList()[i].Difficulty == expectedResults[i].Difficulty);
                Assert.That(actualResults.ToList()[i].Sum == expectedResults[i].Sum);
            }
        }

        /// <summary>
        /// Testing the LanguageFamilies() query.
        /// </summary>
        [Test]
        public void TestLanguageFamilies()
        {
            Mock<IRepository<language>> mLang = new Mock<IRepository<language>>();
            Mock<IRepository<language_family>> mLangFam = new Mock<IRepository<language_family>>();
            Mock<IRepository<langfam_lang_link>> mLink = new Mock<IRepository<langfam_lang_link>>();

            List<language> langList = new List<language>()
            {
                new language() { id = 1, name = "lang1" },
                new language() { id = 2, name = "lang2" },
                new language() { id = 3, name = "lang3" },
                new language() { id = 4, name = "lang4" },
                new language() { id = 5, name = "lang5" },
                new language() { id = 6, name = "lang6" },
            };

            List<language_family> langfamList = new List<language_family>()
            {
                new language_family() { id = 1, name = "fam1" },
                new language_family() { id = 2, name = "fam2" },
                new language_family() { id = 3, name = "fam3" },
            };

            List<langfam_lang_link> linkList = new List<langfam_lang_link>()
            {
                new langfam_lang_link { id = 1, lang_id = 1, langfam_id = 1 },
                new langfam_lang_link { id = 2, lang_id = 2, langfam_id = 2 },
                new langfam_lang_link { id = 3, lang_id = 3, langfam_id = 2 },
                new langfam_lang_link { id = 4, lang_id = 4, langfam_id = 2 },
                new langfam_lang_link { id = 5, lang_id = 5, langfam_id = 3 },
                new langfam_lang_link { id = 6, lang_id = 6, langfam_id = 3 },
            };

            mLang.Setup(m => m.GetAll()).Returns(langList.AsQueryable());
            mLangFam.Setup(m => m.GetAll()).Returns(langfamList.AsQueryable());
            mLink.Setup(m => m.GetAll()).Returns(linkList.AsQueryable());

            ILanguageLogic il1 = new LanguageLogic(mLang.Object);

            List<QLanguageFamilies> expectedResults = new List<QLanguageFamilies>()
            {
                new QLanguageFamilies("lang1", "fam1"),
                new QLanguageFamilies("lang2", "fam2"),
                new QLanguageFamilies("lang3", "fam2"),
                new QLanguageFamilies("lang4", "fam2"),
                new QLanguageFamilies("lang5", "fam3"),
                new QLanguageFamilies("lang6", "fam3"),
            };

            var actualResults = il1.LanguageFamiliesForTesting(mLang.Object, mLink.Object, mLangFam.Object);

            // Assert
            for (int i = 0; i < actualResults.ToList().Count; i++)
            {
                Assert.That(actualResults.ToList()[i].Language_name == expectedResults[i].Language_name);
                Assert.That(actualResults.ToList()[i].Langfam_name == expectedResults[i].Langfam_name);
            }
        }

        /// <summary>
        /// Testing the Modify() query on a country's population.
        /// </summary>
        /// <param name="value">Values to test.</param>
        [Test]
        [Sequential]
        public void ModifyCountryTest([Values(100)] int value)
        {
            Mock<IRepository<country>> mock = new Mock<IRepository<country>>(MockBehavior.Loose);

            mock.Setup(m => m.GetAll()).Returns(new List<country>()
            {
                new country { id = 1, population = 2343231 },
                new country { id = 2, population = 89495665 },
                new country { id = 3, population = 56195615 },
                new country { id = 4, population = 9619819 },
                new country { id = 5, population = 56115656 },
            }.AsQueryable());

            ILogic<country> il = new CountryLogic(mock.Object);
            il.Modify(1, value);
            mock.Verify(m => m.Modify(1, value));
        }

        /// <summary>
        /// Testing the Remove() query on a language.
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

            il.Remove(1);
            mock.Verify(m => m.Remove(1));
        }

        /// <summary>
        /// Testing the Insert() query on a language family.
        /// </summary>
        [Test]
        public void AddLanguageFamilyTest()
        {
            language_family lf = new language_family()
            {
                id = 4,
                name = "prog3",
            };

            Mock<IRepository<language_family>> mock = new Mock<IRepository<language_family>>();

            mock.Setup(m => m.GetAll()).Returns(new List<language_family>()
            {
                new language_family { id = 1, name = "test1" },
                new language_family { id = 2, name = "test2" },
                new language_family { id = 3, name = "test3" },
            }.AsQueryable());

            ILogic<language_family> il = new LanguageFamilyLogic(mock.Object);

            il.Insert(lf);
            mock.Verify(m => m.Insert(lf));
        }

        /// <summary>
        /// Testing all the data GetAll().
        /// </summary>
        [Test]
        public void SelectAllDataTest()
        {
            Mock<IRepository<country>> mock = new Mock<IRepository<country>>();
            country c = new country
            {
                id = 1,
                population = 100,
            };
            mock.Setup(m => m.GetAll()).Returns(new List<country>()
            {
                new country { id = 1, population = 100 },
                new country { id = 2, population = 200 },
                new country { id = 3, population = 300 },
            }.AsQueryable());

            ILogic<country> il = new CountryLogic(mock.Object);

            Assert.That(il.GetAll().Sum(x => x.population) == 600);
        }

        /// <summary>
        /// Testing the GetOne() method.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        [Test]
        [Sequential]
        public void SelectOne([Values(5)] int id)
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

            object temp = il.GetOne(id);
            mock.Verify(m => m.GetOne(id));
        }
    }
}