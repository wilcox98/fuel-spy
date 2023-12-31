import { FuelDropdown } from "@/components/FuelDropdown";
import MapView from "@/components/Map";
import axios from "axios";
import dynamic from "next/dynamic";
import React, { useEffect, useState } from "react";
const Map = dynamic(() => import("../components/Map"), { ssr: false });
export default function Page() {
  const [stations, setStations] = useState([]);
  const [town, setTown] = useState("");
  const [fuelType, setFuelType] = useState("Super");
  const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;
  useEffect(() => {
    axios
      .get(BASE_URL + "prices")
      .then((res) => {
        const newData = res.data;
        // console.log(newData);
        setStations(newData);
      })
      .catch((error) => console.log("An error occured: ", error));
  });
  return (
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
          <Map
            stations={stations}
            fuelType={fuelType}
            zoom={13}
            center={[-1.286389, 36.817223]}
          ></Map>
        </div>
      </div>
    </div>
  );
}
