import React, { Component } from "react";
import { Container, TextField, Button, Typography, Box, MenuItem, Select, InputLabel, FormControl } from "@mui/material";
import '../AddActivity/AddActivity.css';

class AddActivity extends Component {
  constructor(props) {
    super(props);
    this.state = {
      formData: {
        id: '',
        name: '',
        description: '',
        dateActivity: '',
        duration: '',
        activityTypeId: ''
      },
      activityTypes: [
        { id: 1, name: 'Running' },
        { id: 2, name: 'Swimming' },
        { id: 3, name: 'Cycling' }
      ]
    };
  }

  handleInputChange = (event) => {
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
    // Ovde možete dodati logiku za slanje podataka na server ili drugu obradu
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
              Add Activity
            </Typography>
            <TextField
              label="Id"
              variant="outlined"
              required
              className="fullWidth"
              name="id"
              type="number"
              value={this.state.formData.id}
              onChange={this.handleInputChange}
            />
            <TextField
              label="Name"
              variant="outlined"
              required
              className="fullWidth"
              name="name"
              value={this.state.formData.name}
              onChange={this.handleInputChange}
            />
            <TextField
              label="Description"
              variant="outlined"
              required
              className="fullWidth"
              name="description"
              value={this.state.formData.description}
              onChange={this.handleInputChange}
            />
            <TextField
              label="Date Activity"
              variant="outlined"
              required
              className="fullWidth"
              name="dateActivity"
              type="date"
              InputLabelProps={{ shrink: true }}
              value={this.state.formData.dateActivity}
              onChange={this.handleInputChange}
            />
            <TextField
              label="Duration"
              variant="outlined"
              required
              className="fullWidth"
              name="duration"
              type="number"
              value={this.state.formData.duration}
              onChange={this.handleInputChange}
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
            <Button variant="contained" color="primary" type="submit" className="fullWidth button">
              Add Activity
            </Button>
          </Box>
        </Container>
      </div>
    );
  }
}

export default AddActivity;
