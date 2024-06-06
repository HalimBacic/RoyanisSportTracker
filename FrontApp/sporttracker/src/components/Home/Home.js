import React, { useEffect, useState } from "react";
import "../Home/Home.css";
import AddTarget from "../AddTarget/AddTarget";
import AddActivity from "../AddActivity/AddActivity";
import ActivityTable from "../ActivityTable/ActivityTable";
import TargetTable from "../TargetTable/TargetTable";
import { Button } from "@mui/material";
import { IconButton } from '@mui/material';
import RefreshIcon from '@mui/icons-material/Refresh';


const Home = () => {
  const [isActivity, setIsActivity] = useState(true);
  const [refreshView, setRefreshView] = useState(true);
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
  

  const toggleRefresh = () => {
    setRefreshView((refreshView) => !refreshView);
  };
  
  const toggleView = () => {
    setIsActivity((prevIsActivity) => !prevIsActivity);
  };

  return (
    <div className="container">
      <AddActivity></AddActivity>
      <div className="centralContainer">
        <div style={{display:"flex", flexDirection:"row"}}>
        <Button onClick={toggleView}           
            variant="contained"
            color="primary"
            type="button"
            className="fullWidth"> 
          {isActivity ? "Show Target" : "Show Activity"}
        </Button>
        <IconButton color="primary" onClick={toggleRefresh}>
      <RefreshIcon />
    </IconButton>
        </div>
        {isActivity ? <ActivityTable refresh={refreshView}/> : <TargetTable refresh={refreshView}/>}
      </div>
      <AddTarget></AddTarget>
    </div>
  );
};

export default Home;