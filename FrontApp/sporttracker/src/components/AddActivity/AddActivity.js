import React, { useState, useEffect } from "react";
import { Container, TextField, Button, Typography, Box, MenuItem, Select, InputLabel, FormControl } from "@mui/material";
import '../AddActivity/AddActivity.css';
import { GetAllActivitiesCtrl, CreateActivityCtrl } from '../../controllers/ActivityController';

const AddActivity = ({ token }) => {
  const [formData, setFormData] = useState({
    id: '',
    name: '',
    description: '',
    dateActivity: '',
    duration: '',
    activityTypeId: ''
  });

  const [activityTypes, setActivityTypes] = useState([]);

  useEffect(() => {
    const fetchActivities = async () => {
      try {
        const act = await GetAllActivitiesCtrl(token);
        setActivityTypes(act); 
      } catch (error) {
        alert('Failed to fetch activities:' + error);
      }
    };

    fetchActivities();
  }, [token]); 

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData(prevFormData => ({
      ...prevFormData,
      [name]: value
    }));
  };

  const handleSelectChange = (event) => {
    setFormData(prevFormData => ({
      ...prevFormData,
      activityTypeId: event.target.value
    }));
  };

  const handleSubmit =  async(event) => {
    event.preventDefault();
    const activityData = {
      name: formData.name,
      description: formData.description,
      dateActivity: formData.dateActivity,
      duration: parseInt(formData.duration, 10),  
      activityTypeId: parseInt(formData.activityTypeId, 10)  
    };

    try{
      await CreateActivityCtrl(activityData);
    }
    catch(error)
    {
      alert("Problem with create activity:"+error);
    }
  };

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
            Add Activity
          </Typography>
          <TextField
            style={{ display: 'none' }} 
            label="Id"
            variant="outlined"
            required
            className="fullWidth"
            name="id"
            type="number"
            hidden
            value={formData.id}
            onChange={handleInputChange}
          />
          <TextField
            label="Name"
            variant="outlined"
            required
            className="fullWidth"
            name="name"
            value={formData.name}
            onChange={handleInputChange}
          />
          <TextField
            label="Description"
            variant="outlined"
            required
            className="fullWidth"
            name="description"
            value={formData.description}
            onChange={handleInputChange}
          />
          <TextField
            label="Date Activity"
            variant="outlined"
            required
            className="fullWidth"
            name="dateActivity"
            type="date"
            InputLabelProps={{ shrink: true }}
            value={formData.dateActivity}
            onChange={handleInputChange}
          />
          <TextField
            label="Duration"
            variant="outlined"
            required
            className="fullWidth"
            name="duration"
            type="number"
            value={formData.duration}
            onChange={handleInputChange}
          />
          <FormControl variant="outlined" className="fullWidth" required>
            <InputLabel id="activityTypeId-label">Activity Type</InputLabel>
            <Select
              labelId="activityTypeId-label"
              value={formData.activityTypeId}
              onChange={handleSelectChange}
              label="Activity Type"
            >
              {activityTypes.map(type => (
                <MenuItem key={type.Id} value={type.Id}>
                  {type.Name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <Button variant="contained" onClick={handleSubmit} color="primary" type="button" className="fullWidth button">
            Add Activity
          </Button>
        </Box>
      </Container>
    </div>
  );
};

export default AddActivity;
