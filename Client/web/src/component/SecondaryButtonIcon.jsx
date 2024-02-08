import React from 'react'
import SecondaryButtonIconStyle from './styles.module.css'
const SecondaryButtonIcon = ({text,Icon}) => {
  return (
      <button className={SecondaryButtonIconStyle.secondary_button_icon}>
    <img className='GoogleImg' src={Icon}></img>
      {text}</button>
  )
}

export default SecondaryButtonIcon  
