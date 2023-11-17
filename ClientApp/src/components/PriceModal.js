import moment from "moment/moment";
import { useState } from "react";
import { Button } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";

export const PriceModal = ({ station }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => {
    setShow(true);
  };

  return (
    <div>
      {console.log(station)}
      <strong>{station.tags.brand ?? station.tags.name}</strong>
      <p>{station.tags["addr:street"]}</p>
      <p>{station.tags["addr:city"]}</p>
      <div className="container alert alert-warning" style={{ width: 150 }}>
        Updated: {moment(station.fuelPrice.createdAt).fromNow()}
        <hr></hr>
        Petrol
        <h6>{station.fuelPrice.petrol}</h6>
        Kerosene
        <h6>{station.fuelPrice.kerosene}</h6>
        Diesel
        <h6>{station.fuelPrice.diesel}</h6>
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
              <label for="diesel" className="col-sm-2 col-form-label">
                Diesel
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="diesel"
                  name="diesel"
                ></input>
              </div>
            </div>
            <div className="form-group row">
              <label for="petrol" className="col-sm-2 col-form-label">
                Petrol
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="petrol"
                  name="petrol"
                ></input>
              </div>
            </div>
            <div className="form-group row">
              <label for="super" className="col-sm-2 col-form-label">
                Super
              </label>
              <div className="col-sm-4">
                <input
                  type="number"
                  className="form-control"
                  id="super"
                  name="super"
                ></input>
              </div>
            </div>
          </form>
        </Modal.Body>
        <Modal.Footer>
          <button className="btn btn-primary" onClick={handleClose}>
            Submit
          </button>
          <button className="btn btn-danger" onClick={handleClose}>
            Close
          </button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};
