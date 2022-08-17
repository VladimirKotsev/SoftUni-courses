using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void TestConstructor()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.IsNotNull(heroRepository);
    }

    [Test]
    public void TestSetterOfCollection()
    {
        HeroRepository heroRepository = new HeroRepository();

        CollectionAssert.AreEqual(heroRepository.Heroes, new List<Hero>());
    }

    [Test]
    public void TestCreateMethod_Exception_NullHero()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void TestCreateMethod_Exception_HeroExists()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);

        },
        $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void TestCreateMethod_Successfull()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);

        string result = heroRepository.Create(hero);

        Assert.AreEqual(result, $"Successfully added hero {hero.Name} with level {hero.Level}");
        Assert.AreEqual(heroRepository.Heroes.Count, 1);

        CollectionAssert.AreEqual(heroRepository.Heroes, new List<Hero>() { hero });
    }

    [TestCase (null)]
    [TestCase ("")]
    [TestCase ("   ")]
    [TestCase ("          ")]
    public void TestRemoveMethod_Exception(string parameter)
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(parameter);
        });
    }

    [Test]
    public void TestRemoveMethod_ReturnsFalse()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);

        heroRepository.Create(hero);

        Assert.AreEqual(false, heroRepository.Remove("Rokie"));
        CollectionAssert.AreEqual (heroRepository.Heroes, new List<Hero>() { hero });
    }

    [Test]
    public void TestRemoveMethod_ReturnsTrue()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);
        Hero hero2 = new Hero("Spider-Man", 20);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Assert.AreEqual(true, heroRepository.Remove("Spider-Man"));
        Assert.AreEqual(1, heroRepository.Heroes.Count);
        CollectionAssert.AreEqual(heroRepository.Heroes, new List<Hero>() { hero });
    }

    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);
        Hero hero2 = new Hero("Spider-Man", 20);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Hero resultHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual (hero2, resultHero);
    }

    [Test]
    public void TestGetHero_NonExistingName()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Roockie", 10);

        heroRepository.Create(hero);

        Hero resultHero = heroRepository.GetHero("Spider-Man");

        Assert.AreEqual (null, resultHero);
    }

    [Test]
    public void TestGetHero_ExistingName()
    {
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Spider-Man", 10);

        heroRepository.Create(hero);

        Hero resultHero = heroRepository.GetHero("Spider-Man");

        Assert.AreEqual(hero, resultHero);
    }
}