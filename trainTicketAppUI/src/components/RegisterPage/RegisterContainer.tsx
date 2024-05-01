import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import { Avatar, Box, Grid, Paper, Typography } from "@mui/material";
import BackgroundImage from '../Backgorund/BackgroundImage';
import RegisterForm from "./RegisterForm";
import { useNavigate } from 'react-router-dom';
import { RegisterModel } from '../../models/RegisterModel';
import { useState } from 'react';

const RegisterContainer = () =>{
  const navigate = useNavigate();

  const [, setTokenInfo] = useState<{ value: string; expiry: Date | null }>({
    value: "",
    expiry: null,
  });

  // on submit validate data and create a new accout for user
  const onSubmit = async (data : any) => {
    try {
      const validatedProfile: RegisterModel = {
        firstName: data.firstName,
        lastName: data.lastName,
        email: data.email,
        password: data.password,
      }
      const response = await fetch(`https://localhost:7156/api/Security/Register`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(validatedProfile),
      });
      const responseData = await response.json();
      console.log(responseData)
      const { value, expiry } = responseData;
      localStorage.setItem("authToken", value);
      localStorage.setItem("authTokenExpiry", new Date(expiry).toISOString());
      setTokenInfo({ value: value, expiry: new Date(expiry) });
      navigate("/signIn");
    } catch (error) {
      alert("Email or password incorrect!");
    }
  }

    return(
        <>
      <Grid container component="main" sx={{ height: '100vh' }}>
      <BackgroundImage />
          <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
            <Box
              sx={{
                my: 8,
                mx: 4,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
              }}
             
            >
              <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                Register
              </Typography>
             <RegisterForm onSubmit={onSubmit}></RegisterForm>
            </Box>
          </Grid>
          </Grid>
  
    </>
    )
} 

export default RegisterContainer;