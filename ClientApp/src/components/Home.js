import { Container } from "react-bootstrap";
import Form from "react-bootstrap/Form";

import React from "react";
import { MapView } from "./Map";
import FuelDropdown from "./FuelDropdown";
export class Home extends React.Component {
  state = {
    stations: [],
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
  componentDidMount() {
    fetch("/prices")
      .then((response) => {
        var res = response.json();
        return res;
      })
      .then((data) => {
        // console.log(data);

        this.setState({ stations: data });
      })
      .catch((e) => console.log(e));
  }

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
              <MapView stations={this.state.stations}></MapView>
            </div>
          </div>
        </div>
      </Container>
    );
  }
}

export default Home;
