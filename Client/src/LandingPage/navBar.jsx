import React from 'react'
import './Style/index.css'
import LogIn from "../compenenet/logIn.jsx"
import GetStarted from "../compenenet/GetStarted.jsx"

const navBar = () => {
  return (

   <div className ="Frame1">
        <h1 className="Logo">LOGO</h1>
    <div className='frame2'>
        <LogIn texte={"Log In"}/>
        <GetStarted texte={"Get Started"}/>
      </div>
    </div>
    
  );
}

export default navBar
