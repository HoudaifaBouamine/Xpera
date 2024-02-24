import React from 'react'
import Styles from "./styles.module.css"
import Bell from "./assets/Bell.svg"

const Notification_Allert = () => {
  return (
  <button className={Styles.Notification_bell}><img src={Bell}/></button>
  )
}

export default Notification_Allert
