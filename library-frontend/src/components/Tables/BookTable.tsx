import React, { useState, useEffect, useMemo } from "react";
import { Button, Table } from "react-bootstrap";

import AddBookModal from "../Forms/AddBookModal";
import PaginationComponent from "./PaginationComponent";
import AddCoverImageModal from "../Forms/AddCoverImageModal";

const BookTable = () => {
  const [BookSessionState, setBookSessionState] = useState([]);
  const [pageState, setPageState] = useState({ currentPage: 1, limit: 10, total: 10});
  const [value, setValue] = useState(0); // integer state
  const [show, setShow] = useState(false);
  const [showCover, setShowCover] = useState(false);
  const [coverBookId, setCoverBookId] = useState(0);


  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  const handleClose = () => {
    setShow(false);
    setValue(value + 1);
  };

  const handleCloseCover = () => {
    setShowCover(false);
    setValue(value + 1);
  };

  const handleShow = () => setShow(true);

  const handleShowCover = () => {
    setShowCover(true);
  }


  function getBooks() {
    const books = fetch(host + "/api/book?PageNumber=" +
      pageState.currentPage +
      "&PageSize=" +
      pageState.limit);
    Promise.all([books]).then((responses) => {
      var books = responses[0].json();
      Promise.all([books]).then((data) => {
        setBookSessionState(data[0].results);
        setPageState({
          currentPage: data[0].offset / data[0].limit  + 1,
          total: data[0].total,
          limit: 10,
        });
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
            <th>Actions</th>
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
                <td>
                  <Button
                    type="button"
                    variant="primary"
                    onClick={() => {
                      setCoverBookId(listValue.id);
                      handleShowCover();
                    }}
                  >
                    Add Cover Image
                  </Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
      <PaginationComponent pageState={pageState} setPageState={setPageState} setValue={setValue} value={value} />

      <Button type="button" variant="primary" onClick={handleShow}>
        Add Book
      </Button>

      <AddBookModal
        show={show}
        handleClose={handleClose}
        handleShow={handleShow}
      />

      <AddCoverImageModal
        bookId={coverBookId}
        show={showCover}
        handleClose={handleCloseCover}
        handleShow={handleShowCover}
      />
    </>
  );
};

export default BookTable;
