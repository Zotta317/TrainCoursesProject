import { Box, FormControl, InputLabel, MenuItem, Select, Typography } from "@mui/material";
import { DatePicker, LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import NavigationBar from "../NavigationBar/NavigationBar";
import { TrainCourse } from "../../models/TrainCourse";

export default function CoursesPage() {
    const cities = ["Cluj-Napoca", "Brasov", "Bucuresti", "Iasi", "Oradea", "Galati", "Suceava"]
    const [selectedCurrentCity, setSelectedCurrentCity] = useState<string>("");
    const [selectedDestinationCity, setSelectedDestinationCity] = useState<String>("");

    const [leavingCityPeron, setLeavingCityPeron] = useState<string[]>();
    const [destinationCityPeron, setDestinationCityPeron] = useState<string[]>();

    const [leavingPeron, setLeavingPeron] = useState<String>();
    const [destinationPeron, setDestinationPeron] = useState<String>();

    const [trainCourses,setTrainCourses] = useState<TrainCourse[] | undefined>();

    const[train,setTrain] = useState<string>();

    const filteredCities = cities.filter(city => city !== selectedCurrentCity);
    const token = localStorage.getItem("authToken");

    useEffect(() => {
        if (selectedCurrentCity != "")
            fetchGetPlatform(selectedCurrentCity).then((platforms) => {
                setLeavingCityPeron(platforms);
            });

        if (selectedDestinationCity != "")
            fetchGetPlatform(selectedDestinationCity).then((platforms) => {
                setDestinationCityPeron(platforms);
            });
    }, [selectedCurrentCity, selectedDestinationCity]);




    const fetchGetPlatform = async (city: String) => {

        try {
            let url = `https://localhost:7156/api/Platform/GetPlatformsByCity/${city}`
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
            return data;

        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }
    const fetchGetTrains = async () => {

        try {
            let url = `https://localhost:7156/api/TrainCourse/GetTrainCourseByCity/${selectedCurrentCity}`
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
            setTrainCourses(data);

        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }

    useEffect(() =>{
        if (selectedCurrentCity != "")
            fetchGetTrains();
    },[selectedCurrentCity]
    )

    console.log()

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
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={leavingPeron}
                    label="Peron"
                    onChange={(event) => { setLeavingPeron(event.target.value) }}
                    disabled={selectedCurrentCity === ""}
                >
                    {leavingCityPeron?.map((peron: string, index: number) => (
                        <MenuItem key={index} value={peron}>
                            {peron}
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
                    disabled={leavingPeron === undefined}
                    onChange={(event) => { setSelectedDestinationCity(event.target.value) }}
                >
                    {filteredCities?.map((city: String, index: number) => (
                        <MenuItem key={index} value={filteredCities[index]}>
                            {city}
                        </MenuItem>
                    ))}
                </Select>
            </FormControl>

            <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                <Select
                    labelId="demo-simple-select-label"
                    id="demo-simple-select"
                    value={destinationPeron}
                    label="Peron"
                    onChange={(event) => { setDestinationPeron(event.target.value) }}
                    disabled={selectedDestinationCity === ""}
                >
                    {destinationCityPeron?.map((peron: string, index: number) => (
                        <MenuItem key={index} value={peron[index]}>
                            {peron}
                        </MenuItem>
                    ))}
                </Select>
            </FormControl>

            <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                <LocalizationProvider dateAdapter={AdapterDayjs}>
                    <DatePicker
                        label="Date Picker"
                        format="YYYY/MM/DD"
                        defaultValue={dayjs()}
                        disabled={leavingPeron == null}
                    />
                </LocalizationProvider>
            </FormControl>

            <FormControl sx={{ width: '50ch', alignSelf: "center", marginTop: 3 }}>
                    
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={train}
                        label="Peron"
                        disabled={leavingPeron == null}
                        onChange={(event) => { setTrain(event.target.value) }}
                    >
                        {trainCourses?.map((trainCourse: TrainCourse, index: number) => (
                            <MenuItem key={index} value={trainCourse?.trainName}>
                                {trainCourse?.trainName}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>
        </Box>
    </>
)
}