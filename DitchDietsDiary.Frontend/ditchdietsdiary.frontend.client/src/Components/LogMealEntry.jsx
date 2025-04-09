import React, { useState } from "react";

function LogMealEntry() {
    const [mealData, setMealData] = useState({
        foodEntry: "",
        timeEaten: "",
        preMealHungerLevel: 5,
        postMealFullnessLevel: 5,
        Mood: 3
    });

    const [message, setMessage] = useState("");

    const handleChange = (e) => {
        const { name, value } = e.target;
        setMealData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("https://localhost:44333/api/foodLog", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(mealData),
            });

            if (response.ok) {
                setMessage("Meal logged successfully!");
                setMealData({
                    foodEntry: "",
                    timeEaten: "",
                    preMealHungerLevel: 5,
                    postMealFullnessLevel: 5,
                    mood: 3,
                });
            }
            else {
                const error = await response.text();
                setMessage(`Error: ${error}`);
            }
        } catch (error) {
            setMessage("An error occurred. Please try again.");
        }
    };

    return (
        <div>
            <h1>Log Meal Entry</h1>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Food Entry: </label>
                    <input
                        type="text"
                        name="foodEntry"
                        value={mealData.foodEntry}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Time Eaten: </label>
                    <input
                        type="datetime-local"
                        name="timeEaten"
                        value={mealData.timeEaten}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Pre-Meal Hunger Level (0-10): </label>
                    <input
                        type="number"
                        name="preMealHungerLevel"
                        value={mealData.preMealHungerLevel}
                        onChange={handleChange}
                        min="0"
                        max="10"
                        required
                    />
                </div>
                <div>
                    <label>Post-Meal Fullness Level (0-10): </label>
                    <input
                        type="number"
                        name="postMealFullnessLevel"
                        value={mealData.postMealFullnessLevel}
                        onChange={handleChange}
                        min="0"
                        max="10"
                        required
                    />
                </div>
                <div>
                    <label>Mood (1-5): </label>
                    <input
                        type="number"
                        name="mood"
                        value={mealData.mood}
                        onChange={handleChange}
                        min="1"
                        max="5"
                        required
                    />
                </div>
                <button type="submit">Log Meal</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
}

export default LogMealEntry;