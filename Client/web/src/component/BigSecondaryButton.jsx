import React from 'react'
import BigSecondaryButtonStyle from "./styles.module.css"
const BigSecondaryButton = ({text}) => {
  return (
    <div>
      <button className={BigSecondaryButtonStyle.Big_Secondary_Button} >{text}</button>  
    </div>
  )
}

export default BigSecondaryButton
