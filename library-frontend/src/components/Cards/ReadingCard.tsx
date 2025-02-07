
import React, { useMemo, useState } from 'react';
import { Button } from 'react-bootstrap';
import Card from 'react-bootstrap/Card';
import StockImage from '../../assets/stock-image.jpg';



const ReadingCard = (props) => {

  const [value, setValue] = useState(0); // integer state
  const [image, setImage] = useState(Uint8Array.from([]));
  
  const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";

  const replaceImage = (error) => {
      //replacement of broken Image
      error.target.src = StockImage;
  }

  return (
    <Card style={{ width: '18rem' }}>
      <Card.Img variant="top" style={{height: '18rem'}}  src={host + "/api/book/" + props.book.book.id + "/cover-image"} onError={replaceImage}/>
      <Card.Body>
        <Card.Title>{props.book.book.name}</Card.Title>
        <Card.Subtitle className="mb-2 text-muted">{props.book.book.author.name}</Card.Subtitle>
        <Card.Text>
          Some quick example text to build on the card title and make up the
          bulk of the card's content.
        </Card.Text>
        <Button variant="primary">Go somewhere</Button>
      </Card.Body>
    </Card>
  );
}

export default ReadingCard;