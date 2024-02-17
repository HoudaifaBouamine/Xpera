import React from 'react'
import CTAButton from './styles.module.css'

const CTA_button = ({text,onclick}) => {
  return (
       <button className={CTAButton.CTAButton} onClick={onclick}>{text}</button>
  )
}
export default CTA_button
