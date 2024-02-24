import React from 'react'
import Styles from "./styles.module.css"
import FemalePic from "./assets/femallPicMvp.svg"
import  Expand_down from "./assets/Expand_down.svg"
const GoToProfile = () => {
  return (
    <section className={Styles.GoToProfile}>
    <img src={FemalePic} className={Styles.FemalePic}/>
   <button className={Styles.Expand_down_button}> <img src={Expand_down}/></button>
      
    </section>
  )
}

export default GoToProfile
