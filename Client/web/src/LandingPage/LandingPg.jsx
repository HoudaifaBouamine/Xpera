import React from 'react'
import NavBar from './navBar'
import LPStyle from './Style/index.module.css'
import GetStarted from "../component/BigCTA_Button"
import BigSecondaryButton from "../component/BigSecondaryButton"
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
import XperaPhone_Image from "./Style/assets/XperaPhone.svg"
import DownloadFromPlayStore from "./Style/assets/DownloadFromPlayStore.svg"
import DownloadFromAppStore from "./Style/assets/DownloadFromAppStore.svg"
const LandingPg = () => {
  return (
       <div className={LPStyle.herolandingPage}>
        <NavBar/>
        <div className={LPStyle.countainerLandingpage}>
          <div className={LPStyle.herotext}>
            <h1 className={LPStyle.Anareawithreal}>An area with real <span className={LPStyle.experiences}>experiences</span></h1>  
            <div className={LPStyle.descriptionlandingPage}>   
              <p className={LPStyle.ShareYourTechStory}>Share Your Tech Story, Interact, and Learn from Community Experiences with Xpera</p>
            </div>  
             <div className={LPStyle.herobutton}>
             <GetStarted  text={"Start For Free "}/>
                <section className={LPStyle.Learn_More_button}>
                <BigSecondaryButton text={"learn more"} />
                </section>
              </div>
          </div>

          <img src={HeroImage} className={LPStyle.HeroimagelandingPage}/>
          <img src={bluesecrle} className={LPStyle.bluesercle}/>
          <img src={lightcircle} className={LPStyle.lightcircle}/>
          <img src={smallBlueDonut} className={LPStyle.smallBlueDonut}/>
          <img src={smallBlueHairt} className={LPStyle.smallBlueHairt}/>
          <img src={smallBlueSercle} className={LPStyle.smallBlueSercle}/>
          <img src={BlueStarSmall} className={LPStyle.BlueStarSmall}/>

        </div>
        
{/* the second countainer of the landing page */}

        <div className={LPStyle.countainertwolandingPage}>
             
             <img src={BlackManHoldingPhone } className={LPStyle.BlackManHoldingPhoneimageFlipped}/>
           
           <div className={LPStyle.Xperacomunitydescription}>
            <h1 className={LPStyle.Shareyour}>Share your <span className={LPStyle.Story}> Story</span></h1>
            <p className={LPStyle.Xperaisancomunity}>Xpera is an comunity platforme where you share your experiences to help others make better choices</p>
             <SecondaryButton text={"learn more"}></SecondaryButton>
          </div>
         
          <img src={BlackManHoldingPhone } className={LPStyle.BlackManHoldingPhoneimage}/>
         
          <div className={LPStyle.XperacomunitydescriptionFlipped}>
            <h1 className={LPStyle.Shareyour}>Share your <span className={LPStyle.Story}> Story</span></h1>
            <p className={LPStyle.Xperaisancomunity}>Xpera is an comunity platforme where you share your experiences to help others make better choices</p>
             <SecondaryButton text={"learn more"}></SecondaryButton>
          </div>
        </div>
        
{/* the third countainer of the landing page */}
        <div className={LPStyle.countainertreelandingPage}>
          <img src={ManWithLaptopPresentingSomething} className={LPStyle.ManWithLaptopPresentingSomething}/>
          <img src={intership} className={LPStyle.intershipimage}/>
          <img src={experaInUiUx} className={LPStyle.experInUIUXimage}/>
          <img src={experaIndotNet} className={LPStyle.experaDotNetimage}/>
          <div className={LPStyle.Xperapracticesdescription}>
            <h1 className={LPStyle.HearTheBestpractices}>Hear the best practices</h1>
            <p className={LPStyle.Strengthenyourlearning}>Strengthen your learning journey by gathering insights from others, empowering you to make informed decisions and steer clear of potential pitfalls</p>
            <SecondaryButton text={"learn more"}></SecondaryButton>
          </div>
        </div>

{/* the fourth countainer of the landing page  (will not apeard in phones) */}
        <div className={LPStyle.countainerfourlandingPage}>
          <div className={LPStyle.experadrivendiscription}>
            <h1 className={LPStyle.BecomeExperienceDriven}>Become Experience-Driven Today</h1>
            <SmallTeritiaryButtons text={"Get Started"}></SmallTeritiaryButtons>
          </div>
        </div>
         
        <div className={LPStyle.lineBetweenSection}></div>
{/* the fiveth of the landing page  (will not apeard in phones)  */}
        <div className={LPStyle.countainerfivelandingPage}>
          <img src={xperaWhiteLogo}  className={LPStyle.xperaWhiteLogo}/>
          <div className={LPStyle.QuickLinks}>
            <h1 className={LPStyle.countainerfivetext}>Quick Links</h1>
              <NavigationIcon text={"About Us"}/>
              <NavigationIcon text={"Careers"}/>
              <NavigationIcon text={"FAQs"}/>
              <NavigationIcon text={"Teams"}/>
              <NavigationIcon text={"Contact Us"}/>
          </div>
          
          <div className={LPStyle.Company}>
          <h1 className={LPStyle.countainerfivetext}>Company</h1>
              <NavigationIcon text={"About Us"}/>
              <NavigationIcon text={"Careers"}/>
              <NavigationIcon text={"FAQs"}/>
              <NavigationIcon text={"Teams"}/>
              <NavigationIcon text={"Contact Us"}/>
          </div>
          <div className={LPStyle.CreatAccount}>
            <h1 className={LPStyle.CreatAccounttext}>Creat Account</h1>
            <div className={LPStyle.signUpORcreatAccount}>
               <section className={LPStyle.InputFieldWhite }>
                   <InputFieldWhite placeHolder={"simple@mail.com"} Type={"email"}/>
               </section>
               <SmallTeritiaryButtons text={"Sign Up"}></SmallTeritiaryButtons>
               </div>
              <h1 className={LPStyle.FollowUStext}>Follow US</h1>
               <div className={LPStyle.socialmediaicons}>
                <img src={iconOne}/>
                <img src={iconTwo}/>
                <img src={iconTree}/>
                <img src={iconFour}/>
               </div>
          </div>        
        </div>

        {/* The fourth section that will apeard for phones*/}      
        <section className={LPStyle.Countainer_Five_Phone}>
          <h1 className={LPStyle.Get_The_Xpera_App}>Get The <span className={LPStyle.Xpera_Text}>Xpera</span> App</h1>
          <img src={XperaPhone_Image} className={LPStyle.XperaPhone_Image}/>
          <sub>
            <button  className={LPStyle.bigCTAbuttonSingUp}>INSTALL NOW</button>
            </sub>
          <div className={LPStyle.DownloadButtons}>
            <button  className={LPStyle.IconDownloadButton}><img src={DownloadFromPlayStore} className={LPStyle.DownloadImage}/></button>
            <button  className={LPStyle.IconDownloadButton}><img src={DownloadFromAppStore} className={LPStyle.DownloadImage}/></button>
          </div>
          </section>
                {/* The five section that will apeard for phones*/}    
          <div className={LPStyle.Countainer_Six_Phone}>
            <img className={LPStyle.xpera_logo_for_Phone} src={xperaWhiteLogo}/>
            <section className={LPStyle.Icon_For_Phone}>
            <h1 className={LPStyle.FollowUStext}>Follow US</h1>
               <div className={LPStyle.socialmediaicons}>
                <img src={iconOne} className={LPStyle.icon_socailmedia}/>
                <img src={iconTwo} className={LPStyle.icon_socailmedia}/>
                <img src={iconTree} className={LPStyle.icon_socailmedia}/>
                <img src={iconFour} className={LPStyle.icon_socailmedia}/>
               </div>
            </section>
          </div>
           {/* The six section that will apeard for phones*/}    
           <div className={LPStyle.seven_countainer}>
           <div className={LPStyle.Company}>
            <h1 className={LPStyle.countainerfivetext}>Company</h1>
              <NavigationIcon text={"About Us"}/>
              <NavigationIcon text={"Careers"}/>
              <NavigationIcon text={"FAQs"}/>
              <NavigationIcon text={"Teams"}/>
              <NavigationIcon text={"Contact Us"}/>
          </div>
          <div className={LPStyle.Company}>
          <h1 className={LPStyle.countainerfivetext}>Legal</h1>
              <NavigationIcon text={"Privacy Policy"}/>
              <NavigationIcon text={"Terms of use"}/>
              <NavigationIcon text={"Site map"}/>
              <NavigationIcon text={"Legal"}/>
          </div>  
         
          </div>
       
         {/*last of the landing page */}
        <section className={LPStyle.lastcountainerlandingpage}>
         <h1 className={LPStyle.AllRightsReserved}>© 2024 All Rights Reserved</h1>
          <div className={LPStyle.navigationIcons}>
          <button className={LPStyle.navigationIcon}>Privacy Policy</button>
          <button className={LPStyle.navigationIcon}>Terms of Use</button>
          <button className={LPStyle.navigationIcon}>Sales and Refunds</button>
          <button className={LPStyle.navigationIcon}>Legal</button>
          <button className={LPStyle.navigationIcon}>Site Map</button>
         </div>
        </section>
    </div>
  )
}

export default LandingPg
