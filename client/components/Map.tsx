/* eslint-disable array-callback-return */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import L, { LatLngExpression } from "leaflet";
import React, { useEffect, useState } from "react";
// import fuel from "./../fuel-station.png";
import { PriceModal } from "./PriceModal";
import "leaflet/dist/leaflet.css";
import { FuelPrice, Station } from "@/models/models";

const MapView = ({
  zoom = 13,
  center = [-1.286389, 36.817223],
  fuelType,
  stations,
}: {
  center: LatLngExpression;
  zoom: number;
  fuelType: string;
  stations: never[];
}) => {
  // var center: [number, number][] = [[-1.286389, 36.817223]];
  const [_zoom, setZoom] = useState(zoom);
  let priceWidget;
  var selectedFuelType: number;
  const [isBrowser, setIsBrowser] = useState(false);
  useEffect(() => {
    setIsBrowser(true);
  }, []);

  if (!isBrowser) {
    return null;
  }
  return (
    <MapContainer center={center} zoom={_zoom} scrollWheelZoom={false}>
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {stations.map((station: Station, index: number) => {
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
            iconAnchor: [22, 33],
            html: `<div class="row">
            <div class="col position-relative">
              <span class="priceTag position-absolute translate-middle start-50   fs-6 fw-bold">${selectedFuelType}</span>
            <img height="40px" src="/fuel-station.png" ></img>
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
            <img height="40px" src="/fuel-station.png" ></img>
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
export default MapView;
