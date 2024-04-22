import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";

import { Visibility, VisibilityOff } from "@mui/icons-material"
import { Avatar, Box, Button, CssBaseline, Grid, IconButton, InputAdornment, Link, TextField, Typography, createTheme } from "@mui/material"

export default function RegisterForm({ onSubmit} : any){
    const [showPassword, setShowPassword] = useState(false);
    const [showConfirmedPassword, setShowConfirmedPassword] = useState(false);
  
    // validation schema for Sig in form
    // Email must be of type @gmail.com 
    // Password must have at least 1 symbol, 1 number, 1 letter, min size 6
    // ConfirmOassword must match with Password
    const schema = z.object({
      email: z.string()
        .min(12, { message: 'Email must end in @gmail.com' })
        .refine((email) => email.endsWith('@gmail.com'), {
          message: 'Email must end with "@gmail.com"',
        }),
      firstName: z.string().min(1, { message: "Please fill this field" }),
      lastName: z.string().min(1, { message: "Please fill this field" }),
      password: z.string()
        .min(6, { message: 'Password must be at least 6 characters. Must have at least 1 number,1 letter and 1 Symbol' })
        .refine((password) => /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/.test(password), {
          message: 'Password must contain at least one letter, one number, and one symbol',
        }),
      confirmPassword: z.string()
        .min(6)
      ,
    }).refine(
      (values: { password: any; confirmPassword: any; }) => {
        return values.password === values.confirmPassword;
      },
      {
        message: "Passwords must match!",
        path: ["confirmPassword"],
      }
    );
  
    type ValidationSchemaType = z.infer<typeof schema>
  
    //validation resolver (using Zod)
    const { register, handleSubmit, formState: { errors } } = useForm<ValidationSchemaType>({
      resolver: zodResolver(schema),
    });
  
   // Allow user to see his password
    const handleClickShowPassword = (fieldId: string) => {
      if (fieldId === "password") {
        setShowPassword((prevShowPassword) => !prevShowPassword);
      } else {
        setShowConfirmedPassword(
          (prevShowConfirmedPassword) => !prevShowConfirmedPassword
        );
      }
    };

    return(
        <>
         <Box component="form" noValidate sx={{ mt: 1 }} onSubmit={handleSubmit(onSubmit)}>
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  {...register('email')}
                  error={!!errors.email}
                  helperText={errors.email?.message}

                />
                <Grid container spacing={1}>
                  <Grid item xs={12} sm={6}>
                    <TextField
                      margin="normal"
                      required
                      fullWidth
                      id="firstName"
                      label="First Name"
                      {...register('firstName')}
                      error={!!errors.firstName}
                      helperText={errors.firstName?.message}

                    />
                  </Grid>
                  <Grid item xs={12} sm={6}>
                    <TextField
                      margin="normal"
                      required
                      fullWidth
                      id="lastName"
                      label="Last Name"
                      {...register('lastName')}
                      error={!!errors.lastName}
                      helperText={errors.lastName?.message}
                    />
                  </Grid>
                </Grid>
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  id="password"
                  label="Password"
                  {...register('password')}
                  error={!!errors.password}
                  helperText={errors.password?.message}
                  type={showPassword ? "text" : "password"}
                  InputProps={{
                    endAdornment: (
                      <InputAdornment position="end">
                        <IconButton
                          aria-label="toggle password visibility"
                          onClick={() => handleClickShowPassword("password")}
                        >
                          {showPassword ? <VisibilityOff /> : <Visibility />}
                        </IconButton>
                      </InputAdornment>
                    ),
                  }}
                />
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  label="Confirm Password"
                  {...register('confirmPassword')}
                  error={!!errors.confirmPassword}
                  helperText={errors.confirmPassword?.message}
                  type={showConfirmedPassword ? "text" : "password"}
                  id="confirmPassword"
                  InputProps={{
                    endAdornment: (
                      <InputAdornment position="end">
                        <IconButton
                          aria-label="toggle password visibility"
                          onClick={() =>
                            handleClickShowPassword("")
                          }
                        >
                          {showConfirmedPassword ? (
                            <VisibilityOff />
                          ) : (
                            <Visibility />
                          )}
                        </IconButton>
                      </InputAdornment>
                    ),
                  }}
                />
                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  sx={{ mt: 3, mb: 2 }}
                >
                  Register
                </Button>
                <Grid container>
                  <Grid item xs>
                    <Link href="/signIn" variant="body2">
                      Already have an account? Sign in
                    </Link>
                  </Grid>
                </Grid>
              </Box>
        
        </>
    )
}