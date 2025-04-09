using DitchDietsDiary.Core;
using DitchDietsDiary.Infrastructure.Data;
using DitchDietsDiary.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DitchDietsDiaryUnitTests
{
    public class FoodLogRepositoryTests
    {
        [Fact]
        public void GetMealEntry_WithFilters_ReturnsCorrectData()
        {
            // Arrange: Set up an in-memory database
            var options = new DbContextOptionsBuilder<FoodLoggingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var dbContext = new FoodLoggingDbContext(options);

            dbContext.FoodEntries.Add(new FoodEntryModel
            {
                FoodEntryId = 1,
                FoodEntry = "Bacon avocado sandwich",
                TimeEaten = new DateTime(2025, 4, 9),
                PreMealHungerLevel = 1,
                PostMealFullnessLevel = 8,
                Mood = 9
            });
            dbContext.FoodEntries.Add(new FoodEntryModel
            {
                FoodEntryId = 2,
                FoodEntry = "Burger",
                TimeEaten = new DateTime(2025, 4, 10),
                PreMealHungerLevel = 4,
                PostMealFullnessLevel = 6,
                Mood = 7
            });
            dbContext.SaveChanges();

            var repository = new FoodLoggingRepository(dbContext);

            // Act
            var request = new FoodEntryRequestModel
            {
                FoodSearchTerm = "Bacon",
                DateOfFoodEntry = new DateTime(2025, 4, 9)
            };

            var result = repository.GetMealEntry(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.FoodEntryId);
            Assert.Contains("Bacon", result.FoodEntry);
            Assert.Equal(new DateTime(2025, 4, 9), result.TimeEaten);
            Assert.Equal(1, result.PreMealHungerLevel);
            Assert.Equal(8, result.PostMealFullnessLevel);
            Assert.Equal(9, result.Mood);
        }
    }
}
