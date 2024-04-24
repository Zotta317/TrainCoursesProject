import { ThemeProvider } from "@emotion/react";
import SignIn from "./components/SignInPage/SignInSide";
import { createTheme } from "@mui/material";

const defaultTheme = createTheme();
function App() {
  return (
    <>
      <ThemeProvider theme={defaultTheme}>
              <SignIn />
      </ThemeProvider>

    </>
  );
}

export default App;