import { Box, Button, Divider, Stack, Typography } from "@mui/material";
import React, { useState } from "react";
import { CourseView } from "../../models/CourseView";
import BuyTicket from "./BuyTicket";

interface coursesViewsProps {
  courseViews: CourseView[];
  boughtTicket : boolean;
  setBoughtTicket : (boughtTciket : boolean) => void;
}
export default function showCourses({ courseViews,boughtTicket,setBoughtTicket}: coursesViewsProps) {

  console.log(courseViews)
  const [openCourseIdForPurchase, setOpenCourseIdForPurchase] = useState<string | null>(null);

  return (
    <>
      {courseViews?.length === 0 ? (
        <Typography variant="h6" color="textSecondary" sx={{ mt: 20 }}>
          No courses found. All the trains are busy
        </Typography>
      ) : (
        courseViews?.map((courseView: CourseView) => (
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
                    Leaving Date : {courseView?.leavingTime ? new Date(courseView.leavingTime).toLocaleString() : ""}
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
                    Arival Date : {courseView?.arivingTime ? new Date(courseView.arivingTime).toLocaleString() : ""}
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
                        disabled={courseView?.numberOfSeatsAvailable === 0}>
                        Buy ticket
                      </Button>
                      <BuyTicket
                        courseId={courseView?.courseID}
                        openCourseIdForPurchase={openCourseIdForPurchase}
                        setOpenCourseIdForPurchase={setOpenCourseIdForPurchase}
                        boughtTicket = {boughtTicket} setBoughtTicket ={setBoughtTicket}
                      /></Box>
                  </Stack>
                </Stack>
              </Stack>
            </Box>
          </React.Fragment>))
      )}
    </>
  )
}