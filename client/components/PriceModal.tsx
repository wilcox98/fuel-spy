import { Station } from "@/models/models";
import axios from "axios";
import moment from "moment/moment";
import { useState } from "react";
import { Button } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";
export const PriceModal = ({ station }) => {
  const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL;
  const [show, setShow] = useState(false);
  const [diesel, setDiesel] = useState(
    station.fuelPrice ? station.fuelPrice.diesel : 0
  );
  const [petrol, setPetrol] = useState(
    station.fuelPrice ? station.fuelPrice.petrol : 0
  );
  const [kerosene, setKerosene] = useState(
    station.fuelPrice ? station.fuelPrice.kerosene : 0
  );
  const [createdAt, setCreatedAt] = useState(
    station.fuelPrice ? station.fuelPrice.createdAt : null
  );

  const handleClose = () => setShow(false);
  const [pending, setPending] = useState(false);
  const handleSubmit = () => {
    setPending(true);
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        stationId: station.stationId,
        diesel: parseFloat(diesel),
        petrol: parseFloat(petrol),
        kerosene: parseFloat(kerosene),
      }),
    };

    axios
      .post(BASE_URL + "prices", {
        stationId: station.stationId,
        diesel: parseFloat(diesel),
        petrol: parseFloat(petrol),
        kerosene: parseFloat(kerosene),
      })
      .then((res) => {
        console.log(res);
        // this.setState({ postId: data.id });
        setPending(false);
        setCreatedAt(moment.now());
        handleClose();
      })
      .catch((error) => console.log("An error occured: ", error));
    // fetch("/prices", requestOptions)
    //   .then(async (response) => {
    //     // const isJson = response.headers
    //     //   .get("content-type")
    //     //   ?.includes("application/json");
    //     // const data = isJson && (await response.json());

    //     // // check for error response
    //     // if (!response.ok) {
    //     //   // get error message from body or default to response status
    //     //   const error = (data && data.message) || response.status;
    //     //   return Promise.reject(error);
    //     // }
    //     console.log(response.json());
    //     // this.setState({ postId: data.id });
    //     setPending(false);
    //     setCreatedAt(moment.now());
    //     handleClose();
    //   })
    //   .catch((error) => {
    //     // this.setState({ errorMessage: error.toString() });
    //     console.error("There was an error!", error);
    //   });
  };
  const handleShow = () => {
    setShow(true);
  };
  let lastUpdated;
  if (createdAt !== null) {
    lastUpdated = `Updated: ${moment(createdAt).fromNow()}`;
  } else {
  }
  return (
    <div>
      {/* {console.log(station)} */}
      <strong>{station.tags.brand ?? station.tags.name}</strong>
      <p>{station.tags["addr:street"]}</p>
      <p>{station.tags["addr:city"]}</p>
      <div className="container alert alert-warning" style={{ width: 150 }}>
        {lastUpdated}
        <hr></hr>
        Petrol
        <h6>{petrol}/=</h6>
        Kerosene
        <h6>{kerosene}/=</h6>
        Diesel
        <h6>{diesel}/=</h6>
      </div>

      <Button variant="primary" onClick={handleShow}>
        Submit prices
      </Button>

      <Modal
        show={show}
        onHide={handleClose}
        animation={false}
        size="sm"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            <strong>{station.tags.brand ?? station.tags.name}</strong>
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <form style={{ width: 500, height: 120 }}>
            <div className="form-group row">
              <label htmlFor="diesel" className="col-sm-2 col-form-label">
                Diesel
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="diesel"
                  name="diesel"
                  value={diesel}
                  onChange={(e) => setDiesel(e.target.value)}
                ></input>
              </div>
            </div>
            <div className="form-group row">
              <label htmlFor="petrol" className="col-sm-2 col-form-label">
                Petrol
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="petrol"
                  name="petrol"
                  value={petrol}
                  onChange={(e) => setPetrol(e.target.value)}
                ></input>
              </div>
            </div>
            <div className="form-group row">
              <label htmlFor="super" className="col-sm-2 col-form-label">
                Kerosene
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="super"
                  name="super"
                  value={kerosene}
                  onChange={(e) => setKerosene(e.target.value)}
                ></input>
              </div>
            </div>
          </form>
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-primary" onClick={handleSubmit}>
            {pending ? "Submitting..." : "Submit"}
          </button>
          <button className="btn btn-danger" onClick={handleClose}>
            Close
          </button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};
