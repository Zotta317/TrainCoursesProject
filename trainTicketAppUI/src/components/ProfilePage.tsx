import { Box, Divider, Stack, TextField, Typography } from "@mui/material";
import NavigationBar from "./NavigationBar";
import { TicketView } from "../models/TicketView";
import { useEffect, useState } from "react";
import React from "react";

export default function ProfilePage() {

    const [ticketViews, setTicketViews] = useState<TicketView[]>([]);
    const token = localStorage.getItem("authToken");

    //get all user tickets
    useEffect(() => {
        const fetchDataTicket = async () => {
            try {
                let url = "https://localhost:7156/api/Ticket/GetUserTickets/AllUserTickets"

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
                setTicketViews(data);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        }

        fetchDataTicket();
    })

    return (
        <>
            <NavigationBar />
            <Box
            marginTop={10}
                sx={{
                    flexGrow: 1,
                    display: "flex",
                    alignItems: "center",
                    justifyContent: "center",
                    flexDirection: "column",
                }}
            >

                {ticketViews?.length === 0 ? (
                    <Typography variant="h6" color="textSecondary" sx={{ mt: 20 }}>
                        You have no tickets.
                    </Typography>
                ) : (
                    ticketViews?.map((ticketView: TicketView,index : number) => (
                        <React.Fragment key={ticketView?.ticketID ?? index}>
                            <Box marginTop={5}>
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
                                            
                                            Leaving City:  {ticketView?.leavingCity}
                                           
                                        </Typography>
                                        <Typography
                                            color={"white"}
                                            variant="h6"
                                            sx={{
                                                fontSize: 13,
                                                marginRight: 30,
                                            }}
                                        >
                                            Leaving Time : {ticketView?.leavingTime ? new Date(ticketView.leavingTime).toLocaleString() : ""}
                                        </Typography>
                                        <Typography
                                        color={"white"}
                                        variant="h6"
                                        sx={{
                                            fontSize: 13,
                                            marginRight: 30,
                                            
                                        }}>
                                            {"\n"+ticketView?.firstName + " " + ticketView?.lastName }
                                        </Typography>
                                    </Stack>
                                    <Stack direction="column">
                                        <Typography
                                            variant="h6"
                                            marginRight={20}
                                            alignItems="center"
                                            color={"white"}
                                        >
                                            Arriving City : {ticketView?.arrivingCity}
                                        </Typography>


                                        <Typography
                                            variant="h6"
                                            color={"white"}
                                            sx={{
                                                fontSize: 13,
                                                marginRight: 30,
                                            }}
                                        >
                                            Arival Time : {ticketView?.arrivingTime ? new Date (ticketView.arrivingTime).toLocaleString() : ""}
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
                                                Train:
                                                {ticketView.trainName}
                                            </Typography>
                                        </Stack>
                                        <Stack direction="column" gap={2}>
                                            <Typography
                                                variant="h6"
                                                sx={{ fontSize: 15, marginTop: 2, color: "white" }}
                                            >
                                                Carrige:
                                                {ticketView?.carrigeName}
                                            </Typography>
                                            <Typography
                                                variant="h6"
                                                sx={{
                                                    fontSize: 15,
                                                    marginTop: 2,
                                                    color: "white",
                                                }}
                                            >
                                                Seat:
                                                {ticketView?.seatName}
                                            </Typography>
                                        </Stack>
                                        <Stack direction="column" alignItems="center" gap={2}>
                                            <Typography
                                                variant="h6"
                                                sx={{ fontSize: 15, marginTop: 2 }}
                                            ></Typography>
                                            <Box >
                                            </Box>
                                        </Stack>
                                    </Stack>
                                </Stack>
                            </Box>

                        </React.Fragment>
                    ))
                )
                }
            </Box>
        </>
    )
}


