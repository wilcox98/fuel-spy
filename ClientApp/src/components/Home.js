import { Container } from "react-bootstrap";
import Form from "react-bootstrap/Form";

import React from "react";
import axios from "axios";
import { MapView } from "./Map";
import FuelDropdown from "./FuelDropdown";
export class Home extends React.Component {
  state = {
    towns: [
      {
        Diesel: 115.6,
        Kerosene: 103.54,
        Super: 134.72,
        Town: "Nairobi",
        lat: -1.30261485,
        lon: 36.8288420181,
      },
    ],
    avg: [],
  };
  // componentDidMount() {
  //   axios
  //     .get(`http://127.0.0.1:5000/towns`)
  //     .then((res) => {
  //       const towns = res.data;
  //       //    console.log(towns)
  //       this.setState({ towns });
  //     })
  //     .catch((error) => console.log(error));
  //   axios
  //     .get(`http://localhost:5000/towns/average`)
  //     .then((res) => {
  //       const avg = res.data;
  //       //    console.log(towns)
  //       this.setState({ avg });
  //     })
  //     .catch((error) => console.log(error));
  // }
  render() {
    return (
      <Container>
        <div className="container">
          <div className="row">
            <div className="col-md-6">
              <Form.Group
                className="mb-3"
                controlId="exampleForm.ControlInput1"
              >
                <Form.Control type="text" placeholder="Town" />
              </Form.Group>
            </div>
            <div className="col-md-6">
              <FuelDropdown />
            </div>
          </div>
          <div className="row">
            <div className="col-md-12">
              <MapView towns={this.state.towns}></MapView>
            </div>
          </div>
        </div>
      </Container>
    );
  }
}

export default Home;
