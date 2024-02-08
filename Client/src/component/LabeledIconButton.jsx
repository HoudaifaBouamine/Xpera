import React from 'react';
import './styles.module.css';

const LabeledIconButton = ({ label, icon, onClick }) => {
  return (
    <button className="labeled-icon-button" onClick={onClick}>
      <span className="icon">{icon}</span>
      <span className="label">{label}</span>
    </button>
  );
};

export default LabeledIconButton;
