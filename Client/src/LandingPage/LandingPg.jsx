import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from "../compenenet/CTA_Button"
import LogIn  from "../compenenet/SecondaryButton"
import Hightlight_05 from './Style/assets/Highlight_05.svg'
import Misc_01  from './Style/assets/Misc_01.svg'
import Pngopreview from './Style/assets/pngo-removebg-preview.svg'
import Vector from './Style/assets/Vector.svg'
const LandingPg = () => {
  return (
       <div>
        <NavBar/>
           <div className='hero-page'>
          <div className='hero-text'>
            <h1>Your Guide to Honest <span> Reviews</span></h1>
            <p>Unveiling the Tech Truths: Your Ultimate IT Review Hub</p>
            <p>Your concise guide to honest IT reviews. Dive into expert insights and user experiences. Trust the reviews that matter, empower your tech choices</p>
              <div className='hero-button'>
                <GetStarted text={"Get Started"}/>
                <LogIn text={"Log in"}/>
                 </div>
          </div>
          <div className='hero-image'><img src={Pngopreview}></img></div>
        </div>
    </div>
  )
}

export default LandingPg
