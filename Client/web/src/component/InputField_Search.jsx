import React, { useState } from 'react';
import Styles from "./inputField_Search.module.css"
import SearchIcon from "./assets/SearchIcon.svg"
import classNames from 'classnames';
const InputWithSearchIcon = () => {
  const [isInputFocused, setIsInputFocused] = useState(false);
  console.log(isInputFocused);
  const handleInputFocus = () => {
    setIsInputFocused(true);
  };
  const handleInputBlur = () => {
    setIsInputFocused(false);
  };
  const containerClasses = classNames(Styles.Input_With_Search_Icon, { [Styles.Input_With_Search_Icon_focuse] : isInputFocused });
  
  
  return (
    <div className={containerClasses}>
     <span ><img src={SearchIcon}/></span>
     <input type="search" 
            placeholder="Search" 
            className={Styles.Input_Field_Search}
            onBlur={handleInputBlur}
            onFocus={handleInputFocus}
      />
    </div>
  );
};

export default InputWithSearchIcon
