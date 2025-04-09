using DitchDietsDiary.Core;
using DitchDietsDiary.Core.Interfaces;
using DitchDietsDiary.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DitchDietsDiary.Infrastructure.Repositories
{
    public class FoodLoggingRepository : IFoodLoggingRepository
    {
        private readonly FoodLoggingDbContext _dbContext;

        public FoodLoggingRepository(FoodLoggingDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public FoodEntryModel GetMealEntry(FoodEntryRequestModel foodEntryRequest)
        {
            if (foodEntryRequest == null) throw new ArgumentNullException(nameof(foodEntryRequest));

            // Start building the query
            var query = _dbContext.FoodEntries.AsQueryable();

            if (foodEntryRequest.FoodEntryId > 0)
            {
                query = query.Where(e => e.FoodEntryId == foodEntryRequest.FoodEntryId);
            }
            // Filter by date if provided
            if (foodEntryRequest.DateOfFoodEntry.HasValue)
            {
                query = query.Where(e => e.TimeEaten.Date == foodEntryRequest.DateOfFoodEntry.Value.Date);
            }

            // Filter by search term if provided
            if (!string.IsNullOrWhiteSpace(foodEntryRequest.FoodSearchTerm))
            {
                query = query.Where(e => e.FoodEntry.Contains(foodEntryRequest.FoodSearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            // Return the first matching result or null
            return query.FirstOrDefault();

        }

        public void SaveMealEntry(FoodEntryModel foodEntryModel)
        {
            if (foodEntryModel == null)
            {
                throw new ArgumentNullException(nameof(foodEntryModel));
            }

            // Add the entry to the DbSet
            _dbContext.FoodEntries.Add(foodEntryModel);

            // Save changes to the database
            _dbContext.SaveChanges();
        }
    }
}
