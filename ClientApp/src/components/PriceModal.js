import { useState } from "react";
import { Button } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";

export const PriceModal = ({ town }) => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => {
    setShow(true);
  };

  return (
    <div>
      <strong>{town.tags.brand ?? town.tags.name}</strong>
      <p>{town.tags["addr:street"]}</p>
      <p>{town.tags["addr:city"]}</p>
      <div className="container alert alert-warning" style={{ width: 150 }}>
        Petrol
        <h6>198.98</h6>
        Kerosene
        <h6>198.98</h6>
        Diesel
        <h6>198.98</h6>
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
            <strong>{town.tags.brand ?? town.tags.name}</strong>
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
