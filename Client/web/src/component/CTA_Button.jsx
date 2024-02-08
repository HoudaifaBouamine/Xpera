import React from 'react'
import CTAButton from './styles.module.css'

const CTA_button = ({text}) => {
  return (
       <button className={CTAButton.CTAButton}>{text}</button>
  )
}
export default CTA_button
