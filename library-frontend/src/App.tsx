import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import { Container } from "reactstrap";

import Header from "./components/Header";
import ReadingTable from "./components/Pages/ReadingTable";
import AuthorTable from "./components/Pages/AuthorTable";
import BookTable from "./components/Pages/BookTable";

function App() {
  useEffect(() => {
    document.title = "Reading Tracker";
  });

  return (
    <Router>
      <div className="App">
        <Container fluid className="centered">
          <Header />
          <br />
          <div className="content">
            <Routes>
              <Route path="/" element={<ReadingTable />}></Route>
              <Route path="/tracker" element={<ReadingTable />}></Route>
              <Route path="/books" element={<BookTable />}></Route>
              <Route path="/authors" element={<AuthorTable />}></Route>
            </Routes>
          </div>
        </Container>
      </div>
    </Router>
  );
}

export default App;
