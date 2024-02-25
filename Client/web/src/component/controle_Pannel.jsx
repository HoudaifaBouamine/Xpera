import React from 'react'
import Styles from "./styles.module.css"
import BIG_CTA_Icon from './BIG_CTA_Icon.jsx'
import Edit_fill from "./assets/Edit_fill.svg"
import Selection_Button from './slection_Button.jsx'
const controle_Pannel = () => {
  return (
    <div className={Styles.controle_Pannel}>
      <section className={Styles.selection_section}>
      <Selection_Button texte={"Hot Today"}/>
      <Selection_Button texte={"Trend"}/>
      <Selection_Button texte={"Recent"}/>
      <Selection_Button texte={"Follow"}/>
      </section>
      <BIG_CTA_Icon Icon={Edit_fill}  text={"Creat Post"}/>
 </div>
  )
}

export default controle_Pannel
