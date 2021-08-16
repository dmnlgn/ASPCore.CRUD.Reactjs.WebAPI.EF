import logo from './logo.svg';
import './App.css';
import {Home} from './components/Home';
import {Reservations} from './components/Reservations';
import {Guests} from './components/Guests';
import {Navigation} from './components/Navigation';

import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";



function App() {
  return (
    <Router>
    <div className="container">
      <h3 className="m-3 d-flex justify-content-center">ReactReservationService</h3>
    </div>
    <Navigation/>
    <Switch>
      <Route path="/" component={Home} exact/>
      <Route path="/reservations" component={Reservations} exact/>
      <Route path="/guests" component={Guests} exact/>
    </Switch>
    </Router>
  );
}

export default App;
