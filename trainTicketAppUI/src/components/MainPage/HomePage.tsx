import { Box } from "@mui/material";
import NavigationBar from "../NavigationBar/NavigationBar";
import FilterCourses from "./FilterCourses";

export default function HomePage(){

    return (
        <>
        <NavigationBar />
        <Box
          sx={{
            flexGrow: 1,
            display: "flex",
            alignItems: "center",
            justifyContent: "center",
            flexDirection: "column",
          }}
        >
          <FilterCourses />
        </Box>
      </>
        
    )
}