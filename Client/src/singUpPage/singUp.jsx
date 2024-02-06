import React from 'react'
import SingUpForme from '../component/singUpForme';
import "./style/singUp.css"
import logo from "./assets/logo.svg"
import HappyMan from "./assets/image1.svg"
import manHoldComputer from "./assets/image2.svg"
import manThink from "./assets/image3.svg"
import manHoldPhone from "./assets/image4.svg"
import blueStar from "./assets/stars.svg"
import blueDonut from "./assets/donuts.svg"
import ZigZag from "./assets/ZigZag.svg"
import blueLine from "./assets/blueLines.svg"
import grayDonut from "./assets/grayDonut.svg"
import BlueXmark from "./assets/XblueMark.svg"
const signin = () => {
  return (
    <div className='split-container-singupPage'>
      <img src={blueDonut} className='blueDonut-image'  draggable="false"/>  
      <img src={ZigZag} className='ZigZag-image' draggable="false"/>
      <img src={blueLine} className='blueLines-image'  draggable="false"/>
      <img src={grayDonut} className='gray-donut-image'  draggable="false"/>
      <img src={BlueXmark} className='BlueXmark-image'  draggable="false"/>
       <img src={blueStar} className='blueStar-image' draggable="false"/>
     <div className="color-side-singupPage">

       <img src={logo} className='singUp-page-logo'  draggable="false"/>
       <img src={HappyMan} className='HappyMan-image'  draggable="false"/>
       <img src={manHoldComputer} className='manHoldComputer-image'  draggable="false"/>
       <img src={manThink} className='manThink-image'  draggable="false"/>
       <img src={manHoldPhone} className='manHoldPhone-image'  draggable="false"/>
    

     </div>
     <div className="image-side-singupPage">
        <SingUpForme />
     </div>  
    </div>
  )
};
export default signin;