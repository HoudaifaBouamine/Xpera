import React from 'react'
import './Style/index.css'
import CTA_Button from "../component/CTA_Button"
import SecondaryButton from "../component/SecondaryButton"
import logo from "./Style/assets/logo.svg"
const navBar = () => {
  return (
   <div className ="navBar">
       <img src={logo} className='logo' />
      <div className='navBar-button'>
        <SecondaryButton text={"Log in"}/>
        <CTA_Button text={"Get Started"}/>
        
      </div>
    </div>
    
  );
}

export default navBar
