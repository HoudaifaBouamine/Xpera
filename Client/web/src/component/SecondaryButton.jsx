import React from 'react'
import SecondaryButtonStyle from'./styles.module.css'

const SecondaryButton = ({text,onclick}) => {
  return (
      <button className={SecondaryButtonStyle.secondary_button} onClick={onclick}>{text}</button>
  )
}

export default SecondaryButton
