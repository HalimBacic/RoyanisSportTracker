import React, { useState} from "react";
import { Container, TextField, Button, Typography, Box } from "@mui/material";
import '../Register/Register.css'
import { RegisterUserCtrl } from '../../controllers/UserController'

const Register = () => {
  const [formData, setFormData] = useState({
    username: '',
    email: '',
    password: ''
  });

  const handleRegister = () => { 
      let user = RegisterUserCtrl(formData);
      console.log(user);
  }

  const handleInputChange = (event) => {
    setFormData({
      ...formData,
      [event.target.name]: event.target.value
    });
  }

  return (
    <div>
      <Container maxWidth="xs" className="container">
          <Box
              component="form"
              className="form"
              noValidate
              autoComplete="off"
          >
              <Typography variant="h5" component="h2" className="title">
                  Register
              </Typography>
              <TextField
                  label="Username"
                  variant="outlined"
                  required
                  className="fullWidth"
                  name="username"
                  value={formData.username}
                  onChange={handleInputChange}
              />
              <TextField
                  label="Email"
                  variant="outlined"
                  type="email"
                  required
                  className="fullWidth"
                  name="email"
                  value={formData.email}
                  onChange={handleInputChange}
              />
              <TextField
                  label="Password"
                  variant="outlined"
                  type="password"
                  required
                  className="fullWidth"
                  name="password"
                  value={formData.password}
                  onChange={handleInputChange}
              />
              <Button variant="contained" color="primary" type="button" className="fullWidth" onClick={handleRegister}>
                  Register
              </Button>
          </Box>
      </Container>
    </div>
  );
}

export default Register;
