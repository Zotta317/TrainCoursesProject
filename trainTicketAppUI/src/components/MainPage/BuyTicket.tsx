import { Box, Button, Divider, Modal, Stack, Typography } from "@mui/material";
import { useState } from "react";

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

export default function BuyTicket(courseId: any) {

    const [openCourseIdForPurchase, setOpenCourseIdForPurchase] = useState<
        string | null
    >(null);

    const fetchAddTicket = async () => {

        const token = localStorage.getItem("authToken");
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
    return (
        <>
            <Modal
                open={openCourseIdForPurchase === courseId}
                onClose={() => setOpenCourseIdForPurchase(null)}
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
                        <Button variant="contained" onClick={() => setOpenCourseIdForPurchase(courseId)}>Cancel</Button>
                        <Button key={courseId} variant="contained" onClick={fetchAddTicket}>Confirm</Button>
                    </Box>
                </Box>
            </Modal>
        </>
    )
}