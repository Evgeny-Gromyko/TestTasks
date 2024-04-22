import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import { useState, useEffect } from "react";
import UserAgreementPage from "./pages/UserAgreementPage";
import MainPage from "./pages/MainPage";
import TermsOfUseContext from "./contexts/TermsOfUseContext";
import APIDataContext from "./contexts/APIDataContext";
import { GetAPIData } from "./services/APIWrapper";

function App() {
  const [APIData, SetAPIData] = useState(null);
  const [termsAccepted, SetTermsAccepted] = useState(false);

  useEffect(() => {
    GetAPIData().then(data => SetAPIData(data))
  }, []);

  return (
    <APIDataContext.Provider value={{ APIData, SetAPIData }}>
      <TermsOfUseContext.Provider value={{ termsAccepted, SetTermsAccepted }}>
        <BrowserRouter>
          <Routes>
            <Route path="/user-agreement" Component={UserAgreementPage} />
            { termsAccepted && <Route path="/main" Component={MainPage} /> }
            <Route path="*" element={<Navigate to="/user-agreement" replace />} />
          </Routes>
        </BrowserRouter>
      </TermsOfUseContext.Provider>
    </APIDataContext.Provider>
  );
}

export default App;
