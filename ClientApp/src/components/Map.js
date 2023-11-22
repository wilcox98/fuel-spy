/* eslint-disable array-callback-return */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import L from "leaflet";
import React, { useState } from "react";
import fuel from "./../fuel-station.png";
import { PriceModal } from "./PriceModal";

export const MapView = ({
  zoom = 13,
  center = [-1.286389, 36.817223],
  fuelType,
  stations,
}) => {
  const [_zoom, setZoom] = useState(zoom);
  let priceWidget;
  let selectedFuelType;
  // console.log(geoJSONData);
  return (
    <MapContainer center={center} zoom={_zoom} scrollWheelZoom={false}>
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {stations.map((station, index) => {
        if (station.fuelPrice !== null) {
          if (fuelType === "Super") {
            selectedFuelType = station.fuelPrice.petrol;
          } else if (fuelType === "Diesel") {
            selectedFuelType = station.fuelPrice.diesel;
          } else if (fuelType === "Kerosene") {
            selectedFuelType = station.fuelPrice.kerosene;
          }
          priceWidget = L.divIcon({
            className: "custom-popup",
            iconSize: [40, 40],
            iconAnchor: [25, 65],
            html: `<div class="row">
            <div class="col position-relative">
              <span class="priceTag position-absolute translate-middle start-50   fs-6 fw-bold">${selectedFuelType}</span>
            <img height="40px" src="${fuel}" ></img>
            </div>
          </div>`,
          });
        } else {
          priceWidget = L.divIcon({
            className: "custom-popup",
            iconSize: [40, 40],
            iconAnchor: [22, 33],
            html: `<div class="row">
            <div class="col position-relative">
            <img height="40px" src="${fuel}" ></img>
            </div>
          </div>`,
          });
        }
        return (
          <Marker
            key={index}
            position={[station.lat, station.lon]}
            icon={priceWidget}
            eventHandlers={{
              click: () => {
                setZoom(15);
              },
            }}
          >
            <Popup>
              <PriceModal station={station}></PriceModal>
            </Popup>
          </Marker>
        );
      })}
    </MapContainer>
  );
};
