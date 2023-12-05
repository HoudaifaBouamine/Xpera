import React from 'react'
import "../navBar/index.css"
const GetStarted = ({texte}) => {
  return (
    <div>
       <button className='Getstarted-button'>{texte}</button>
    </div>
  )
}
export default GetStarted
