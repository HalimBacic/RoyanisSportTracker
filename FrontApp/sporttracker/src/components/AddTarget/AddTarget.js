import React, { Component } from "react";
import { Container, TextField, Button, Typography, Box, MenuItem, Select, InputLabel, FormControl } from "@mui/material";
import '../AddTarget/AddTarget.css';

class AddTarget extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
        userId: '',
        activityTypeId: '',
        date: '',
        type: '',
        count: '',
        target: ''
      },
      //Ucitati activityTypes iz baze podataka 
      activityTypes: [
        { id: 1, name: 'Running' },
        { id: 2, name: 'Swimming' },
        { id: 3, name: 'Cycling' }
      ]
    };
  }

  handleInput = (event) => {
    const { name, value } = event.target;
    this.setState(prevState => ({
      formData: {
        ...prevState.formData,
        [name]: value
      }
    }));
  }

  handleSelectChange = (event) => {
    this.setState(prevState => ({
      formData: {
        ...prevState.formData,
        activityTypeId: event.target.value
      }
    }));
  }

  handleSubmit = (event) => {
    event.preventDefault();
    console.log('Form submitted');
    console.log(this.state.formData);
  }

  render() {
    return (
      <div>
        <Container maxWidth="xs" className="container">
          <Box
            component="form"
            className="form"
            noValidate
            autoComplete="off"
            onSubmit={this.handleSubmit}
          >
            <Typography variant="h5" component="h2" className="title">
              Activity Form
            </Typography>
            <TextField
              label="UserId"
              variant="outlined"
              required
              className="fullWidth"
              name="userId"
              type="number"
              value={this.state.formData.userId}
              onChange={this.handleInput}
            />
            <FormControl variant="outlined" className="fullWidth" required>
              <InputLabel id="activityTypeId-label">Activity Type</InputLabel>
              <Select
                labelId="activityTypeId-label"
                value={this.state.formData.activityTypeId}
                onChange={this.handleSelectChange}
                label="Activity Type"
              >
                {this.state.activityTypes.map(type => (
                  <MenuItem key={type.id} value={type.id}>
                    {type.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            <TextField
              label="Date"
              variant="outlined"
              required
              className="fullWidth"
              name="date"
              type="date"
              InputLabelProps={{ shrink: true }}
              value={this.state.formData.date}
              onChange={this.handleInput}
            />
            <TextField
              label="Type"
              variant="outlined"
              required
              className="fullWidth"
              name="type"
              type="number"
              value={this.state.formData.type}
              onChange={this.handleInput}
            />
            <TextField
              label="Count"
              variant="outlined"
              required
              className="fullWidth"
              name="count"
              type="number"
              value={this.state.formData.count}
              onChange={this.handleInput}
            />
            <TextField
              label="Target"
              variant="outlined"
              required
              className="fullWidth"
              name="target"
              type="number"
              value={this.state.formData.target}
              onChange={this.handleInput}
            />
            <Button variant="contained" color="primary" type="submit" className="fullWidth button">
              Add target
            </Button>
          </Box>
        </Container>
      </div>
    );
  }
}

export default AddTarget;
