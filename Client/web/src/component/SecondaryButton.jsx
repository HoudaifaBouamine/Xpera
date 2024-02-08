import React from 'react'
import SecondaryButtonStyle from'./styles.module.css'

const SecondaryButton = ({text}) => {
  return (
      <button className={SecondaryButtonStyle.secondary_button}>{text}</button>
  )
}

export default SecondaryButton
