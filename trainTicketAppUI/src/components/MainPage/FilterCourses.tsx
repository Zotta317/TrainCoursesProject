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
  const [leavingCity, setleavingCity] = useState<string>("Cluj-Napoca");
  const [arrivingCity, setarrivingCity] = useState<string>("");
  const [dateValue, setdateValue] = React.useState<Dayjs | null>(dayjs());
  const [courseViews, setCourseViews] = useState<CourseView[]>([]);
  const token = localStorage.getItem("authToken");
  const handleDateChange = (newValue: Dayjs | null) => {
    setdateValue(newValue);
  }
  const [date, setDate] = React.useState<String | undefined>('2024-03-28T17:13:36');

  const filteredCities = cities.filter(city => city !== leavingCity);
  console.log(courseViews)

  const [boughtTicket,setBougthTicket] = useState(false);

  const fetchData = async () => {
    try {
      let url = `https://localhost:7156/api/TrainCourse/GetTrainCourseByDate/${date}?arrivingCity=${arrivingCity}&leavingCity=${leavingCity}`;
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

  useEffect(() => {

    fetchData();
  }, [leavingCity, arrivingCity, date,boughtTicket])

  useEffect(() => {
    const formattedDate = dateValue?.format("YYYY-MM-DDTHH:mm:ss")
    setDate(formattedDate);
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
              value={leavingCity}
              label="City"
              onChange={(event) => { setleavingCity(event.target.value), setarrivingCity("") }}
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
              disabled={leavingCity === ""}
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={arrivingCity}
              label="City"
              onChange={(event) => setarrivingCity(event.target.value)}
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