import React from 'react'
import './index.css'
import LogIn from "../compenenet/logIn.jsx"
import GetStarted from "../compenenet/GetStarted.jsx"

const navBar = () => {
  return (
    <div>
   <div className ="Frame1">
        <h1 className="Logo">LOGO</h1>
    <div className='frame2'>
        <LogIn texte={"Log In"}/>
        <GetStarted texte={"Get Started"}/>
      </div>
    </div>

    <div className="Frame34">
     <div className='Frame33'>
      <h1 className='hightlight'>Your Guide to Honest <span className='hightlight1'>Reviews</span></h1>
       <p className='paragraph'>Unveiling the Tech Truths: Your Ultimate IT Review Hub</p>
      <p className='paragraph2'>Your concise guide to honest IT reviews. Dive into expert insights and user experiences. Trust the reviews that matter, empower your tech choices</p>
     </div>
    </div>

    </div>
    
  );
}

export default navBar
