import { Button, IconButton, InputAdornment, Link, TextField, Typography } from '@mui/material';
import { Visibility, VisibilityOff } from '@mui/icons-material';
import { useEffect, useState } from 'react';
import { SubmitHandler, useForm } from 'react-hook-form';
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { redirect, useNavigate } from 'react-router-dom';

export default function SignInForm ({ onSubmit} : any ) {
  const [showPassword, setShowPassword] = useState(false);
  const navigate = useNavigate();
  const schema = z.object({
    email: z.string()
      .min(12, { message: 'Email must end in @gmail.com' })
      .refine((email) => email.endsWith('@gmail.com'), {
        message: 'Email must end with "@gmail.com"',
      }),
    password: z.string()
      .min(6, { message: 'Password must be at least 6 characters. Must have at least 1 number,1 letter and 1 Symbol' })
      .refine((password) => /^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/.test(password), {
        message: 'Password must contain at least one letter, one number, and one symbol',
      }),
  });

  const { register, handleSubmit, formState: { errors } } = useForm({
    resolver: zodResolver(schema),
  });

  const handleClickShowPassword = () => setShowPassword((show) => !show);
  

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <TextField
        margin="normal"
        required
        fullWidth
        id="email"
        label="Email Address"
        {...register('email')}
        error={!!errors.email}
        helperText={errors.email?.message?.toString()}
        autoFocus
      />
      <TextField
        margin="normal"
        required
        fullWidth
        id="password"
        label="Password"
        {...register('password')}
        error={!!errors.password}
        helperText={errors.password?.message?.toString()}
        type={showPassword ? "text" : "password"}
        InputProps={{
          endAdornment: (
            <InputAdornment position="end">
              <IconButton
                aria-label="toggle password visibility"
                onClick={handleClickShowPassword}
              >
                {showPassword ? <VisibilityOff /> : <Visibility />}
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
        Sign In
      </Button>
      <Typography variant="body2">
        Don't have an account? <Link href="/Register">Register</Link>
      </Typography>
    </form>
  );
};

