import React from 'react'
import navBarButtonStyle from './styles.module.css'

const navBar_Button = ({texte,onclick}) => {
  return (
   <button className={navBarButtonStyle.navBar_Button} onClick={onclick} >{texte}</button>
  )
}

export default navBar_Button
