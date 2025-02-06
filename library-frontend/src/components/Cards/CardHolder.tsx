// Create a skeleton component

import React, { useMemo, useState } from 'react';
import ReadingCard from "./ReadingCard";

const CardHolder = () => {
  const [value, setValue] = useState(0); // integer state
  const [currentBooks, setCurrentBooks] = useState([]);

  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  function getCurrentBooks() {
    const books = fetch(host + "/api/ReadingSession/current");
    Promise.all([books]).then((responses) => {
      var books = responses[0].json();
      Promise.all([books]).then((data) => {
        setCurrentBooks(data[0]);
        console.log(data[0]);
      });
    });
  }

  const getCurrentReadsHook = useMemo(() => getCurrentBooks(), [value]);
  
  return (
    <div className="d-flex gap-3">
      {currentBooks.map((listValue, index) => {
        return (
          <ReadingCard key={index} book={listValue} />
        );
      })}
    </div>
  );
}

export default CardHolder;