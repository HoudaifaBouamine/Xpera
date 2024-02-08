import React from 'react'
import './styles.css'
const SecondaryButtonIcon = ({text,Icon}) => {
  return (
      <button className='secondary-button-icon'>
    <img className='GoogleImg' src={Icon}></img>
      {text}</button>
  )
}

export default SecondaryButtonIcon  
