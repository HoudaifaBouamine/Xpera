import React,{useState} from 'react'
import singUpFormStyle from "./singUpForme.module.css"
import InputField from './InputField'
import GoogleButton from './SecondaryButtonIcon'
import CTA_button from './BigCTA_Button'
import icon from "./assets/googleIcon.svg"
import { useNavigate } from 'react-router-dom'
import { API_URL } from './API_URL'  
import { Navigate } from 'react-router-dom'
const singInForme = () => {
  const Navigate = useNavigate(""); 
  const [userName, setUserName] = useState('');
  const handleUserNameChange = (value) => {
    setUserName(value);
  };
  const [email,setEmail] = useState("");
  const handleEmailChange=(value)=>{
    setEmail(value);
  }

  const [password,setPassword]=useState(""); 
  const handlePasswordChange =(value)=>{
    setPassword(value);
  } 

  const SingUpClickHandler= async (e)=>{
    e.preventDefault();
    try{
      const response = await fetch(`${API_URL}/api/User/register`,{
        method: "POST",
        headers : new Headers( {  'content-type' : 'application/json' } ),
        body: JSON.stringify({
          name:userName, 
          email: email,
          password: password,
          pictureUrl:null,
        }),
      });
      const data = await  response.json() ; 
      if (data){
       console.log(data); 
      /* Navigate(`/home/${data.user_Id}`);*/
      }
       Navigate("/home");

      }
      catch (e) { 

          console.log("   > Er "+e)
      }
    
  }


  return (
    <div className={singUpFormStyle.HeroSingUpforme}>
       <h1 className={singUpFormStyle.HerotitleSingUp}>Become a memeber !</h1 >
     <div className={singUpFormStyle.userNameSingUp}>
        <p className={singUpFormStyle.usernameParagraphSingUp}>Full name</p>     
        <InputField  placeHolder={"Amine Mazari"} Type="text" inputValue={userName} onInputChange={handleUserNameChange}/>
      </div>    
      <div className={singUpFormStyle.userNameSingUp}>
       <p className={singUpFormStyle.usernameParagraphSingUp}>Email</p>     
       <InputField  placeHolder={"exmple@email.com"} Type="email" inputValue={email} onInputChange={handleEmailChange} />
      </div>    
      <div className={singUpFormStyle.PasswordSingUp}>
         <p className={singUpFormStyle.PasswordParagraphSingUp}>Password</p>
         <InputField  placeHolder={"Password"} Type='password'  inputValue={password} onInputChange={handlePasswordChange}/>
      </div> 
      <CTA_button  text={"Sign Up"} onclick={SingUpClickHandler}/>
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
