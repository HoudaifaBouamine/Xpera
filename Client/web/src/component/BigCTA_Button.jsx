import React from 'react'
import  BigCTAButtonStyle from './styles.module.css'

const BigCTA_Button = ({text,onclick}) => {
  return (
       <button className={BigCTAButtonStyle.bigCTAButton} onClick={onclick} >{text}</button>
  )
}
export default BigCTA_Button
