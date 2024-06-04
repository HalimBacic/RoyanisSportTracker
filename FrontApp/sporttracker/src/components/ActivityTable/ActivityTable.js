import React, { useState, useEffect } from "react";
import { Container, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, Typography, Box } from "@mui/material";
import '../ActivityTable/ActivityTable.css';
import { GetAllActivitiesForUserCtrl, GetAllActivitiesCtrl } from '../../controllers/ActivityController'; 

const ActivityTable = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const [activities, setActivities] = useState([]);
  const [activityTypes, setActivityTypes] = useState([]);

  useEffect(() => {
    loadActivities();
    loadActivityTypes();
  }, [currentPage]);

  const loadActivities = () => {
    GetAllActivitiesForUserCtrl(currentPage)
      .then(data => {
        setActivities(data);
        setTotalPages(Math.ceil(data.length / 10)); 
      })
      .catch(error => {
        console.error("Error loading activities:", error);
      });
  };

  const loadActivityTypes = () => {
    GetAllActivitiesCtrl()
      .then(data => {
        setActivityTypes(data);
      })
      .catch(error => {
        console.error("Error loading activity types:", error);
      });
  };

  const getActivityTypeName = (typeId) => {
    const type = activityTypes.find(type => type.Id === typeId);
    return type ? type.Name : 'Unknown';
  };

  const handlePreviousPage = () => {
    setCurrentPage(prevPage => Math.max(prevPage - 1, 1));
  };

  const handleNextPage = () => {
    setCurrentPage(prevPage => Math.min(prevPage + 1, totalPages));
  };

  return (
    <div>
      <Container maxWidth="md" className="container">
        <Typography variant="h5" component="h2" className="title">
          Activity List
        </Typography>
        <TableContainer component={Paper}>
          <Table className="table">
            <TableHead>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>Description</TableCell>
                <TableCell>Date Activity</TableCell>
                <TableCell>Duration</TableCell>
                <TableCell>Activity Type</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {activities.map((activity) => (
                <TableRow key={activity.Id}>
                  <TableCell>{activity.Name}</TableCell>
                  <TableCell>{activity.Description}</TableCell>
                  <TableCell>{activity.DateActivity}</TableCell>
                  <TableCell>{activity.Duration}</TableCell>
                  <TableCell>{getActivityTypeName(activity.ActivityTypeId)}</TableCell>
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
    </div>
  );
};

export default ActivityTable;
