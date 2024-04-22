import { useContext } from 'react';
import Gallery from "../components/Gallery";
import APIDataContext from "../contexts/APIDataContext";
import { handleDownload } from '../services/FileDownloader';

const MainPage = () => {
    const { APIData } = useContext(APIDataContext);

    return (
        <Gallery
            imageUrls={APIData.images}
            onDownload={handleDownload}
        />
    );
}

export default MainPage;
