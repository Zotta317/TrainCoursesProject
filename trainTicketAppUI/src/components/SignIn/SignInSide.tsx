import { useNavigate } from 'react-router-dom';
import SignInContainer from './SignInContainer';
import { SignInModel } from '../../models/SignInModel';
import { useEffect, useState } from 'react';

export default function SignIn()  {

  const navigate = useNavigate();
  const [redirect, setRedirect] = useState(false);
  const [tokenInfo, setTokenInfo] = useState<{ value: string; expiry: Date | null }>({
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
        setRedirect(true);
      } catch (error) {
        setRedirect(false);
        alert("Email or password incorrect!");
      }
  };
  
  useEffect(() => {
    if (redirect) {
      navigate("/mainPage");
    }
  }, [redirect, navigate]);

  return (
    <SignInContainer onSubmit={onSubmit} redirect={redirect} />
  );
};

