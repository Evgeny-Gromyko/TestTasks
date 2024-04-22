import React, { useState, useEffect } from 'react';
import ImageComponent from './ImageComponent';
import './Gallery.css'

const Gallery = ({ imageUrls, onDownload }) => {
    const [imageURLs, setImageURLs] = useState([]);

    useEffect(() => {
        setImageURLs(imageUrls)
    }, []);

    return (
        <div className="gallery">
            {imageURLs.map((url) => (
                <ImageComponent
                    key={url}
                    imageUrl={url}
                    onDownload={onDownload}
                />
            ))}
        </div>
    );
};

export default Gallery;
