import React from 'react'
import NavBar from './navBar'
import './Style/index.css'
import GetStarted from "../component/CTA_Button"
import LogIn  from "../component/SecondaryButton"
import HeroImage from "./Style/assets/HeroImg.png"
import bluesecrle from "./Style/assets/bluesecrle.svg"
import lightcircle from "./Style/assets/Light Circle.svg"
import smallBlueDonut from "./Style/assets/blueSmallDonut.svg"
import smallBlueHairt from "./Style/assets/React Shape.svg"
import smallBlueSercle from "./Style/assets/SmallBlueSercle.svg"
import BlueStarSmall from "./Style/assets/blueStar.svg"
import SecondaryButton from '../component/SecondaryButton'
import BlackManHoldingPhone from "./Style/assets/MainCountainerTwo.svg"
import ManWithLaptopPresentingSomething from "./Style/assets/ManWithLaptopPresentingSomething.svg"
import intership from "./Style/assets/MyIntership2023.svg"
import experaInUiUx from "./Style/assets/Ui-UxExper.svg"
import experaIndotNet from "./Style/assets/myExperInNet.svg"
import SmallTeritiaryButtons from '../component/SmallTeritiaryButtons'
import NavigationIcon from '../component/NavigationIcon'
import InputFieldWhite from '../component/InputFieldWhite'
import xperaWhiteLogo from "./Style/assets/xperaWhiteLogo.svg"
import iconOne from "./Style/assets/Vector.svg"
import iconTwo from "./Style/assets/Vector-1.svg"
import iconTree from "./Style/assets/Vector-2.svg"
import iconFour from "./Style/assets/Vector-3.svg"


const LandingPg = () => {
  return (
       <div className='hero-landingPage'>
        <NavBar/>


        <div className='countainer-Landing-page'>
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
        
        {/* the second countainer of the landing page */}

        <div className='countainer-two-landingPage'>

          <div className='Xpera-comunity-description'>
            <h1 className='Share-your'>Share your <span className='Story'> Story</span></h1>
            <p className='Xpera-is-an-comunity'>Xpera is an comunity platforme where you share your experiences to help others make better choices</p>
             <SecondaryButton text={"learn more"}></SecondaryButton>
          </div>
          <img src={BlackManHoldingPhone } className='Black-Man-Holding-Phone-image'/>
        </div>
        
         {/* the third countainer of the landing page */}
        <div className='countainer-tree-landingPage'>
          <img src={ManWithLaptopPresentingSomething} className='Man-With-Laptop-Presenting-Something'/>
          <img src={intership} className='intership-image'/>
          <img src={experaInUiUx} className='experInUIUX-image'/>
          <img src={experaIndotNet} className='experaDotNet-image'/>
          <div className='Xpera-practices-description'>
            <h1 className='Hear-TheBest-practices'>Hear the best practices</h1>
            <p className='Strengthen-your-learning'>Strengthen your learning journey by gathering insights from others, empowering you to make informed decisions and steer clear of potential pitfalls</p>
            <SecondaryButton text={"learn more"}></SecondaryButton>
          </div>
        </div>

         {/* the fourth countainer of the landing page */}
        <div className='countainer-four-landingPage'>
          <div className='expera-driven-discription'>
           <h1 className='Become-Experience-Driven'>Become Experience-Driven Today</h1>
           <SmallTeritiaryButtons text={"Get Started"}></SmallTeritiaryButtons>
           </div>
        </div>
                {/* the lastcountainer of the landing page */}
        <div className='lineBetweenSection'></div>
        <div className='countainer-five-landingPage'>
          <img src={xperaWhiteLogo} />
          <div className='Quick-Links'>
            <h1 className='countainer-five--text'>Quick Links</h1>
              <NavigationIcon text={"About Us"}/>
              <NavigationIcon text={"Careers"}/>
              <NavigationIcon text={"FAQs"}/>
              <NavigationIcon text={"Teams"}/>
              <NavigationIcon text={"Contact Us"}/>
          </div>
          <div className='Company'>
          <h1 className='countainer-five--text'>Company</h1>
              <NavigationIcon text={"About Us"}/>
              <NavigationIcon text={"Careers"}/>
              <NavigationIcon text={"FAQs"}/>
              <NavigationIcon text={"Teams"}/>
              <NavigationIcon text={"Contact Us"}/>
          </div>
          <div className='Creat-Account'>
          <h1 className='Creat-Account--text'>Creat Account</h1>
            <div className='signUp-OR-creatAccount'>
               <InputFieldWhite placeHolder={"simple@mail.com"} Type={"email"}/>
               <SmallTeritiaryButtons text={"Sign Up"}></SmallTeritiaryButtons>
               </div>
               <h1 className='Follow-US--text'>Follow US</h1>
               <div className='social-media-icons'>
                <img src={iconOne}/>
                <img src={iconTwo}/>
                <img src={iconTree}/>
                <img src={iconFour}/>
               </div>
          </div>       
             
        </div>
                {/*last of the landing page */}
        <section className='last-countainer-landingpage'>
         <h1 className='All-Rights-Reserved'>© 2024 All Rights Reserved</h1>
          <div className='navigation-Icons'>
          <button className='navigationIcon'>Privacy Policy</button>
          <button className='navigationIcon'>Terms of Use</button>
          <button className='navigationIcon'>Sales and Refunds</button>
          <button className='navigationIcon'>Legal</button>
          <button className='navigationIcon'>Site Map</button>
         </div>
        </section>
    </div>
  )
}

export default LandingPg
