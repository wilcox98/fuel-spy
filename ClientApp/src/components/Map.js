import { MapContainer, TileLayer, Marker, Popup, GeoJSON } from "react-leaflet";

import React from "react";
import { Icon } from "leaflet";
import fuel from "./../fuel-station.png";
// import data from "./location.json";
import mapData from "./interpreter.json";

export const MapView = ({
  zoom = 13,
  center = [-1.286389, 36.817223],
  towns,
}) => {
  var geoJSONData = [];
  geoJSONData = Array.from(mapData["elements"]);
  console.log(geoJSONData);
  return (
    <MapContainer center={center} zoom={zoom} scrollWheelZoom={false}>
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {/* {geoJSONData.forEach((element) => console.log(element))} */}
      {geoJSONData.map((town, index) => {
        if (town.type === "node") {
          return (
            <Marker
              key={index}
              position={[town.lat, town.lon]}
              icon={
                new Icon({
                  iconUrl: fuel,
                  iconSize: [40, 40],
                  iconAnchor: [20, 30],
                })
              }
            >
              <Popup>
                <strong>{town.tags.brand ?? town.tags.name}</strong>
                <p>{town.tags["addr:street"]}</p>
                <p>{town.tags["addr:city"]}</p>
                <div
                  className="container alert alert-warning"
                  style={{ width: 150 }}
                >
                  Petrol
                  <h6>198.98</h6>
                  Kerosene
                  <h6>198.98</h6>
                  Diesel
                  <h6>198.98</h6>
                </div>

                <button type="button" class="btn btn-primary">
                  Submit Prices
                </button>
              </Popup>
            </Marker>
          );
        } else {
        }
      })}
      {/* <Marker></Marker> */}
      {/* {geoJSONData.map((data, index) => (
        <GeoJSON key={index} data={data}>
          <Popup></Popup>
        </GeoJSON>
      ))} */}
    </MapContainer>
  );
};
