import React from 'react'
import Styles from "./Style/home.module.css"
import NavBar from "../component/navBar_HomePage.jsx"
const Home = () => {
  return (
    <div className={Styles.Hero_Page}>
      <NavBar/>
    </div>
  )
}

  export default Home
