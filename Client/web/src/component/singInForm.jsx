import React from 'react'
import singInFormStyle from "./signInForme.module.css"
import InputField from './InputField'
import GoogleButton from './SecondaryButtonIcon'
import CTA_button from './BigCTA_Button'
import icon from "./assets/googleIcon.svg"
const singInForm = () => {
  return (
    <div className={singInFormStyle.Hero_forme}>
    <h1 className={singInFormStyle.Hero_title}>Welcome Back!</h1 >
  <div className={singInFormStyle.userName}>
     <p className={singInFormStyle.username_Paragraph}>User name</p>     
     <InputField  placeHolder={"Amine Mazari"} Type="text"  />
   </div>    
   <div className={singInFormStyle.Password}>
      <p className={singInFormStyle.Password_Paragraph}>Password</p>
      <InputField  placeHolder={"Password"} Type='password'  />
   </div> 
   <CTA_button  text={"Log In"}/>
   <div className={singInFormStyle.forgot_Password_Section}>
     <a className={singInFormStyle.forgotPassword}>Forgot Password ?</a>
     </div>
   <section className={singInFormStyle.container}>
     <div className={singInFormStyle.horizontalline1SingUp}></div>
       <p className={singInFormStyle.orSingUp}>Or</p>
       <div className={singInFormStyle.horizontalline1SingUp}></div>  
   </section>
   <GoogleButton text={"Continue with Google"} Icon={icon}></GoogleButton>
   <div className={singInFormStyle.noAccount}>
     <p className={singInFormStyle.noAccount_Paragraph}>Don’t have an account</p>
     <a className={singInFormStyle.noAccount_Paragraph2}>Log In</a>
   </div>
 </div>
  )
}   

export default singInForm
