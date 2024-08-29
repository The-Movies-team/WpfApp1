using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using System.IO;
using WpfApp1.Models;

namespace WpfApp1.Tests
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private readonly string testFilePath = "test_movies.csv";

        [TestInitialize]
        public void Setup()
        {
            // Ensure the test file is deleted before each test
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [TestMethod]
        public void TestSaveAndReadFromFile()
        {
            // Arrange
            var movieRepository = new MovieRepository();
            var moviesToSave = new ObservableCollection<Movie>
            {
                new Movie { Title = "Inception", Duration = 148, Genre = "Sci-Fi" },
                new Movie { Title = "The Matrix", Duration = 136, Genre = "Action" }
            };

            // Act
            movieRepository.SaveToFile(moviesToSave);

            var moviesRead = new ObservableCollection<Movie>();
            movieRepository.ReadFromFile(moviesRead);

            // Assert
            Assert.AreEqual(moviesToSave.Count, moviesRead.Count);
            for (int i = 0; i < moviesToSave.Count; i++)
            {
                Assert.AreEqual(moviesToSave[i].Title, moviesRead[i].Title);
                Assert.AreEqual(moviesToSave[i].Duration, moviesRead[i].Duration);
                Assert.AreEqual(moviesToSave[i].Genre, moviesRead[i].Genre);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up the test file after each test
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }
    }
}