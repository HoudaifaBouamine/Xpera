import React from 'react'
import BigSecondaryButtonStyle from "./styles.module.css"
const BigSecondaryButton = ({text,onclick}) => {
  return (
    <div>
      <button className={BigSecondaryButtonStyle.Big_Secondary_Button} onClick={onclick} >{text}</button>  
    </div>
  )
}

export default BigSecondaryButton
