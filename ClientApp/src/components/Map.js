/* eslint-disable array-callback-return */
import { MapContainer, TileLayer, Marker, Popup } from "react-leaflet";
import L from "leaflet";
import React, { useState } from "react";
import fuel from "./../fuel-station.png";
import { PriceModal } from "./PriceModal";

export const MapView = ({
  zoom = 13,
  center = [-1.286389, 36.817223],
  towns,
  stations,
}) => {
  const [_zoom, setZoom] = useState(zoom);

  // console.log(geoJSONData);
  return (
    <MapContainer center={center} zoom={_zoom} scrollWheelZoom={false}>
      <TileLayer
        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
      />
      {stations.map((station, index) => {
        return (
          <Marker
            key={index}
            position={[station.lat, station.lon]}
            icon={L.divIcon({
              className: "custom-popup",
              iconSize: [40, 40],
              iconAnchor: [25, 65],
              html:
                // ReactDOMServer.renderToString(<SVGIconComponent perc={200} />),
                `<div class="row">
                  <div class="col position-relative">
                    <span class="priceTag position-absolute translate-middle start-50   fs-6 fw-bold">${station.fuelPrice.petrol}</span>
                  <img height="40px" src="${fuel}" ></img>
                  </div>
                </div>`,
            })}
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
