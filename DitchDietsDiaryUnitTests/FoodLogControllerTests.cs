using DitchDietsDiary.Controllers;
using DitchDietsDiary.Core;
using DitchDietsDiary.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace DitchDietsDiaryUnitTests
{
    [TestFixture]
    public class FoodLogControllerTests
    {
        [Fact]
        public void LogMealEntry_PersistsMealEntry()
        {
            //Arrange
            var mockPersistenceHandling = new Mock<IFoodLoggingRepository>();
            var mockLogging = new Mock<ILogger<FoodLogController>>();
            var foodLogController = new FoodLogController(mockLogging.Object, mockPersistenceHandling.Object);

            var foodEntry = new FoodEntryModel
            {
                FoodEntry = "New string of food entry",
                TimeEaten = DateTime.UtcNow,
                PreMealHungerLevel = 4,
                PostMealFullnessLevel = 8,
                Mood = 7
            };

            //Act
            foodLogController.LogMealEntry(foodEntry);

            // Assert
            mockPersistenceHandling.Verify(repo => repo.SaveMealEntry(It.Is<FoodEntryModel>(m =>
                m.FoodEntry == foodEntry.FoodEntry && // Use == for comparison
                m.TimeEaten == foodEntry.TimeEaten && // Use == for comparison
                m.PreMealHungerLevel == foodEntry.PreMealHungerLevel && // Use == for comparison
                m.PostMealFullnessLevel == foodEntry.PostMealFullnessLevel && // Use == for comparison
                m.Mood == foodEntry.Mood // Use == for comparison
            )), Times.Once, "The meal entry was not persisted as expected.");
        }
    }
}