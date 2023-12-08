import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from "../compenenet/CTA_Button"
import LogIn  from "../compenenet/SecondaryButton"
import Hightlight_05 from './Style/assets/Highlight_05.svg'
import Star  from './Style/assets/Misc_01.svg'
import HeroImage from './Style/assets/pngo-removebg-preview.svg'
import Object1 from './Style/assets/shape0.svg'
import Object from "./Style/assets/shape1.svg"
const LandingPg = () => {
  return (
       <div>
        <NavBar/>
        <img src={Object} className='Object'></img>
        <img src={Object1} className='Object1'></img>
           <div className='hero-page'>
          <div className='hero-text'>
            <h1 className='hero-text1'>Your Guide to Honest <span className='hero-text2'> Reviews </span><img src={Star} className='star'></img></h1>
            <p className='hero-paragraph1'>Unveiling the Tech Truths: Your Ultimate IT Review Hub</p>        
            <p className='hero-paragraph2'>Your concise guide to honest IT reviews. Dive into expert insights and user experiences. Trust the reviews that matter, empower your tech choices</p>

             <div className='hero-button'>
                <GetStarted text={"Get Started"}/>
                <LogIn text={"Log in"}/>
                 </div>
          </div>
          <div className='hero-image'><img src={HeroImage}></img></div>
        </div>
    </div>
  )
}

export default LandingPg
