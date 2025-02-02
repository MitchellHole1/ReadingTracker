import React, { useState, useEffect } from "react";

import { Button, Modal, Form } from "react-bootstrap";

interface Props {
  show: boolean;
  handleClose: () => void;
  handleShow: () => void;
}

const AddAuthorModal = ({ show, handleClose, handleShow }: Props) => {
  const [inputs, setInputs] = useState({});

  function handleValueChange(event: { target: { name: any; value: any } }) {
    const name = event.target.name;
    const value = event.target.value;
    setInputs((values) => ({ ...values, [name]: value }));
  }

  const addAuthor = (e) => {
    e.preventDefault();
    fetch("/api/author", {
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      method: "POST",

      // Fields that to be updated are passed
      body: JSON.stringify({
        name: inputs.name,
        gender: inputs.gender,
        nationality: inputs.nationality,
      }),
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (data) {
        console.log(data);
        handleClose();
      });
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Add Author</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="formBasicName">
            <Form.Label>Name</Form.Label>
            <Form.Control
              name="name"
              type="text"
              placeholder="Enter Name"
              onChange={handleValueChange}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicNationality">
            <Form.Label>Nationality</Form.Label>
            <Form.Control
              name="nationality"
              type="text"
              placeholder="Enter Nationality"
              onChange={handleValueChange}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicGender">
            <Form.Label>Gender</Form.Label>
            <Form.Control
              name="gender"
              type="text"
              placeholder="Enter gender"
              onChange={handleValueChange}
            />
          </Form.Group>

          <Button variant="primary" type="submit" onClick={addAuthor}>
            Submit
          </Button>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default AddAuthorModal;
