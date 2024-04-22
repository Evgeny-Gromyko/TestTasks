import React, {useRef, useEffect} from 'react';
import StyledButton from './UI/StyledButton';
import './ImageComponent.css';

const ImageComponent = ({ imageUrl, onDownload }) => {

    const canvasRef = useRef(null);

    useEffect(() => {
        const canvas = canvasRef.current;
        canvas.height = 200;
        const context = canvas.getContext('2d');

        const img = new Image();
        img.src = imageUrl;
        
        img.onload = () => {
            const ratio = canvas.height / img.height;
            canvas.width = img.width * ratio;
            
            context.drawImage(img, 0, 0, canvas.width, canvas.height);
        };
    }, [imageUrl]);


    return (
        <div className="image-container">
            <canvas ref={canvasRef} />
            <StyledButton onClick={() => onDownload(imageUrl, "image.png")}>Download</StyledButton>
        </div>
    );
};

export default ImageComponent;
