import React, { useEffect, useState } from "react";
import "../Home/Home.css";
import AddTarget from "../AddTarget/AddTarget";
import AddActivity from "../AddActivity/AddActivity";
import ActivityTable from "../ActivityTable/ActivityTable";
import TargetTable from "../TargetTable/TargetTable";
import { Button } from "@mui/material";


const Home = () => {
  const [isActivity, setIsActivity] = useState(true);
  const [token, setToken] = useState("");

  const getTokenFromCookies = () => {
    const cookies = document.cookie.split('; ');
    const tokenCookie = cookies.find(cookie => cookie.startsWith('token='));
    if (tokenCookie) {
      return tokenCookie.split('=')[1];
    }
    return null;
  };

  useEffect(() => {
    const token = getTokenFromCookies();
    const tokenObj = JSON.parse(token);
    setToken(tokenObj.token);
  }, [])
  

  const toggleView = () => {
    setIsActivity((prevIsActivity) => !prevIsActivity);
  };

  return (
    <div className="container">
      <AddActivity></AddActivity>
      <div className="centralContainer">
        <Button onClick={toggleView}           
            variant="contained"
            color="primary"
            type="button"
            className="fullWidth"> 
          {isActivity ? "Show Target" : "Show Activity"}
        </Button>
        {isActivity ? <ActivityTable /> : <TargetTable />}
      </div>
      <AddTarget></AddTarget>
    </div>
  );
};

export default Home;
