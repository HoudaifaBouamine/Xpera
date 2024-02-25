import React from 'react'
import Styles from "./styles.module.css"
const BIG_CTA_Icon = ({text,Icon}) => {
  return (
   <button className={Styles.BIG_CTA_Icon}><img src={Icon} />{text}</button>
  )
}

export default BIG_CTA_Icon
