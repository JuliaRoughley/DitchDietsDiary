namespace DitchDietsDiary.Core
{
    public class FoodEntryRequestModel
    {
        public int FoodEntryId { get; set; }
        public DateTime? DateOfFoodEntry { get; set; }
        public string FoodSearchTerm { get; set; } = string.Empty;
    }
}
