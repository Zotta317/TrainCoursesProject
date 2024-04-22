import { AppBar, Box, Button, CssBaseline, Toolbar, Typography } from "@mui/material"
import { useEffect, useState } from "react";
import { Profile } from "../../models/Profile";
import { useNavigate } from "react-router-dom";
import Logout from "../LogOut";

export default function NavigationBar() {
  

  const [userProfile, setUserProfile] = useState<Profile | null>(null);
  const navigate = useNavigate();

  //get user profile in order to see if it's an admin or quest
  useEffect(() => {
    const fetchUserProfile = async () => {
      try {
        const token = localStorage.getItem("authToken");
        if (!token) {
          throw new Error("Authentication token not found in localStorage");
        }
        const response = await fetch(
          "https://localhost:7156/api/Profile/GetProfile/Users",
          {
            method: "GET",
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        if (!response.ok) {
          throw new Error("Network response was not ok");
        }

        const data = await response.json();
        setUserProfile(data);
        console.log(data);
      } catch (error) {
        console.error("Unknown error occurred:", error);
      }
    };
    fetchUserProfile();
  }, []);

  // redirecting user to next page once everything is all filled
  const handleLogout = () => {
    Logout();
    console.log("SEr");
    navigate("/signIn");
  };
  return (
    <>
      <Box sx={{ display: 'flex',marginBottom : 10 }}>
        <CssBaseline />
        <AppBar component="nav">
          <Toolbar>
            <Box sx={{ display: { xs: 'none', sm: 'block' } }}>
              
                <Button onClick={() => navigate("/MainPage")} sx={{ color: '#fff' }}>
                  Home
                </Button>
                <Button  sx={{ color: '#fff' }}>
                  Events
                </Button> 
                {userProfile?.isAdmin ? (<Button onClick={() => navigate("/CoursesPage")} sx={{ color: '#fff' }}>Courses</Button>) : (<Typography/>)}
              
           
            </Box>
            <Typography
              variant="h6"
              component="div"
              sx={{ flexGrow: 2, display: { xs: 'none', sm: 'block' } }}
            >
              </Typography>
            
            <Box sx={{ display: { xs: 'none', sm: 'block' } }}>
           
              <Button sx={{ color: '#fff' }} onClick ={() => navigate("/ProfilePage")} >
                Profile
              </Button>
              <Button sx={{ color: '#fff' }} onClick = {handleLogout}>
                Log Out
              </Button>

            </Box>
          </Toolbar>
        </AppBar>
      </Box>
    </>
  )
}
