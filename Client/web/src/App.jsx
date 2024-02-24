import { useState } from 'react'
import React from 'react'
import { Route,BrowserRouter,Router,Routes } from 'react-router-dom'
import LandingPage from "./LandingPage/LandingPg"
import SingUp from "./singUpPage/singUp"
import Signin from './SigninPage/signin.jsx'
import Home from './Home Page/Home.jsx'
function App() {
    return (
<div>    
    <Home/>
{/*<BrowserRouter>
    <Routes>
      <Route path="/" element={<LandingPage/>}/>
      <Route path="/signup" element={<SingUp/>}/>
      <Route path="/signin" element={<Signin/>}/>
      <Route path="/home" element={<Home/>}/>
       </Routes>
    </BrowserRouter>*/}
</div>
    )}
  
export default App


