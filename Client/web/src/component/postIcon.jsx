import React from 'react'
import Styles from "./styles.module.css"
import AddIcon from "./assets/addIcon.svg"
const postIcon = () => {
  return (
    <button className={Styles.Post_Icon}><img src={AddIcon}/></button>
  )
}

export default postIcon
