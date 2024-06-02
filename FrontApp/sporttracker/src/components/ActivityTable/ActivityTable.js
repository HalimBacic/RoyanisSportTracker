import React, { Component } from "react";
import { Container, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, Typography, Box } from "@mui/material";
import '../ActivityTable/ActivityTable.css';

class ActivityTable extends Component {
  constructor(props) {
    super(props);
    this.state = {
      currentPage: 1,
      totalPages: 1,
      activities: [] // Ove podatke ćete popuniti izvan ove komponente
    };
  }

  componentDidMount() {
    // Ovdje možete pozvati metodu za učitavanje podataka
    this.loadActivities();
  }

  loadActivities = () => {
    // Ovde možete dodati logiku za učitavanje podataka sa servera
    // Na primer, koristite fetch ili axios za preuzimanje podataka
    // I zatim ažurirajte stanje sa preuzetim podacima i ukupnim brojem stranica
  }

  handlePreviousPage = () => {
    this.setState((prevState) => ({
      currentPage: Math.max(prevState.currentPage - 1, 1)
    }), this.loadActivities);
  }

  handleNextPage = () => {
    this.setState((prevState) => ({
      currentPage: Math.min(prevState.currentPage + 1, prevState.totalPages)
    }), this.loadActivities);
  }

  render() {
    const { currentPage, totalPages, activities } = this.state;

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
                  <TableCell>Id</TableCell>
                  <TableCell>Name</TableCell>
                  <TableCell>Description</TableCell>
                  <TableCell>Date Activity</TableCell>
                  <TableCell>Duration</TableCell>
                  <TableCell>Activity Type Id</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {activities.map((activity) => (
                  <TableRow key={activity.id}>
                    <TableCell>{activity.id}</TableCell>
                    <TableCell>{activity.name}</TableCell>
                    <TableCell>{activity.description}</TableCell>
                    <TableCell>{activity.dateActivity}</TableCell>
                    <TableCell>{activity.duration}</TableCell>
                    <TableCell>{activity.activityTypeId}</TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
          <Box className="pagination">
            <Button
              variant="contained"
              color="primary"
              onClick={this.handlePreviousPage}
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
              onClick={this.handleNextPage}
              disabled={currentPage === totalPages}
            >
              Next
            </Button>
          </Box>
        </Container>
      </div>
    );
  }
}

export default ActivityTable;
