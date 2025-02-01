import React, { useState, useEffect } from "react";

import { Button, Modal, Form } from "react-bootstrap";

interface Props {
  show: boolean;
  handleClose: () => void;
  handleShow: () => void;
}

const AddBookModal = ({ show, handleClose, handleShow }: Props) => {
  const [inputs, setInputs] = useState({});
  const [value, setValue] = useState(0); // integer state

  const [GenreState, setGenreState] = useState([]);

  useEffect(
    function getGenres() {
      const books = fetch("/api/genre");
      Promise.all([books]).then((responses) => {
        var books = responses[0].json();
        Promise.all([books]).then((data) => {
          setGenreState(data[0]);
        });
      });
    },
    [value]
  );

  function handleValueChange(event: { target: { name: any; value: any } }) {
    const name = event.target.name;
    const value = event.target.value;
    setInputs((values) => ({ ...values, [name]: value }));
  }

  function handleMultiSelectChange(e) {
    var options = e.target.options;
    var value: any[] = [];
    for (var i = 0, l = options.length; i < l; i++) {
      if (options[i].selected) {
        value.push(options[i].value);
      }
    }
    setInputs((values) => ({ ...values, genre: value }));
  }

  const addBook = async (e) => {
    e.preventDefault();
    const response = await fetch("/api/book", {
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      method: "POST",

      // Fields that to be updated are passed
      body: JSON.stringify({
        name: inputs.name,
        authorId: inputs.authorId,
        yearPublished: inputs.yearPublished,
        originalLanguage: inputs.originalLanguage,
        type: inputs.type,
        pages: inputs.pages,
        genres: inputs.genre,
      }),
    })
    const data = await response.json();
    console.log(data);
    handleClose();
  };

  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Add Book</Modal.Title>
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
          <Form.Group className="mb-3" controlId="formBasicAuthorId">
            <Form.Label>AuthorId</Form.Label>
            <Form.Control
              name="authorId"
              type="text"
              placeholder="Enter AuthorId"
              onChange={handleValueChange}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicYearPublished">
            <Form.Label>YearPublished</Form.Label>
            <Form.Control
              name="yearPublished"
              type="number"
              placeholder="Enter Year Published"
              onChange={handleValueChange}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicOriginalLanguage">
            <Form.Label>OriginalLanguage</Form.Label>
            <Form.Control
              name="originalLanguage"
              type="text"
              placeholder="Enter language"
              onChange={handleValueChange}
            />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicType">
            <Form.Label>Type</Form.Label>
            <Form.Select
              aria-label="Default select example"
              name="type"
              onChange={handleValueChange}
            >
              <option>Select Type</option>
              <option value="Novel">Novel</option>
              <option value="Novella">Novella</option>
              <option value="Novelette">Novelette</option>
              <option value="ShortStoryCollection">
                Short Story Collection
              </option>
              <option value="Other">Other</option>
            </Form.Select>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicGenre">
            <Form.Label>Genre</Form.Label>
            <Form.Select
              aria-label="Default select example"
              name="genre"
              onChange={handleMultiSelectChange}
              multiple
            >
              {GenreState.map((listValue, index) => {
                return (
                  <option key={index} value={listValue.id}>
                    {listValue.name}
                  </option>
                );
              })}
            </Form.Select>
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPages">
            <Form.Label>Page Count</Form.Label>
            <Form.Control
              name="pages"
              type="number"
              placeholder="Enter page count"
              onChange={handleValueChange}
            />
          </Form.Group>

          <Button variant="primary" type="submit" onClick={addBook}>
            Submit
          </Button>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default AddBookModal;
