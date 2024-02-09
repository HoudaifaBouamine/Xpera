import React from 'react'
import IconMenuStyle from "./styles.module.css"
const IconMenu = ({Icon}) => {
  return (
    <div> 
        <button className={IconMenuStyle.Icon_Menu} > <img src={Icon} /></button>
      
    </div>
  )
}

export default IconMenu
