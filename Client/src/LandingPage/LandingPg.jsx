import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from "../component/CTA_Button"
import LogIn  from "../component/SecondaryButton"
import HeroImage from "./Style/assets/HeroImg.svg"
import bluesecrle from "./Style/assets/bluesecrle.svg"
import lightcircle from "./Style/assets/Light Circle.svg"
import smallBlueDonut from "./Style/assets/blueSmallDonut.svg"
import smallBlueHairt from "./Style/assets/bluehairt.svg"
import smallBlueSercle from "./Style/assets/SmallBlueSercle.svg"
import BlueStarSmall from "./Style/assets/blueStar.svg"


const LandingPg = () => {
  return (
       <div>
        <NavBar/>
           <div className='hero-Landing-page'>
          <div className='hero-text'>
            <h1 className='An-area-with-real'>An area with real<span className='experiences'> experiences</span></h1>  
            <div className='description-landingPage'>   
              <p className='Share-Your-Tech-Story'>Share Your Tech Story, Interact, and Learn from Community Experiences with Xpera</p>
            </div>  
             <div className='hero-button'>
                <GetStarted text={"Start For Free"}/>
                 </div>
          </div>

          <img src={HeroImage} className='Hero-image-landingPage' />
          <img src={bluesecrle} className='bluesercle'/>
          <img src={lightcircle} className='lightcircle'/>
          <img src={smallBlueDonut} className='smallBlueDonut'/>
          <img src={smallBlueHairt} className='smallBlueHairt'/>
          <img src={smallBlueSercle} className='smallBlueSercle'/>
          <img src={BlueStarSmall} className='BlueStarSmall'/>
       </div>
    </div>
  )
}

export default LandingPg
