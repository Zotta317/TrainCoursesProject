import { Box, Button, Divider, Modal, Stack, Typography } from "@mui/material";
import { useState } from "react";
import { CourseView } from "../../models/CourseView";
import React from "react";
import BuyTicket from "./BuyTicket";

export default function showCourses({selectedCity} : any) {
    
    const [, setOpenCourseIdForPurchase] = useState<
    string | null
  >(null);
  
       return (
        <>
         {selectedCity?.length === 0 ? (
          <Typography variant="h6" color="textSecondary" sx={{ mt: 20 }}>
            No courses found. All the trains are busy
          </Typography>
        ) : (
          selectedCity?.map((courseView: CourseView) => (
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
                      Leaving Date : {courseView?.leavingTime ? new Date(courseView.arrivingTime).toLocaleString() : ""}
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
                      Arival Date : {courseView?.arrivingTime ? new Date(courseView.arrivingTime).toLocaleString() : ""}
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
                        Available tickets : {courseView?.numberOfSeatsAvailable}
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
                          onClick={() => setOpenCourseIdForPurchase(courseView?.courseID)}
                          disabled ={courseView?.numberOfSeatsAvailable === 0}>
                          Buy ticket
                        </Button>
                       <BuyTicket courseId ={courseView?.courseID}></BuyTicket>
                      </Box>
                    </Stack>
                  </Stack>
                </Stack>
              </Box>
            </React.Fragment>))
        )}
        </>
    )
}