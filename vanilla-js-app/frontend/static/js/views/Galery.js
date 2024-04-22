export default function getGalery(imageUrls, onDownload) {
    const gallery = document.createElement('div');
    gallery.className = 'gallery';

    imageUrls?.forEach((url) => {
        const imageContainer = document.createElement('div');
        imageContainer.className = 'image-container';

        imageContainer.appendChild(renderImageToCanvas(url));

        const downloadButton = document.createElement('button');
        downloadButton.className = 'download-button';
        downloadButton.textContent = 'Download';
        downloadButton.addEventListener('click', () => onDownload(url, 'image.png'));
        imageContainer.appendChild(downloadButton);

        gallery.appendChild(imageContainer);
    });

    return gallery;
}

const renderImageToCanvas = (url) => {
    const canvas = document.createElement('canvas');
    canvas.height = 200;
    canvas.style.width = '100%'; 

    const context = canvas.getContext('2d');
    const img = new Image();
    img.src = url;
    img.alt = 'Image';

    img.onload = () => {
        const ratio = canvas.height / img.height;
        canvas.width = img.width * ratio;
        
        context.drawImage(img, 0, 0, canvas.width, canvas.height);
    };

    return canvas;
}
