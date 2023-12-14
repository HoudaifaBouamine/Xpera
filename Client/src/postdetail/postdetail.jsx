import './postdetail.css'
import avatar from './avatar.jpg'
import { useEffect, useState } from 'react'

export default function() {

  let [post,setPost] = useState(null)

  useEffect(
    () => {
      fetch("https://ac4d-154-121-91-96.ngrok-free.app/api/Post/3")
     .then( (result) => result.json() )
      .then ( result => console.log(result) ).catch(console.log())
    },
    []
  )

    if (!post) return <div>Loading</div>
    else return (
    <div className='post'>
      <h1>
        {post.title}
      </h1>
      <div className='owner'>
        <img className='avatar' src={avatar} />
        <h2>
        {post.user.firstname} {post.user.lastname}
        </h2>
        <h3>
          {post.publishDateTime}
        </h3>
      </div>
      <p>
        {post.body}
      </p>
      <div className='tags'>
        <a>Lorem.</a><a>lorem</a><a>lorem</a>
      </div>
    </div>
  )

}