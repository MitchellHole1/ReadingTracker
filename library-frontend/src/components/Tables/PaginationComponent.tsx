// Factor out the pagination component from the Author table into its own component

import React, { useState, useEffect, useMemo } from "react";
import { Pagination } from "react-bootstrap";


interface Props {
    pageState: { currentPage: number, limit: number, total: number };
    setPageState: ({ currentPage, limit, total }: { currentPage: number, limit: number, total: number }) => void;
    setValue: (num: number) => void;
    value: number;
  }

const PaginationComponent = ({ pageState, setPageState, setValue, value }: Props) => {

  function renderPagination(pageState: { currentPage: any; limit?: number; total: any; }) {
    const options = [];
    let numPages = pageState.total / 10;
    if (pageState.total % 10 === 0) {
      numPages -= 1;
    }
    for (let i = 0; i <= numPages; i++) {
      console.log(pageState.currentPage)
      if (i + 1 === pageState.currentPage) {
        options.push(
          <Pagination.Item key={i} onClick={() => setPageState({ currentPage: i + 1, limit: 10, total: 10})} active>{i + 1}</Pagination.Item>
        );
        continue;
      }
      options.push(<Pagination.Item key={i} onClick={() => { setPageState({ currentPage: i + 1, limit: 10, total: 10}); setValue(value + 1)}}>{i + 1}</Pagination.Item>);
    }

    return options;
  }

  return(
    <Pagination>
      <Pagination.First />
      <Pagination.Prev />
      {renderPagination(pageState)}
      <Pagination.Next />
      <Pagination.Last />
    </Pagination>
  )

};

export default PaginationComponent;

