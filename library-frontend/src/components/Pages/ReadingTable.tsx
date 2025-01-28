import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";

const ReadingTable = () => {
  const [readingSessionState, setReadingSessionState] = useState([]);
  const [value, setValue] = useState(0); // integer state

  useEffect(() => {
    document.title = "Reading Tracker";
  });
  
  useEffect(
    function getReadingSessions() {
      const readings = fetch("/api/ReadingSession");
      Promise.all([readings]).then((responses) => {
        var readings = responses[0].json();
        Promise.all([readings]).then((data) => {
          setReadingSessionState(data[0]);
        });
      });
    },
    [value]
  );

  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>Book</th>
          <th>Author</th>
          <th>Rating</th>
          <th>Start Date</th>
          <th>End Date</th>
        </tr>
      </thead>
      <tbody>
        {readingSessionState.map((listValue, index) => {
          return (
            <tr key={index}>
              <td>{listValue.book.name}</td>
              <td>{listValue.book.author.name}</td>
              <td>{listValue.rating}</td>
              <td>{listValue.start.split("T")[0]}</td>
              <td>{listValue.end.split("T")[0]}</td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};

export default ReadingTable;
