/* eslint-disable array-callback-return */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";

import React from "react";
import { Icon } from "leaflet";
import fuel from "./../fuel-station.png";
// import data from "./location.json";
import mapData from "./interpreter.json";
import { PriceModal } from "./PriceModal";

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
                <PriceModal town={town}></PriceModal>
              </Popup>
            </Marker>
          );
        } else {
          //   return <></>;
        }
      })}
    </MapContainer>
  );
};
