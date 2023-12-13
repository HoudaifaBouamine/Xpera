import React from 'react'
import './Style/index.css'
import CTA_Button from "../component/CTA_Button"
import SecondaryButton from "../component/SecondaryButton"
const navBar = () => {
  return (
   <div className ="navBar">
        <h1 className="Logo">LOGO</h1>
      <div className='navBar-button'>
        <SecondaryButton text={"Log in"}/>
        <CTA_Button text={"Get Started"}/>
        
      </div>
    </div>
    
  );
}

export default navBar
