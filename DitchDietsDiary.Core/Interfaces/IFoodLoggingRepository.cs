using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitchDietsDiary.Core.Interfaces
{
    public interface IFoodLoggingRepository
    {
        void SaveMealEntry(FoodEntryModel foodEntryModel);
    }
}
