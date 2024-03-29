import React from 'react'
import Styles from "./post.module.css"
const post = () => {
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
    <section className={Styles.profileInfo}>
          <img src={profilePics} className={Styles.profilePicsFroProfileInfo}/>
          <mark className={Styles.profileName_work}>
            <h1> {profileName}</h1>
            <p>{work}</p>
          </mark>
          <label className={Styles.specialities}>
          {
            speciality.map((knowladge)=>(
              <div className={Styles.speciality}>
                <img src={Check_fill} className={Styles.Check_fill}/>
                <p className={Styles.knowladge}>{knowladge}</p>
              </div>
            ))
          }
          </label>
          </section>

  
</div>
  )
}

export default post
