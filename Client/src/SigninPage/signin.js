import './signin.css'
import image1 from './images/image1.png'
import image2 from './images/image2.png'
import image3 from './images/image3.png'
import image4 from './images/image4.png'

function InputArticle({label,placeholder,type}) {

  return (
    <div className='inputarticle'>
    <label htmlFor='Label'>{label}</label>
    <input name={label} id={label} type={type} placeholder={placeholder} />
    </div>
  )

}

function Horizontal() {

  return (
    <div className='horizontal'>
      <div></div>
      <p>Or</p>
      <div></div>
    </div>
  )

}

function Leftsection({clas}) {

  let handlefocus = (e) => e.preventDefault()

  return (
    <div className='containerl'>
      <svg className='svg' width="697" height="644" viewBox="0 0 697 644" fill="none" xmlns="http://www.w3.org/2000/svg">
      <path d="M69.3107 287.978C4.05616 497.162 283.451 687.574 416.658 656.696H758.007L774 -23H140.279C140.279 -23 43.8734 9.23307 12.3358 56.1085C-40.9089 135.248 97.1555 198.717 69.3107 287.978Z" fill="#B6C6FF"/>
      </svg>
      <div className='formcontainer'>
        <h1>Become a member</h1>
        <InputArticle label='Full name' placeholder='moha riad' type='text' />
        <InputArticle label='Email' placeholder='example@gmail.com' type='email' />
        <InputArticle label='Password' placeholder='password' type='text' />
        <input name="submit" id="submit" type="submit" value="Sign up" onFocus={handlefocus} />
        <Horizontal />
        <div className='google'>
          <svg width="25" height="24" viewBox="0 0 25 24" fill="none" xmlns="http://www.w3.org/2000/svg">
          <g clip-path="url(#clip0_312_1250)">
          <path d="M12.7406 9.88636V14.4716H19.2733C18.421 17.25 16.0985 19.2401 12.7406 19.2401C8.74343 19.2401 5.50053 15.9972 5.50053 12C5.50053 8.00284 8.73917 4.75994 12.7406 4.75994C14.5389 4.75994 16.1795 5.42045 17.4451 6.5071L20.8201 3.12784C18.6895 1.18466 15.8514 0 12.7406 0C6.10991 0 0.736328 5.37358 0.736328 12C0.736328 18.6264 6.10991 24 12.7406 24C22.8145 24 25.0389 14.5781 24.0502 9.90341L12.7406 9.88636Z" fill="#2454FF"/>
          </g>
          <defs>
          <clipPath id="clip0_312_1250">
          <rect width="23.5275" height="24" fill="white" transform="translate(0.736328)"/>
          </clipPath>
          </defs>
          </svg>
          <p>Continue with google</p>
        </div>
        <p>Already have an account? <a href='#aa'>Log In</a></p>
      </div>
    </div>
  )

}

function Rightsection() {

  return (
    <div className='containerr'>
      <img src={image1} alt=''/>
      <img src={image2} alt='' />
      <img src={image3} alt=''/>
      <img src={image4} alt=''/>
      <h1>LOGO</h1>
      <div className='effect'></div>
    </div>
  )

}

export default function Login() {

  return (
    <div className='container'>
      <Rightsection />
      <Leftsection />
    </div>
  )


}