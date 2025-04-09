namespace DitchDietsDiary.Core
{
    public class FoodEntryModel
    {
        public int FoodEntryId { get; set; }
        public string FoodEntry { get; set; } = string.Empty;
        public DateTime TimeEaten { get; set; } = DateTime.UtcNow;
        public  int PreMealHungerLevel {get; set; }
        public int PostMealFullnessLevel { get; set; }
        public int Mood {  get; set; }
    }
}
