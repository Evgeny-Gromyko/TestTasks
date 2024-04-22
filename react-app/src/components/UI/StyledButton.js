import React from 'react';
import './StyledButton.css';

const StyledButton = ({children, ...props}) => {
  return (
    <button  {...props} className='button'>
      {children}
    </button>
  );
};

export default StyledButton;
