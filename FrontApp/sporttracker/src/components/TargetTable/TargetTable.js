import React, { useState, useEffect } from "react";
import { makeStyles } from '@material-ui/core/styles';
import { Container, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, Typography, Box } from "@mui/material";
import '../TargetTable/TargetTable.css';
import { GetAllActivitiesCtrl } from '../../controllers/ActivityController'; 
import { GetTargetsCtrl} from '../../controllers/UserTargetController';

const useStyles = makeStyles({
  greenCell: {
    backgroundColor: 'green',
    color:'white'
  },
  redCell: {
    backgroundColor: 'red',
    color:'white'
  },
});

const TargetTable = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [targets, setTargets] = useState([]);
  const [activityTypes, setActivityTypes] = useState([]);
  const classes = useStyles();

  useEffect(() => {
    loadTargets();
    loadActivityTypes();
  }, [currentPage]);
  

  const loadActivityTypes = () => {
    GetAllActivitiesCtrl()
      .then(data => {
        setActivityTypes(data);
      })
      .catch(error => {
        console.error("Error loading activity types:", error);
      });
  };

  const loadTargets = () => {
    GetTargetsCtrl(currentPage)
      .then(data => {
        setTargets(data);
        setTotalPages(Math.ceil(data.length / 10)); 
      })
      .catch(error => {
        console.error("Error loading targets:", error);
      });
  };

  const handlePreviousPage = () => {
    setCurrentPage(prevPage => Math.max(prevPage - 1, 1));
  };

  const handleNextPage = () => {
    setCurrentPage(prevPage => Math.min(prevPage + 1, totalPages));
  };

  const getActivityTypeName = (typeId) => {
    const type = activityTypes.find(type => type.Id === typeId);
    return type ? type.Name : 'Unknown';
  };

  const getActivityType = (typeId) => {
    return typeId === 0 ? 'TimePerDay' : 'DurationPerDay';
  };

  return (
    <div>
      <Container maxWidth="md" className="container">
        <Typography variant="h5" component="h2" className="title">
          Target List
        </Typography>
        <TableContainer component={Paper}>
          <Table className="table">
            <TableHead>
              <TableRow>
                <TableCell>ActivityTypeId</TableCell>
                <TableCell>Date</TableCell>
                <TableCell>Type</TableCell>
                <TableCell>Count</TableCell>
                <TableCell>Target</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {targets.map((activity,index) => (
                <TableRow key={index}>
                  <TableCell>{getActivityTypeName(activity.ActivityTypeId)}</TableCell>
                  <TableCell>{activity.DateActivity}</TableCell>
                  <TableCell>{getActivityType(activity.Type)}</TableCell>
                  <TableCell className={activity.Count >= activity.Target ? classes.greenCell : classes.redCell}>
              {activity.Count}
            </TableCell>
                  <TableCell>{activity.Target}</TableCell>
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

export default TargetTable;
