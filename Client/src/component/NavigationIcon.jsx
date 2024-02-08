import React from 'react'
import NavigationIconStyle from './styles.module.css'

const NavigationIcon = ({text}) => {
  return (
    <button className={NavigationIconStyle.Navigation_Icon}>{text}</button>
  )
}

export default NavigationIcon
