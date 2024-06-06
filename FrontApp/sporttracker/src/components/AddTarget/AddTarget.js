import React, { useState, useEffect } from "react";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box,
  MenuItem,
  Select,
  InputLabel,
  FormControl,
} from "@mui/material";
import "../AddTarget/AddTarget.css";
import { GetAllActivitiesCtrl } from "../../controllers/ActivityController";
import { AddTargetCtrl } from "../../controllers/UserTargetController";

const AddTarget = ({ token }) => {
  const [formData, setFormData] = useState({
    userId: "",
    activityTypeId: "",
    dateActivity: "",
    type: "",
    count: "",
    target: "",
  });

  const [activityTypes, setActivityTypes] = useState([]);
  const [types] = useState(["TimePerDay", "DurationPerDay"]);

  useEffect(() => {
    const fetchActivities = async () => {
      try {
        const act = await GetAllActivitiesCtrl(token);
        setActivityTypes(act);
      } catch (error) {
        alert("Failed to fetch activities:", error);
      }
    };

    fetchActivities();
  }, [token]);

  const handleInput = (event) => {
    const { name, value } = event.target;
    setFormData((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSelectChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const targetData = {
      dateActivity: formData.dateActivity,
      target: parseInt(formData.target, 10),
      type: formData.type,
      activityTypeId: parseInt(formData.activityTypeId, 10),
    };
    try {
      await AddTargetCtrl(targetData);
    } catch (error) {
      alert("Problem with add target:" + error);
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
          onSubmit={handleSubmit}
        >
          <Typography variant="h5" component="h2" className="title">
            Add target
          </Typography>
          <FormControl variant="outlined" className="fullWidth" required>
            <InputLabel id="activityTypeId-label">Activity Type</InputLabel>
            <Select
              labelId="activityTypeId-label"
              name="activityTypeId"
              value={formData.activityTypeId}
              onChange={handleSelectChange}
              label="Activity Type"
            >
              {activityTypes.map((type) => (
                <MenuItem key={type.Id} value={type.Id}>
                  {type.Name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <TextField
            label="Date"
            variant="outlined"
            required
            className="fullWidth"
            name="dateActivity"
            type="date"
            InputLabelProps={{ shrink: true }}
            value={formData.dateActivity}
            onChange={handleInput}
          />
          <FormControl variant="outlined" className="fullWidth" required>
            <InputLabel id="type-label">Target Type</InputLabel>
            <Select
              labelId="type-label"
              name="type"
              value={formData.type}
              onChange={handleSelectChange}
              label="Target Type"
            >
              {types.map((type, index) => (
                <MenuItem key={index} value={index}>
                  {type}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          <TextField
            label="Target"
            variant="outlined"
            required
            className="fullWidth"
            name="target"
            type="number"
            value={formData.target}
            onChange={handleInput}
          />
          <Button
            variant="contained"
            color="primary"
            type="submit"
            className="fullWidth button"
          >
            Add target
          </Button>
        </Box>
      </Container>
    </div>
  );
};

export default AddTarget;
