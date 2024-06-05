import React, { useState, useEffect } from "react";
import {
  Container,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  Typography,
  Box,
  TextField,
  InputAdornment,
  IconButton,
  MenuItem,
  Select,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
} from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import "../ActivityTable/ActivityTable.css";
import {
  GetAllActivitiesForUserCtrl,
  GetAllActivitiesCtrl,
  SearchActivityCtrl,
  SearchDateActivityCtrl,
  SearchTypeActivityCtrl,
  UpdateActivityCtrl,
  DeleteActivityCtrl
} from "../../controllers/ActivityController";

const ActivityTable = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [activities, setActivities] = useState([]);
  const [activityTypes, setActivityTypes] = useState([]);
  const [byName, setByName] = useState("");
  const [byDesc, setByDesc] = useState("");
  const [selectedDate, setSelectedDate] = useState(new Date());
  const [selectedType, setselectedType] = useState(0);
  const [currentActivity, setCurrentActivity] = useState({});
  const [open, setOpen] = useState(false);

  useEffect(() => {
    loadActivities();
    loadActivityTypes();
    const fetchActivities = async () => {
      try {
        const act = await GetAllActivitiesCtrl();
        setActivityTypes(act);
      } catch (error) {
        alert("Failed to fetch activities:", error);
      }
    };

    fetchActivities();
  }, [currentPage]);

  const handleSearch = () => {
    const searchData = {
      Name: byName,
      Description: byDesc,
    };
    SearchActivityCtrl(searchData)
      .then((data) => {
        setActivities(data);
        setTotalPages(Math.ceil(data.length / 10));
      })
      .catch((error) => {
        console.error("Error loading activities:", error);
      });
  };

  const handleSearchByDate = () => {
    SearchDateActivityCtrl(selectedType)
      .then((data) => {
        setActivities(data);
        setTotalPages(Math.ceil(data.length / 10));
      })
      .catch((error) => {
        console.error("Error loading activities:", error);
      });
  };

  const handleSearchByType = () => {
    SearchTypeActivityCtrl(selectedType)
      .then((data) => {
        setActivities(data);
        setTotalPages(Math.ceil(data.length / 10));
      })
      .catch((error) => {
        console.error("Error loading activities:", error);
      });
  };

  const loadActivities = () => {
    GetAllActivitiesForUserCtrl(currentPage)
      .then((data) => {
        setActivities(data);
        setTotalPages(Math.ceil(data.length / 10));
      })
      .catch((error) => {
        console.error("Error loading activities:", error);
      });
  };

  const loadActivityTypes = () => {
    GetAllActivitiesCtrl()
      .then((data) => {
        setActivityTypes(data);
      })
      .catch((error) => {
        console.error("Error loading activity types:", error);
      });
  };

  const getActivityTypeName = (typeId) => {
    const type = activityTypes.find((type) => type.Id === typeId);
    return type ? type.Name : "Unknown";
  };

  const handlePreviousPage = () => {
    setCurrentPage((prevPage) => Math.max(prevPage - 1, 1));
  };

  const handleNextPage = () => {
    setCurrentPage((prevPage) => Math.min(prevPage + 1, totalPages));
  };

  const handleDateChange = (event) => {
    setSelectedDate(event.target.value);
  };

  const handleTypeChange = (event) => {
    setselectedType(event.target.value);
  };

  const updateActivity = (activity) => {
    UpdateActivityCtrl(activity)
    .then((data) => {
      setCurrentActivity(data)
    })
    .catch((error) => {
      console.error("Error loading activity types:", error);
    });
  };

  const deleteActivity = (id) => {
    console.log(id);
    DeleteActivityCtrl(id)
    .catch((error) => {
      console.error("Error loading activity types:", error);
    });
  };

  //Dialog actions
  const handleEditClick = (activity) => {
    setCurrentActivity(activity);
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSave = () => {
    updateActivity(currentActivity);
    setOpen(false);
  };

  const handleChange = (e, field) => {
    setCurrentActivity({
      ...currentActivity,
      [field]: e.target.value,
    });
  };

  return (
    <div>
      <Container maxWidth="md" className="container">
        <Typography variant="h5" component="h2" className="title">
          Activity List
        </Typography>
        <Box sx={{ display: "flex", justifyContent: "space-between", mb: 2 }}>
          <TextField
            label="By Name"
            variant="outlined"
            value={byName}
            onChange={(e) => setByName(e.target.value)}
            sx={{ width: "45%" }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton onClick={handleSearch}>
                    <SearchIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
          />
          <TextField
            label="By Description"
            variant="outlined"
            value={byDesc}
            onChange={(e) => setByDesc(e.target.value)}
            sx={{ width: "45%" }}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton onClick={handleSearch}>
                    <SearchIcon />
                  </IconButton>
                </InputAdornment>
              ),
            }}
          />
        </Box>

        <Box sx={{ display: "flex", justifyContent: "flex-start", mb: 2 }}>
          <TextField
            label="Choose search date"
            type="date"
            value={selectedDate}
            onChange={handleDateChange}
            InputLabelProps={{
              shrink: true,
            }}
          />

          <IconButton onClick={handleSearchByDate}>
            <SearchIcon />
          </IconButton>
          <Select
            labelId="activityTypeId-label"
            value={selectedType}
            onChange={handleTypeChange}
            label="Activity Type"
          >
            {activityTypes.map((type) => (
              <MenuItem key={type.Id} value={type.Id}>
                {type.Name}
              </MenuItem>
            ))}
          </Select>
          <IconButton onClick={handleSearchByType}>
            <SearchIcon />
          </IconButton>
        </Box>

        <TableContainer component={Paper}>
          <Table className="table">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Description</TableCell>
                <TableCell>Date Activity</TableCell>
                <TableCell>Duration</TableCell>
                <TableCell>Activity Type</TableCell>
                <TableCell>Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {activities.map((activity) => (
                <TableRow key={activity.Id}>
                  <TableCell>{activity.Name}</TableCell>
                  <TableCell>{activity.Description}</TableCell>
                  <TableCell>{activity.DateActivity}</TableCell>
                  <TableCell>{activity.Duration}</TableCell>
                  <TableCell>
                    {getActivityTypeName(activity.ActivityTypeId)}
                  </TableCell>
                  <TableCell>
                    <IconButton
                      color="primary"
                      onClick={() => handleEditClick(activity)}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton
                      color="secondary"
                      onClick={() => deleteActivity(activity.Id)}
                    >
                      <DeleteIcon />
                    </IconButton>
                  </TableCell>{" "}
                  {/* Ćelija sa dugmadima */}
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <Box className="pagination">
          <Button
            variant="contained"
            color="primary"
            onClick={handlePreviousPage}
            disabled={currentPage === 1}
          >
            Previous
          </Button>
          <Typography variant="body1" component="span">
            Page {currentPage} of {totalPages}
          </Typography>
          <Button
            variant="contained"
            color="primary"
            onClick={handleNextPage}
            disabled={currentPage === totalPages}
          >
            Next
          </Button>
        </Box>
      </Container>

      <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Edit Activity</DialogTitle>
        <DialogContent>
          <TextField
            autoFocus
            margin="dense"
            label="Name"
            fullWidth
            value={currentActivity.Name || ""}
            onChange={(e) => handleChange(e, "Name")}
          />
          <TextField
            margin="dense"
            label="Description"
            fullWidth
            value={currentActivity.Description || ""}
            onChange={(e) => handleChange(e, "Description")}
          />
          <TextField
            margin="dense"
            label="Date Activity"
            fullWidth
            value={currentActivity.DateActivity || ""}
            onChange={(e) => handleChange(e, "DateActivity")}
          />
          <TextField
            margin="dense"
            label="Duration"
            fullWidth
            value={currentActivity.Duration || ""}
            onChange={(e) => handleChange(e, "Duration")}
          />
          <TextField
            margin="dense"
            label="Activity Type"
            fullWidth
            disabled
            value={getActivityTypeName(currentActivity.ActivityTypeId) || ""}
            onChange={(e) => handleChange(e, "ActivityTypeId")}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={handleSave} color="primary">
            OK
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default ActivityTable;
