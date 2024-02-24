import React from 'react'
import Styles from "./navBar_HomePage.module.css"
import Logo from "./assets/Log.svg"
import InputWithSearchIcon from './InputField_Search.jsx'
import Notification_Allert from './Notification_Allert.jsx'
import PostIcon from './postIcon.jsx'

const navBar_HomePage = () => {
  return (
    <div className={Styles.navBar}>
        <img src={Logo} className={Styles.Logo}/>
        <InputWithSearchIcon/>
        <aside className={Styles.features}>
        <Notification_Allert/>
        <PostIcon/>
        </aside>
    </div>
  )
}

export default navBar_HomePage
