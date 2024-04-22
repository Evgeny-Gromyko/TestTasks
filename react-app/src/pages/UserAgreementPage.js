import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import TermsOfUseContext from "../contexts/TermsOfUseContext";
import APIDataContext from "../contexts/APIDataContext";
import TermsOfUse from "../components/TermsOfUse";

const UserAgreementPage = () => {
    const { SetTermsAccepted } = useContext(TermsOfUseContext);
    const { APIData } = useContext(APIDataContext);
    const navigate = useNavigate();

    const onAccept = () => {
        SetTermsAccepted(true);
        navigate('/main');
    }

    return (
        <TermsOfUse
            paragraphs={APIData?.terms_of_use?.paragraphs}
            onAccept={onAccept}
        />
    );
}

export default UserAgreementPage;
