import React from 'react'
import style from "./creatPost.module.css"  
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';


const creatPost = () => {
  return (
    <div>
      <header className={style.Header_Creat_Post}>
       <h1 className={style.creatNewPost}>Creat a new story</h1>
      </header>

      <div className={style.postFeature}>
            <section className={style.side_option}> 
        <input className={style.option} placeholder='Options'></input>
        <button className={style.title_button}>Title</button>
        <button className={style.sub_header}>Sub-heading</button>
        <button className={style.sub_header}>Paragraphe</button>
      </section>
    <textarea className={style.PostBody}  placeholder='Write your title here'></textarea>




    </div>
  
    </div>
  )
}

export default creatPost
