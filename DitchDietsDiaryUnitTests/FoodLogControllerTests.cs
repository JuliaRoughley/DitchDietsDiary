using DitchDietsDiary.Controllers;
using DitchDietsDiary.Core;
using DitchDietsDiary.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace DitchDietsDiaryUnitTests
{
    public class FoodLogControllerTests
    {
        [Fact]
        public void LogMealEntry_CallsRepositoryWithCorrectData()
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
                m.FoodEntry == foodEntry.FoodEntry && 
                m.TimeEaten == foodEntry.TimeEaten && 
                m.PreMealHungerLevel == foodEntry.PreMealHungerLevel && 
                m.PostMealFullnessLevel == foodEntry.PostMealFullnessLevel && 
                m.Mood == foodEntry.Mood 
            )), Times.Once, "The meal entry was not persisted as expected.");
        }
    }
}