import React, { useState, useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import { Container } from "reactstrap";

import Header from "./components/Header";
import AuthorTable from "./components/Tables/AuthorTable";
import BookTable from "./components/Tables/BookTable";
import ReadingPage from "./components/Pages/ReadingPage";

function App() {

  return (
    <Router>
      <div className="App">
        <Container fluid className="centered">
          <Header />
          <br />
          <div className="content">
            <Routes>
              <Route path="/" element={<ReadingPage />}></Route>
              <Route path="/tracker" element={<ReadingPage />}></Route>
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
