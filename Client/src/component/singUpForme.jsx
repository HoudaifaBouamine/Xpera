import React,{useState} from 'react'
import singUpFormStyle from "./singUpForme.module.css"
import InputField from './InputField'
import GoogleButton from './SecondaryButtonIcon'
import CTA_button from './BigCTA_Button'
import icon from "./assets/googleIcon.svg"
{/*import { useNavigate } from 'react-router-dom'*/}

  
const singInForme = () => {
  return (
    <div className={singUpFormStyle.HeroSingUpforme}>
       <h1 className={singUpFormStyle.HerotitleSingUp}>Become a memeber !</h1 >
     <div className={singUpFormStyle.userNameSingUp}>
        <p className={singUpFormStyle.usernameParagraphSingUp}>Full name</p>     
        <InputField  placeHolder={"Amine Mazari"} Type="text"  />
      </div>    
      <div className={singUpFormStyle.userNameSingUp}>
       <p className={singUpFormStyle.usernameParagraphSingUp}>Email</p>     
       <InputField  placeHolder={"exmple@email.com"} Type="email"  />
      </div>    
      <div className={singUpFormStyle.PasswordSingUp}>
         <p className={singUpFormStyle.PasswordParagraphSingUp}>Password</p>
         <InputField  placeHolder={"Password"} Type='password'  />
      </div> 
      <button  className={singUpFormStyle.bigCTAbuttonSingUp}>Sign Up </button>
      <section className={singUpFormStyle.containerSingUp}>
        <div className={singUpFormStyle.horizontalline1SingUp}></div>
          <p className={singUpFormStyle.orSingUp}>Or</p>
          <div className={singUpFormStyle.horizontalline1SingUp}></div>  
      </section>
      <GoogleButton text={"Continue with Google"} Icon={icon}></GoogleButton>
      <div className={singUpFormStyle.noAccountSingUp}>
        <p className={singUpFormStyle.noAccountParagraphSingUp}>Don’t have an account</p>
        <a className={singUpFormStyle.noAccountParagraph2SingUp}>Log In</a>
      </div>
    </div>
  )
}

export default singInForme
