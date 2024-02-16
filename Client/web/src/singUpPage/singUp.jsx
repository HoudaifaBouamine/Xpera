import React from 'react'
import SingUpForme from '../component/singUpForme';
import  styles from "./style/singUp.module.css"
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
    <div className={styles.splitcontainersingupPage}>
      <img src={blueDonut} className={styles.blueDonutimage}  draggable="false"/>  
      <img src={ZigZag} className={styles.ZigZagimage} draggable="false"/>
      <img src={blueLine} className={styles.blueLinesimage}  draggable="false"/>
      <img src={grayDonut} className={styles.graydonutimage} draggable="false"/>
      <img src={BlueXmark} className={styles.BlueXmarkimage}  draggable="false"/>
       <img src={blueStar} className={styles.blueStarimage} draggable="false"/>
     <div className={styles.colorsidesingupPage}>

       <img src={logo} className={styles.singUppagelogo}  draggable="false"/>
       <img src={HappyMan} className={styles.HappyManimage}  draggable="false"/>
       <img src={manHoldComputer} className={styles.manHoldComputerimage}  draggable="false"/>
       <img src={manThink} className={styles.manThinkimage} draggable="false"/>
       <img src={manHoldPhone} className={styles.manHoldPhoneimage}  draggable="false"/>
    

     </div>
     <div className={styles.imagesidesingupPage}>
   
     <SingUpForme />
  
     
     </div>  
    </div>
  )
};
export default signin;