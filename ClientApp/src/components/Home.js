import { Container } from "react-bootstrap";

import React, { useEffect, useState } from "react";
import { MapView } from "./Map";
import { FuelDropdown } from "./FuelDropdown";
// TODO use Effect
export const Home = () => {
  const [stations, setStations] = useState([]);
  const [town, setTown] = useState([]);
  const [fuelType, setFuelType] = useState("Super");
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`/prices`);
        const newData = await response.json();
        setStations(newData);
      } catch (error) {
        console.log("An error occured: ", error);
      }
    };
    fetchData();
  });
  return (
    <Container>
      <div className="container">
        <div className="p-4">
          <form className="row g-2">
            <div className="col-md-6">
              <label htmlFor="inputPassword2" className="visually-hidden">
                Town
              </label>
              <input
                type="text"
                className="form-control"
                id="town"
                placeholder="Town"
                value={town}
                onChange={(e) => setTown(e.target.value)}
              ></input>
            </div>
            <div className="col-md-6">
              <FuelDropdown fuelType={fuelType} setFuelType={setFuelType} />
            </div>
          </form>
        </div>
        <div className="row">
          <div className="col-md-12">
            <MapView stations={stations} fuelType={fuelType}></MapView>
          </div>
        </div>
      </div>
    </Container>
  );
};
