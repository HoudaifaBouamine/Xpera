import React from 'react'
import Styles from "./post_short.module.css"
import Tag from '../component/Tag.jsx'
import { Style } from '@mui/icons-material'
import Check_fill from "./assets/Check_fill.svg"
const Short_Post = ({title,profilePics,profileName,postDate,content,work,speciality,Skills}) => {
  return (
    <div className={Styles.Post}>
        <h1 className={Styles.Post_title}>{title}</h1>
        <section className={Styles.postInfo}>
            <img src={profilePics} className={Styles.profilePics}/>
            <p className={Styles.profileName}>{profileName}</p>
            <p className={Styles.postDate}>{postDate}</p>
        </section>
        <article className={Styles.Body_Post}>
            <div className={Styles.content}>
            {content}
            <a className={Styles.seeMore}>See more</a>
            </div>
        </article>
        <section className={Styles.skills}>
            {Skills.map((skill) => (
             <Tag text={skill} />
            ))}
        </section>
    

      
    </div>
  )
}

export default Short_Post


