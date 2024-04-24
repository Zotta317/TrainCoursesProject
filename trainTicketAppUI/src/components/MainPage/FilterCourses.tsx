import { FormControl, Grid, InputLabel, MenuItem, Select } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import dayjs, { Dayjs } from "dayjs";
import React, { useEffect, useState } from "react";
import { CourseView } from "../../models/CourseView";
import ShowCourses from "./ShowCourses";

export default function FilterCourses() {

  const cities = ["Cluj-Napoca", "Brasov", "Bucuresti", "Iasi", "Oradea", "Galati", "Suceava"]
  const [selectedCurrentCity, setSelectedCurrentCity] = useState<string>("Cluj-Napoca");
  const [selectedDestinationCity, setSelectedDestinationCity] = useState<string>("");
  const [dateValue, setdateValue] = React.useState<Dayjs | null>(dayjs());
  const [courseViews, setCourseViews] = useState<CourseView[]>([]);
  const token = localStorage.getItem("authToken");
  const handleDateChange = (newValue: Dayjs | null) => {
    setdateValue(newValue);
  }
  const [selectedLeavingTime, setSelectedLeavingTime] = React.useState<String | undefined>('2024-03-28T17:13:36');

  const filteredCities = cities.filter(city => city !== selectedCurrentCity);
  console.log(courseViews)

  const [boughtTicket,setBougthTicket] = useState(false);
  useEffect(() => {
    const fetchData = async () => {
      try {
        let url = `https://localhost:7156/api/Course/GetCourseByDate/${selectedLeavingTime}?arrivingCity=${selectedDestinationCity}&leavingCity=${selectedCurrentCity}`;
        const response = await fetch(url, {
          method: "Get",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });

        if (!response.ok) {
          throw new Error('Network response was not ok');
        }

        const data = await response.json();
        setCourseViews(data);
        setBougthTicket(false)
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };
    fetchData();
  }, [selectedCurrentCity, selectedDestinationCity, selectedLeavingTime,boughtTicket])

  useEffect(() => {
    const formattedDate = dateValue?.format("YYYY-MM-DDTHH:mm:ss")
    setSelectedLeavingTime(formattedDate);
  }
    , [dateValue])

  return (
    <>
      <Grid container spacing={2} marginLeft={83}>
        <Grid item xs={3}>

          <FormControl
            fullWidth>
            <InputLabel id="demo-simple-select-label">City</InputLabel>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={selectedCurrentCity}
              label="City"
              onChange={(event) => { setSelectedCurrentCity(event.target.value), setSelectedDestinationCity("") }}
            >
              {cities?.map((city: String, index: number) => (
                <MenuItem key={index} value={cities[index]}>
                  {city}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={3} >
          <FormControl fullWidth>
            <LocalizationProvider dateAdapter={AdapterDayjs}>
              <DatePicker
                label="Date"
                value={dateValue}
                onChange={handleDateChange}
                minDate={dayjs()}
              />
            </LocalizationProvider>
          </FormControl>
        </Grid>

        <Grid item xs={3}>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-label">City</InputLabel>
            <Select
              disabled={selectedCurrentCity === ""}
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={selectedDestinationCity}
              label="City"
              onChange={(event) => setSelectedDestinationCity(event.target.value)}
            >
              {filteredCities?.map((city: String, index: number) => (
                <MenuItem key={index} value={city.toString()}>
                  {city}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

        </Grid>
      </Grid>
      <ShowCourses courseViews={courseViews} boughtTicket = {boughtTicket} setBoughtTicket ={setBougthTicket} ></ShowCourses>
    </>
  )
}