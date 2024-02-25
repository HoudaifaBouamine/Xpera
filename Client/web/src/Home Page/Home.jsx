import React from 'react'
import Styles from "./Style/home.module.css"
import NavBar from "../component/navBar_HomePage.jsx"
import Controle_Pannel from '../component/controle_Pannel.jsx'
import Short_Post from '../component/Short_Post.jsx'
import femalwPic from "../component/assets/femallPicMvp.svg"
import data from "../Data/data.jsx"
const Home = () => {
  return (
    <div className={Styles.Hero_Page}>
      <NavBar/>
       <div className={Styles.Controle_Panel}>
          <Controle_Pannel/>
       </div>
       {data.map((data) => {
        return (
          <div className={Styles.post}>
        <Short_Post  title={data.title} profilePics={data.profilePics} profileName={data.profileName} postDate={data.postDate} content={data.content} Skills={data.Skills}/>
        </div>
        )
       })}
       
       </div>
  )
}

  export default Home
