
import React, { useEffect, useState } from 'react';
import axios from 'axios';


const Weather = () => {

    const [city, setCity] = useState('');
    const [weatherData, setWeatherData] = useState({
        city: "",
        country: "",
        latitude: 0,
        longitude: 0,
        temperature: 0,
        weather_description: "",
        humidity: 0,
        wind_speed: 0,
        forecast: []
    });

  const fetchData = async () => {
    try {
      const response = await axios.get(
        `https://freetestapi.com/api/v1/weathers?search=`+city
      );
      setWeatherData(response.data[0]);
      console.log(response.data); //You can see all the weather data in console log
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleInputChange = (e: any) => {
    setCity(e.target.value);
  };

  const handleSubmit = (e: any) => {
    e.preventDefault();
    fetchData();
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Enter city name"
          value={city}
          onChange={handleInputChange}
        />
        <button type="submit">Get Weather</button>
      </form>
      {weatherData ? (
        <>
            <h2>{weatherData.city}</h2>
            <p>Country: {weatherData.country}</p>
            <p>Latitude: {weatherData.latitude}</p>
            <p>Longitude : {weatherData.longitude}</p>
            <p>Temperature : {weatherData.temperature}°C</p>
            <p>Description : {weatherData.weather_description}</p>
            <p>Humidity : {weatherData.humidity}</p>
            <p>Wind Speed : {weatherData.wind_speed}m/s</p>

        </>
      ) : (
        <p>Loading weather data...</p>
      )}
    </div>
  );
};

export default Weather;