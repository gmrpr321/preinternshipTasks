
const form = document.getElementById("weatherForm");
const cityInput = document.getElementById("cityInput");
const weatherResult = document.getElementById("weatherResult");
const cityName = document.getElementById("cityName");
const temperature = document.getElementById("temperature");
const humidity = document.getElementById("humidity");
const condition = document.getElementById("condition");
const error = document.getElementById("error");

const API_KEY = "294db704158a02e99fcbe4959848bf52"; 

form.addEventListener("submit", async (e) => {
  e.preventDefault();
  const city = cityInput.value.trim();
  if (!city) return;

  try {
    const response = await fetch(
      `https://api.openweathermap.org/data/2.5/weather?q=${encodeURIComponent(city)}&units=metric&appid=${API_KEY}`
    );

    if (!response.ok) {
      throw new Error("City not found");
    }

    const data = await response.json();
    cityName.textContent = data.name;
    temperature.textContent = data.main.temp;
    humidity.textContent = data.main.humidity;
    condition.textContent = data.weather[0].description;

    weatherResult.classList.remove("hidden");
    error.classList.add("hidden");
  } catch (err) {
    weatherResult.classList.add("hidden");
    error.textContent = err.message;
    error.classList.remove("hidden");
  }
});
