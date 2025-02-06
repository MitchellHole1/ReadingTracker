import { useEffect, useState } from "react";
import ReadingTable from "../Tables/ReadingTable";
import CardHolder from "../Cards/CardHolder";

const ReadingPage = () => {
  const [readingSessionState, setReadingSessionState] = useState([]);
  const [value, setValue] = useState(0); // integer state

  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  useEffect(() => {
    document.title = "Reading Tracker";
  });

  return (
    <>
        <h4>Currently Reading:</h4>
        <CardHolder />
        <br />
        <br />
        <h4>Recently Read:</h4>
        <ReadingTable />
    </>
  )
}

export default ReadingPage;