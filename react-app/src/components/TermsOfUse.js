import React from 'react';
import StyledButton from './UI/StyledButton';
import './TermsOfUse.css'

const TermsOfUse = ({ paragraphs, onAccept }) => {
  return (
    <div className="user-agreement">
      <h2>Terms of Use</h2>

      {
        paragraphs?.map((paragraph) => (
          <div key={paragraph.index}>
            <h3>{paragraph.title}</h3>
            <p>{paragraph.content}</p>
          </div>
        ))
      }

      <div className="agreement-actions">
        <StyledButton onClick={onAccept}>Accept</StyledButton>
      </div>
    </div>
  );
};

export default TermsOfUse;
