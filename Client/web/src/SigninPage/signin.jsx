import React from 'react'
import SingInForme from '../component/singInForm.jsx';
import singInStyle from "./signin.module.css"
import blueLine from "./images/blueLine.svg"
import halfDonute from "./images/halfDonute.svg"
import whiteLogo from "./images/whiteLogo.svg"
import blueX from "./images/blueX.svg"
import logo from "./images/logo.svg"
import zigzagblue from "./images/zigzag.svg"
import whiteline from "./images/whiteline.svg"
import star from "./images/star.svg"


const signin = () => {
  return (
   
    <div className={singInStyle.splitcontainersingupPage}>
      <div className={singInStyle.image_side}>
          <h1 className={singInStyle.text}>Hear from experienced individuals</h1>
          <img src={whiteLogo} className={singInStyle.logo}/>
          <img src={halfDonute} className={singInStyle.halfDonute}/>
          <img src={blueLine} className={singInStyle.blueLine}/>
          <img src={blueX} className={singInStyle.blueX}/>

      </div>
       <div className={singInStyle.color_side}>
       <img src={blueX} className={singInStyle.blueX_Color_Side}/>      
       <img src={zigzagblue} className={singInStyle.zigzagblue}/>    
       <img src={whiteline} className={singInStyle.whiteline}/>       
       <img src={star} className={singInStyle.star}/>
         <SingInForme/>
         <img src={logo} className={singInStyle.xperaLogo}/>
            
       </div>
      </div>
  
  )
};
export default signin;