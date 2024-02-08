import React from 'react'
import LPStyle from './Style/index.module.css'
import CTA_Button from "../component/CTA_Button"
import SecondaryButton from "../component/SecondaryButton"
import logo from "./Style/assets/logo.svg"
import NavBar_Button from '../component/navBar_Button'
const navBar = () => {
  return (
   <div className ={LPStyle.navBar}>
       <img src={logo} className={LPStyle.navbarlogo} />
      <div className={LPStyle.aboutUsbuttons}>
        <NavBar_Button texte={"Service"}/>
        <NavBar_Button texte={"Download"}/>
        <NavBar_Button texte={"Company"}/>
      </div>
          

      <div className={LPStyle.logInGetStartedButton}>
        <SecondaryButton text={"Log in"}/>
        <CTA_Button text={"Get Started"}/>
        
      </div>
    </div>
    
  );
}

export default navBar
