import React, { useState } from "react";
import "../Home/Home.css";
import AddTarget from "../AddTarget/AddTarget";
import AddActivity from "../AddActivity/AddActivity";
import ActivityTable from "../ActivityTable/ActivityTable";
import TargetTable from "../TargetTable/TargetTable";

const Home = () => {
  const [isActivity, setIsActivity] = useState(true);

  const toggleView = () => {
    setIsActivity((prevIsActivity) => !prevIsActivity);
  };

  return (
    <div className="container">
      <AddActivity></AddActivity>
      <div className="centralContainer">
        <button onClick={toggleView}>
          {isActivity ? "Show Target" : "Show Activity"}
        </button>
        {isActivity ? <ActivityTable /> : <TargetTable />}
      </div>
      <AddTarget></AddTarget>
    </div>
  );
};

export default Home;
