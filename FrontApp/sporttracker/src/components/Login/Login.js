import React, { Component, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Container, TextField, Button, Typography, Box } from "@mui/material";
import "../Login/Login.css";
import { LoginUserCtrl } from "../../controllers/UserController";

const Login = () => {
  
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: ''
  })

  const handleInputChange = (event) => {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value
    });
  }

  const navigate = useNavigate();

  const handleClick = async (event) => { 
    try {
      const token = await LoginUserCtrl(formData);
      if (token) {
        document.cookie = `token=${JSON.stringify(token)}; path=/`;
        navigate('/Home');
      } else {
        alert('Invalid credentials');
      }
    } catch (err) {
      alert('An error occurred during login. Please try again.');
      console.error(err);
    }
   }

  return (
    <div>
      <Container maxWidth="xs" className="container">
        <Box component="form" className="form" noValidate autoComplete="off">
          <Typography variant="h5" component="h2" className="title">
            Login
          </Typography>
          <TextField
            label="Username"
            variant="outlined"
            required
            className="fullWidth"
            name="username"
            value = {formData.username}
            onChange={handleInputChange}
          />
          <TextField
            label="Password"
            variant="outlined"
            type="password"
            required
            name="password"
            value = {formData.password}
            className="fullWidth"
            onChange={handleInputChange}
          />
          <Button
            variant="contained"
            color="primary"
            type="button"
            className="fullWidth"
            onClick={handleClick}
          >
            Login
          </Button>
        </Box>
      </Container>
    </div>
  );
};

export default Login;
