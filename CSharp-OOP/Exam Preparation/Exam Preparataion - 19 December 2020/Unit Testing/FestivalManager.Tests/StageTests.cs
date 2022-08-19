namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Stage stage = new Stage();

            Assert.IsNotNull(stage);
        }


        [Test]
        public void TestSettersAndGetters()
        {
            Stage stage = new Stage();

            Assert.AreEqual(stage.Performers, new List<Performer>());
        }

        [Test]
        public void TestAddPerformer_Exception_OnValidation()
        {
            Stage stage = new Stage();
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(performer);
            });
        }

        [Test]
        public void TestAddPerformer_Exception_NotMature()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Vladko", "Kotsev", 17);

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(performer);
            },
            "You can only add performers that are at least 18.");
        }

        [Test]
        public void TestAddPerformer()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Vladko", "Kotsev", 19);
            stage.AddPerformer(performer);

            CollectionAssert.AreEqual(new List<Performer>() { performer }, stage.Performers);
            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void TestAddSong_Exception_OnValidation()
        {
            Stage stage = new Stage();
            Song song = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(song);
            });
        }

        [Test]
        public void TestAddSong_Exception_TooShortOfASong()
        {
            Stage stage = new Stage();
            Song song = new Song("Bumble bee", TimeSpan.FromSeconds(55));

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song);
            }, 
            "You can only add songs that are longer than 1 minute.");
        }

        [Test]
        public void TestAddSongMethod()
        {
            Stage stage = new Stage();
            Song song = new Song("Bumble bee", TimeSpan.FromMinutes(3.3));

            stage.AddSong(song);

            Type type = typeof(Stage);
            FieldInfo field = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == "Songs");

            List<Song> actual = field.GetValue(stage) as List<Song>;
            List<Song> expected = new List<Song>() { song };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestCase (null)]
        public void AddSongToPerformer_Exception_SongNull(string parameter)
        {
            Stage stage = new Stage();
            Performer performer = new Performer("First", "Lasst", 20);
            Song song = null;

            stage.AddPerformer(performer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(parameter, "First");
            });
        }

        [TestCase (null)]
        public void AddSongToPerformer_Exception_PerformerNull(string parameter)
        {
            Stage stage = new Stage();
            Performer performer = new Performer("First", "Lasst", 20);
            Song song = new Song("Song", TimeSpan.FromMinutes(3.2));

            stage.AddSong(song);

            stage.AddPerformer(performer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer("Song", parameter);
            });
        }

        [Test]
        public void TestAddSongToPerformerMethod()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("First", "Last", 20);
            Song song = new Song("Song", TimeSpan.FromMinutes(3.2));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            string result = stage.AddSongToPerformer("Song", "First Last");

            Assert.AreEqual(result, $"{song} will be performed by {performer}");
            Assert.AreEqual(performer.SongList.Count, 1);
            CollectionAssert.AreEqual(new List<Song>() { song }, performer.SongList);
        }

        [Test]
        public void TestPlayMethod()
        {
            Stage stage = new Stage();
            Performer performer1 = new Performer("First", "Last", 20);
            Song song1 = new Song("Song", TimeSpan.FromMinutes(3.2));
            stage.AddSong(song1);
            stage.AddPerformer(performer1);
            stage.AddSongToPerformer("Song", "First Last");

            Performer performer2 = new Performer("Last", "First", 50);
            Song song2 = new Song("Another Song", TimeSpan.FromMinutes(5));
            Song song3 = new Song("Yet another Song", TimeSpan.FromMinutes(3));
            stage.AddSong(song2);
            stage.AddSong(song3);
            stage.AddPerformer(performer2);

            stage.AddSongToPerformer("Another Song", "Last First");
            stage.AddSongToPerformer("Yet another Song", "Last First");

            string result = stage.Play();

            Assert.AreEqual(result, $"2 performers played 3 songs");

        }

    }
}