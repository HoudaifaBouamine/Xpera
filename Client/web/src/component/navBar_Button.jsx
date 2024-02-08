import React from 'react'
import navBarButtonStyle from './styles.module.css'

const navBar_Button = ({texte}) => {
  return (
   <button className={navBarButtonStyle.navBar_Button}>{texte}</button>
  )
}

export default navBar_Button
