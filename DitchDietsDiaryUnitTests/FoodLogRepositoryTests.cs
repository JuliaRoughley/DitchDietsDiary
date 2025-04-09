using DitchDietsDiary.Core;
using DitchDietsDiary.Infrastructure.Repositories;

namespace DitchDietsDiaryUnitTests
{
    public class FoodLogRepositoryTests
    {
        [Fact]
        public void SaveMealEntry_StoresDataCorrectly()
        {
            //Arrange
            var foodLogRepository = new FoodLoggingRepository();
            var foodEntry = new FoodEntryModel
            {
                FoodEntry = "Bacon avocado sandwich",
                TimeEaten = DateTime.Now,
                PreMealHungerLevel = 1,
                PostMealFullnessLevel = 8,
                Mood = 9
            };

            var foodEntryRequest = new FoodEntryRequestModel
            {
                FoodEntryId = 1
            };

            // Act
            foodLogRepository.SaveMealEntry(foodEntry);

            //Assert
            var storedEntry = foodLogRepository.GetMealEntry(foodEntryRequest); 
            Assert.NotNull(storedEntry);
            Assert.Equal(foodEntry.FoodEntry, storedEntry.FoodEntry);
            Assert.Equal(foodEntry.TimeEaten, storedEntry.TimeEaten);
            Assert.Equal(foodEntry.PreMealHungerLevel, storedEntry.PreMealHungerLevel);
            Assert.Equal(foodEntry.PostMealFullnessLevel, storedEntry.PostMealFullnessLevel);
            Assert.Equal(foodEntry.Mood, storedEntry.Mood);
        }
    }
}
