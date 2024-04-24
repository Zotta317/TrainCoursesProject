import { Avatar, Box, Grid, Paper, Typography } from '@mui/material';
import { LockOutlined as LockOutlinedIcon } from '@mui/icons-material';
import SignInForm from './SignInForm';
import BackgroundImage from '../Backgorund/BackgroundImage';
import { useNavigate } from 'react-router-dom';
import { SignInModel } from '../../models/SignInModel';
import { useState } from 'react';

const SignInContainer = () => {

  const navigate = useNavigate();
  const [, setTokenInfo] = useState<{ value: string; expiry: Date | null }>({
    value: "",
    expiry: null,
  });
  const onSubmit = async (data: any) => {
    try {
        const validatedProfile: SignInModel = {
          email: data.email,
          password: data.password
        }
        const response = await fetch(`https://localhost:7156/api/Security/Login`, {
          method: "POST",
          headers: {
            Accept: "application/json",
            "Content-Type": "text/json",
          },
          body: JSON.stringify(validatedProfile),
        });
        const responseData = await response.json();
        const { value, expiry } = responseData;
        localStorage.setItem("authToken", value);
        localStorage.setItem("authTokenExpiry", new Date(expiry).toISOString());
        setTokenInfo({ value: value, expiry: new Date(expiry) });
        navigate("/mainPage");
      } catch (error) {
        alert("Email or password incorrect!");
      }
  };

  return (
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
            Sign in
          </Typography>
          <SignInForm onSubmit={onSubmit} />
        </Box>
      </Grid>
    </Grid>
  );
};

export default SignInContainer;