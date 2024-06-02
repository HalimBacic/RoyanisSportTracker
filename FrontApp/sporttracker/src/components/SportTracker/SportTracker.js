import React, { Component } from "react";
import Login from "../Login/Login";
import Register from "../Register/Register";
import '../SportTracker/SportTracker.css'

class SportTracker extends Component {
  render() {
    return <div className="container">
      <Login></Login>
      <Register></Register>
    </div>;
  }
}

export default SportTracker;
