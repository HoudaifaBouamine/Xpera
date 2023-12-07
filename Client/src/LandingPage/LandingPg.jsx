import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from '../compenenet/GetStarted'
import LogIn from '../compenenet/logIn'
import Hightlight_05 from './Style/assets/Highlight_05.svg'
import Misc_01  from './Style/assets/Misc_01.svg'
import Pngopreview from './Style/assets/pngo-removebg-preview.svg'
import Vector from './Style/assets/Vector.svg'
const LandingPg = () => {
  return (
       <div>
        <NavBar/>
    <div className='Hero-page'>   
    <img src={Hightlight_05} className='Hightlight_05'/>   
   <div className="hero-text">
      <h1 className='hightlight'>Your Guide to Honest <span className='hightlight1'>Reviews</span> 
      </h1>
       <p className='paragraph'>Unveiling the Tech Truths: Your Ultimate IT Review Hub</p>
      <p className='paragraph2'>Your concise guide to honest IT reviews. Dive into expert insights
      and user experiences. Trust the reviews that matter, empower your 
      tech choices</p>
      <div className='frame35'>
      <GetStarted texte={"GetStarted"}/>
      <LogIn texte={"Learn More"}/>
     </div>
     <img src={Pngopreview} className='Pngopreview' />
    </div>
    </div>
    </div>
  )
}

export default LandingPg
