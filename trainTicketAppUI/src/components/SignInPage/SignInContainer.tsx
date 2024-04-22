import { Avatar, Box, Grid, Paper, Typography } from '@mui/material';
import { LockOutlined as LockOutlinedIcon } from '@mui/icons-material';
import SignInForm from './SignInForm';
import BackgroundImage from '../Backgorund/BackgroundImage';
// import BackgroundImage from './BackgroundImage';
// import  BackgroundImage  from '../Backgorund/BackgroundImage';
const SignInContainer = ({ onSubmit, navigate } : any) => {
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
          <SignInForm onSubmit={onSubmit} navigate={navigate} />
        </Box>
      </Grid>
    </Grid>
  );
};

export default SignInContainer;