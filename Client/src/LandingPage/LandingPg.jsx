import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from "../component/CTA_Button"
import LogIn  from "../component/SecondaryButton"

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

        </div>
    </div>
  )
}

export default LandingPg
