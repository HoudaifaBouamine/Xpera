import React from 'react'
import Styles from "./navBar_HomePage.module.css"
import Logo from "./assets/Logo.svg"
const navBar_HomePage = () => {
  return (
    <div className={Styles.navBar}>
        <img src={Logo} className={Styles.Logo}/>
        
      
    </div>
  )
}

export default navBar_HomePage
