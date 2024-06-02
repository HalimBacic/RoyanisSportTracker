import "./App.css";
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Routes,
} from "react-router-dom";
import Home from "../src/components/Home/Home";
import SportTracker from "../src/components/SportTracker/SportTracker";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<SportTracker></SportTracker>} />
        <Route path="/home" element={<Home></Home>} />
      </Routes>
    </Router>
  );
}

export default App;
