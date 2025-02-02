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

  function renderPagination(pageState) {
    const options = [];
    for (let i = 1; i <= pageState.total / 10; i++) {
      console.log(pageState.currentPage)
      if (i === pageState.currentPage) {
        options.push(
          <Pagination.Item key={i} onClick={() => setPageState({ currentPage: i, limit: 10, total: 10})} active>{i}</Pagination.Item>
        );
        continue;
      }
      options.push(<Pagination.Item key={i} onClick={() => { setPageState({ currentPage: i, limit: 10, total: 10}); setValue(value + 1)}}>{i}</Pagination.Item>);
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

