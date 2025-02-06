import React, { useState, useEffect, useMemo } from "react";
import { Table, Button, Modal, Form, Pagination } from "react-bootstrap";
import AddAuthorModal from "../Forms/AddAuthorModal";
import PaginationComponent from "./PaginationComponent";

const AuthorTable = () => {
  const [AuthorSessionState, setAuthorSessionState] = useState([]);
  const [pageState, setPageState] = useState({ currentPage: 1, limit: 10, total: 10});

  const [value, setValue] = useState(0); // integer state
  const [show, setShow] = useState(false);

  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  const handleClose = () => {
    setShow(false);
    setValue(value + 1);
  };
  const handleShow = () => setShow(true);

  useEffect(() => {
    document.title = "Authors";
  });

  function getAuthors() {
    const Authors = fetch(
      host + "/api/author?PageNumber=" +
        pageState.currentPage +
        "&PageSize=" +
        pageState.limit
    );
    Promise.all([Authors]).then((responses) => {
      var Authors = responses[0].json();
      Promise.all([Authors]).then((data) => {
        console.log(data[0]);
        setAuthorSessionState(data[0].results);
        setPageState({
          currentPage: data[0].offset / data[0].limit  + 1,
          total: data[0].total,
          limit: 10,
        });
      });
    });
  }

  const getAuthorsHook = useMemo(() => getAuthors(), [value]);

  return (
    <>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Nationality</th>
            <th>Gender</th>
          </tr>
        </thead>
        <tbody>
          {AuthorSessionState.map((listValue, index) => {
            return (
              <tr key={index}>
                <td>{listValue.name}</td>
                <td>{listValue.gender}</td>
                <td>{listValue.nationality}</td>
              </tr>
            );
          })}
        </tbody>
        <tfoot></tfoot>
      </Table>
      <PaginationComponent pageState={pageState} setPageState={setPageState} setValue={setValue} value={value} />

      <Button type="button" variant="primary" onClick={handleShow}>
        Add Author
      </Button>

      <AddAuthorModal
        show={show}
        handleClose={handleClose}
        handleShow={handleShow}
      />
    </>
  );
};

export default AuthorTable;
