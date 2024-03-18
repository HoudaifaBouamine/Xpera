import React,{useState} from 'react'
import singInFormStyle from "./signInForme.module.css"
import InputField from './InputField'
import GoogleButton from './SecondaryButtonIcon'
import CTA_button from './BigCTA_Button'
import { useNavigate } from 'react-router-dom'
import icon from "./assets/googleIcon.svg"
import { API_URL } from './API_URL.jsx'
const singInForm = () => {
const Navigate = useNavigate("");
  const [userName, setUserName] = useState('');
  const handleUserNameChange = (value) => {
    setUserName(value);
  };

  const [password,setPassword]=useState(""); 
  const handlePasswordChange =(value)=>{
    setPassword(value);
  }

  const SingInClickHandler = async (e)=>{
    
     e.preventDefault();
      /* 
     const response = await fetch(`${API_URL}/api/User/login`,{
      method: "POST",
      headers : new Headers( {  'content-type' : 'application/json' } ),
      body: JSON.stringify({
        email: userName,
        password: password,
      }),
    })
    const data = await response.json() ; 
    if (data){
     console.log(data); 
    /* Navigate(`/home/${data.user_Id}`);
    }*/
    Navigate("/home");
  }
  return (
    <div className={singInFormStyle.Hero_forme}>
    <h1 className={singInFormStyle.Hero_title}>Welcome Back!</h1 >
  <div className={singInFormStyle.userName}>
     <p className={singInFormStyle.username_Paragraph}>Username</p>     
     <InputField  placeHolder={"Amine Mazari"} Type="text"  inputValue={userName} onInputChange={handleUserNameChange}/>
   </div>    
   <div className={singInFormStyle.Password}>
      <p className={singInFormStyle.Password_Paragraph}>Password</p>
      <InputField  placeHolder={"Password"} Type='password'  inputValue={password} onInputChange={handlePasswordChange} />
   </div> 
   <CTA_button  text={"Log In"} onclick={SingInClickHandler}/>
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
