import React, { useState, useEffect, useMemo } from "react";
import { Button, Table } from "react-bootstrap";

import AddBookModal from "../Forms/AddBookModal";

const BookTable = () => {
  const [BookSessionState, setBookSessionState] = useState([]);
  const [value, setValue] = useState(0); // integer state
  const [show, setShow] = useState(false);
  const [render, rerender] = useState(false);

  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  const handleClose = () => {
    setShow(false);
    setValue(value + 1);
  };

  const handleShow = () => setShow(true);

  function getBooks() {
    const books = fetch(host + "/api/book");
    Promise.all([books]).then((responses) => {
      var books = responses[0].json();
      Promise.all([books]).then((data) => {
        setBookSessionState(data[0]);
      });
    });
  }

  useEffect(() => {
    document.title = "Books";
  });

  const getAuthorsHook = useMemo(() => getBooks(), [value]);

  return (
    <>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Author Name</th>
            <th>Year Published</th>
            <th>Original Language</th>
            <th>Page Count</th>
            <th>Genres</th>
          </tr>
        </thead>
        <tbody>
          {BookSessionState.map((listValue, index) => {
            return (
              <tr key={index}>
                <td>{listValue.name}</td>
                <td>{listValue.author.name}</td>
                <td>{listValue.yearPublished}</td>
                <td>{listValue.originalLanguage}</td>
                <td>{listValue.pages}</td>
                <td>{listValue.genres.map((a) => a.name).join(", ")}</td>
              </tr>
            );
          })}
        </tbody>
      </Table>
      <Button type="button" variant="primary" onClick={handleShow}>
        Add Book
      </Button>

      <AddBookModal
        show={show}
        handleClose={handleClose}
        handleShow={handleShow}
      />
    </>
  );
};

export default BookTable;
