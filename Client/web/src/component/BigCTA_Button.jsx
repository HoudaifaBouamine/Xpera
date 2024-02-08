import React from 'react'
import  BigCTAButtonStyle from './styles.module.css'

const BigCTA_Button = ({text}) => {
  return (
       <button className={BigCTAButtonStyle.bigCTAButton}>{text}</button>
  )
}
export default BigCTA_Button
