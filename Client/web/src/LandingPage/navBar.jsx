import React from 'react'
import { useNavigate } from 'react-router-dom'
import LPStyle from './Style/index.module.css'
import CTA_Button from "../component/CTA_Button"
import SecondaryButton from "../component/SecondaryButton"
import logo from "./Style/assets/logo.svg"
import NavBar_Button from '../component/navBar_Button'
import menuImage from "./Style/assets/Menu.svg"
import MenuButon from  "../component/IconMenu"
const navBar = () => {
   const Navigate = useNavigate(""); 
   const GoSignUp =(e)=>{
    e.preventDefault()
    Navigate("/signup")
   }
   const GoSignIn =(e)=>{
    e.preventDefault()
    Navigate("/signin")
   }
  return (
   <div className ={LPStyle.navBar}>
       <img src={logo} className={LPStyle.navbarlogo} />
      <div className={LPStyle.aboutUsbuttons}>
        <NavBar_Button texte={"Service"}/>
        <NavBar_Button texte={"Download"}/>
        <NavBar_Button texte={"Company"}/>
      </div>
          

      <div className={LPStyle.logInGetStartedButton}>
    
        <SecondaryButton text={"Log in"} onclick={GoSignIn}/>
        <CTA_Button text={"Get Started"} onclick={GoSignUp}/>
        </div>
        <section className={LPStyle.Menue}>
        <MenuButon Icon={menuImage}/>
        </section>
        
  
    </div>
    
  );
}

export default navBar
