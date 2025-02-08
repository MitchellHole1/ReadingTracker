import React, { useState, useEffect } from "react";

import { Button, Modal, Form } from "react-bootstrap";

interface Props {
  bookId: number;
  show: boolean;
  handleClose: () => void;
  handleShow: () => void;
}

const AddCoverImageModal = ({ bookId, show, handleClose, handleShow }: Props) => {
    const [file, SetFile] = useState();
    const [value, setValue] = useState(0); // integer state
    const [BookState, setBookState] = useState([]);
    
    const host = import.meta.env.VITE_API_BASE_URL ? import.meta.env.VITE_API_BASE_URL : "";
    
    
    function handleValueChange(event) {
        SetFile(event.target.files[0]);
    }
    
    const addCoverImage = async (e) => {
        const formData = new FormData()
        formData.append('file', file)
        e.preventDefault();
        const response = await fetch(host + "/api/book/" + bookId + "/cover-image", {
            method: "PATCH",
            // Fields that to be updated are passed
            body: formData
        });
    
        if (response.ok) {
            handleClose();
        }
    };
    
    return (
        <>    
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
            <Modal.Title>Add Cover Image for {bookId}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
            <Form onSubmit={addCoverImage}>
                <Form.Group controlId="coverImage">
                <Form.Label>Cover Image</Form.Label>
                <Form.Control
                    type="file"
                    name="coverImage"
                    onChange={handleValueChange}
                />
                </Form.Group>
                <br></br>
                <Button variant="primary" type="submit">
                Add Cover Image
                </Button>
            </Form>
            </Modal.Body>
        </Modal>
        </>
    );
};

export default AddCoverImageModal;