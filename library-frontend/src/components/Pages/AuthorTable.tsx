import React, { useState, useEffect } from "react";
import { Table, Button, Modal, Form, Pagination } from "react-bootstrap";
import AddAuthorModal from "../Forms/AddAuthorModal";

const AuthorTable = () => {
  const [AuthorSessionState, setAuthorSessionState] = useState([]);
  const [pageState, setPageState] = useState({ currentPage: 1, limit: 10 });

  const [value, setValue] = useState(0); // integer state
  const [show, setShow] = useState(false);

  const handleClose = () => {
    setShow(false);
    getAuthors();
  };
  const handleShow = () => setShow(true);

  useEffect(() => {
    document.title = "Authors";
  });

  function getAuthors() {
    const Authors = fetch(
      "/api/author?PageNumber=" +
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
          currentPage: data[0].offset,
          total: data[0].total,
          limit: 10,
        });
      });
    });
  }

  useEffect(
    function getAuthors() {
      const Authors = fetch(
        "/api/author?PageNumber=" +
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
            currentPage: data[0].offset,
            total: data[0].total,
            limit: 10,
          });
        });
      });
    },
    [value]
  );

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
      <Pagination>
        <Pagination.First />
        <Pagination.Prev />
        <Pagination.Item active>{1}</Pagination.Item>
        <Pagination.Item>{2}</Pagination.Item>
        <Pagination.Next />
        <Pagination.Last />
      </Pagination>

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
