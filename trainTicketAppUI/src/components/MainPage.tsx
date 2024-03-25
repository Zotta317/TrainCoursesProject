import { Box, Button, Divider, FormControl, Grid, InputLabel, MenuItem, Modal, Select, Stack, Typography } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import React, { useEffect, useState } from "react";
import { json, useNavigate } from "react-router-dom";
import { Course } from "../models/Course";
import NavigationBar from "./NavigationBar";

const style = {
  position: 'absolute' as 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 500,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

export default function MainPage() {

  const cities = ["Cluj-Napoca", "Brasov", "Bucuresti", "Iasi", "Oradea", "Galati", "Suceava"]
  const [selectedDestinationCity, setSelectedDestinationCity] = useState<string>("");
  const [selectedCurrentCity, setSelectedCurrentCity] = useState<string>("Cluj-Napoca");
  // const navigate = useNavigate();
  
  const token = localStorage.getItem("authToken");

  const [courseViews, setCourseViews] = useState<Course[]>([])

  //filter courses based on user's preferences
  const selectedCity: Course[] = courseViews
    ? courseViews.filter((course) => course?.leavingCity == selectedCurrentCity && (!selectedDestinationCity || course?.arrivingCity == selectedDestinationCity))
      .map((courseViews: Course) => ({
        courseID: courseViews.courseID,
        arrivingCity: courseViews.arrivingCity,
        leavingCity: courseViews.leavingCity,
        arrivingDate: courseViews.arrivingDate,
        leavingDate: courseViews.leavingDate,
        availableTrainSeats: courseViews.availableTrainSeats,
        trainName: courseViews.trainName,
        trainType: courseViews.trainType
      })) : [];

  //filter cities in case user has't set a destination city
  const filteredCities = cities.filter(city => city !== selectedCurrentCity) ;

  const [openCourseIdForPurchase, setOpenCourseIdForPurchase] = useState<
    string | null
  >(null);

  //open modal por purchasing ticket
  const handleOpenPurchaseTicket = (courseId: string) => {
    setOpenCourseIdForPurchase(courseId);
  };

  //close modal for purchasing ticket
  const handleClosePurchaseTicket = () => setOpenCourseIdForPurchase(null);


  //insert into database new ticket based on selected course
  //available seats will be decreasead by 1
  const fetchAddTicket = async () => {

    console.log(openCourseIdForPurchase)
    try {
      let url = `https://localhost:7156/api/Ticket/PostTicket/AddTicket?courseId=${openCourseIdForPurchase}`;

      const response = await fetch(url, {
        method: "Post",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }


    } catch (error) {
      console.error('Error fetching data:', error);
    }
    setOpenCourseIdForPurchase(null)
  };

  //get all courses from database
  useEffect(() => {
    const fetchData = async () => {
      try {
        let url = "https://localhost:7156/api/Course/GetAllCourses/GetAllreservations";
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

      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();


  })
  return (
    <>
      <NavigationBar />

      <Box
        sx={{
          flexGrow: 1,
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          flexDirection: "column",
        }}
      >
        <Grid container spacing={2} margin={10} marginLeft={83}>

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
        {selectedCity?.length === 0 ? (
          <Typography variant="h6" color="textSecondary" sx={{ mt: 20 }}>
            No courses found. All the trains are busy
          </Typography>
        ) : (
          selectedCity?.map((courseView: Course) => (
            <React.Fragment key={courseView?.courseID}>

              <Box marginTop={6}>
                <Stack
                  direction="row"
                  spacing={5}
                  divider={<Divider orientation="vertical" flexItem />}
                  sx={{
                    backgroundColor: "rgba(3, 138, 255)",
                    padding: "10px",
                    borderRadius: "4px",
                  }}>
                  <Stack direction="column">
                    <Typography
                      variant="h6"
                      marginRight={20}
                      alignItems="center"
                      color={"white"}
                    >
                      {courseView?.leavingCity}
                    </Typography>
                    <Typography
                      color={"white"}
                      variant="h6"
                      sx={{
                        fontSize: 13,
                        marginRight: 30,
                      }}
                    >
                      Leaving Date : {courseView?.leavingDate ? new Date(courseView.leavingDate).toLocaleString() : ""}
                    </Typography>
                  </Stack>
                  <Stack direction="column">
                    <Typography
                      variant="h6"
                      marginRight={20}
                      alignItems="center"
                      color={"white"}
                    >
                      {courseView?.arrivingCity}
                    </Typography>
                    <Typography
                      variant="h6"
                      color={"white"}
                      sx={{
                        fontSize: 13,
                        marginRight: 30,
                      }}
                    >
                      Arival Date : {courseView?.arrivingDate ? new Date(courseView.arrivingDate).toLocaleString() : ""}
                    </Typography>
                  </Stack>
                  <Stack direction="row" alignItems="center" spacing={10}>
                    <Stack direction="column" gap={2}>
                      <Typography
                        variant="h6"
                        sx={{ fontSize: 15, marginTop: 2, color: "white" }}

                      >
                        TrainType:
                        HighSpeed
                      </Typography>
                      <Typography
                        variant="h6"
                        sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                      >
                        Available tickets : {courseView?.availableTrainSeats}
                      </Typography>
                    </Stack>
                    <Stack direction="column" gap={2}>
                      <Typography
                        variant="h6"
                        sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                      >
                        Train Model:
                        {courseView.trainName}
                      </Typography>
                      <Typography
                        variant="h6"
                        sx={{
                          fontSize: 15,
                          marginTop: 2,
                          color: "white",
                        }}
                      >
                        Stops : 0
                      </Typography>
                    </Stack>
                    <Stack direction="column" alignItems="center" gap={2}>
                      <Typography
                        variant="h6"
                        sx={{ fontSize: 15, marginTop: 2 }}
                      ></Typography>
                      <Box >
                        <Button
                          style={{ color: 'white' }}
                          onClick={() => handleOpenPurchaseTicket(courseView?.courseID)}
                          disabled ={courseView?.availableTrainSeats === 0}>
                          Buy ticket
                        </Button>
                        <Modal
                          open={openCourseIdForPurchase === courseView?.courseID}
                          onClose={handleClosePurchaseTicket}
                          aria-labelledby="modal-modal-title"
                          aria-describedby="modal-modal-description"
                        >
                          <Box sx={style}>
                            <Typography
                              id="modal-modal-title"
                              variant="h5"
                              component="h2"
                            >
                              Buy Ticket
                            </Typography>
                            <Typography
                              id="modal-modal-description"
                              sx={{ mt: 2 }}
                            >
                              Please confirm your purchase.
                            </Typography>
                            <Box sx={{ marginTop: 4 }} gap={5} >
                              <Button variant="contained" onClick={handleClosePurchaseTicket}>Cancel</Button>
                              <Button key={courseView.courseID} variant="contained" onClick={fetchAddTicket}>Confirm</Button>
                            </Box>


                          </Box>
                        </Modal>
                      </Box>
                    </Stack>
                  </Stack>
                </Stack>
              </Box>
            </React.Fragment>))
        )}
      </Box>

    </>
  )
}

