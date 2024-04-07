import { Box, FormControl, InputLabel, MenuItem, Select, TextField, Typography } from "@mui/material";
import NavigationBar from "./NavigationBar";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import dayjs from "dayjs";
import { useEffect, useState } from "react";

export default function CoursesPage() {
    const cities = ["Cluj-Napoca", "Brasov", "Bucuresti", "Iasi", "Oradea", "Galati", "Suceava"]
    const [selectedCurrentCity, setSelectedCurrentCity] = useState<string>("");
    const [selectedDestinationCity, setSelectedDestinationCity] = useState<string>("");

    const filteredCities = cities.filter(city => city !== selectedCurrentCity);
    const token = localStorage.getItem("authToken");
  
    useEffect(() => {
        const fetchGetPlatform = async () => {
            try {
                let url = `https://localhost:7156/api/Platform/GetPlatform?leavingCity=${selectedCurrentCity}`
                const response = await fetch(url, {
                    method: "Get",
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });

                if(!response.ok){
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                
            }catch (error) {
      console.error('Error fetching data:', error);
    }
        }
    })
    return (
        <>
            <NavigationBar />
            <Box sx={{
                display: 'flex',
                justifyContent: 'center',
                flexDirection: "column",
                marginTop: 10,
                mt: 2

            }}>
                <Typography
                    variant="h3"
                    sx={{ color: "blue", alignSelf: "center" }}
                >
                    Add Course
                </Typography>

                <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                    <InputLabel id="demo-simple-select-label">Leaving City</InputLabel>
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

                <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                    <InputLabel id="demo-simple-select-label">Destination City</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={selectedDestinationCity}
                        label="City"
                        disabled={selectedCurrentCity === ""}
                        onChange={(event) => { setSelectedDestinationCity(event.target.value) }}
                    >
                        {filteredCities?.map((city: String, index: number) => (
                            <MenuItem key={index} value={cities[index]}>
                                {city}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>

                =                <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            label="Date Picker"
                            format="YYYY/MM/DD"
                            defaultValue={dayjs()}
                        />
                    </LocalizationProvider>
                </FormControl>

            </Box>
        </>
    )
}