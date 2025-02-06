
import React from 'react';
import { Button } from 'react-bootstrap';
import Card from 'react-bootstrap/Card';
import StockImage from '../../assets/stock-image.jpg';



const ReadingCard = (props) => {
  return (
    <Card style={{ width: '18rem' }}>
      <Card.Img variant="top"  src={StockImage} />
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