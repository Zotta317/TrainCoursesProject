import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import { Avatar, Box, Grid, Paper, Typography } from "@mui/material";
import BackgroundImage from '../Backgorund/BackgroundImage';
import RegisterForm from "./RegisterForm";

const RegisterContainer = ({ onSubmit }: { onSubmit: (data: any) => Promise<void> }) =>{
    
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