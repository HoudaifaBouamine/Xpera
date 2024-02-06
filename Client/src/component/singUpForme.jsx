import React,{useState} from 'react'
import "./singUpForme.css"
import InputField from './InputField'
import GoogleButton from './SecondaryButtonIcon'
import CTA_button from './BigCTA_Button'
import icon from "./assets/googleIcon.svg"
{/*import { useNavigate } from 'react-router-dom'*/}

  
const singInForme = () => {
  return (
    <div className='Hero-SingUp-forme'>
       <h1 className='Hero-title-SingUp'>Become a memeber !</h1 >
     <div className='userName-SingUp'>
        <p className='usernameParagraph-SingUp'>Full name</p>     
        <InputField  placeHolder={"Amine Mazari"} Type="text"  />
      </div>    
      <div className='userName-SingUp'>
       <p className='usernameParagraph-SingUp'>Email</p>     
       <InputField  placeHolder={"exmple@email.com"} Type="email"  />
      </div>    
      <div className='Password-SingUp'>
         <p className='PasswordParagraph-SingUp'>Password</p>
         <InputField  placeHolder={"Password"} Type='password'  />
      </div> 
      <button  className="big-CTA-button-SingUp">Sign Up </button>
      <section className='container-SingUp'>
        <div className='horizontal-line1-SingUp'></div>
          <p className='or-SingUp'>Or</p>
          <div className='horizontal-line1-SingUp'></div>  
      </section>
      <GoogleButton text={"Continue with Google"} Icon={icon}></GoogleButton>
      <div className='noAccount-SingUp'>
        <p className='noAccountParagraph-SingUp'>Don’t have an account</p>
        <a className='noAccountParagraph2-SingUp'>Log In</a>
      </div>
    </div>
  )
}

export default singInForme
