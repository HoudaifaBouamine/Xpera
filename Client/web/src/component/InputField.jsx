import React, { useState } from 'react';
import './styles.module.css'

const InputField= ({placeHolder,Type, inputValue,onInputChange})=>{
    
    const handleInputChange = (event) => {
        onInputChange(event.target.value);
      };
    return (
        <input 
        placeHolder={placeHolder} 
        type={Type} 
        className="input"     
        value={inputValue}
        onChange={handleInputChange}
        />
    )
}

export default InputField