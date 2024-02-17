import { useState } from 'react'
import React from 'react'
import { Route,BrowserRouter,Router,Routes } from 'react-router-dom'
import LandingPage from "./LandingPage/LandingPg"
import SingUp from "./singUpPage/singUp"
import Signin from './SigninPage/signin.jsx'
function App() {
    return (
<div>
<BrowserRouter>
    <Routes>
      <Route path="/" element={<LandingPage/>}/>
      <Route path="/signup" element={<SingUp/>}/>
      <Route path="/signin" element={<Signin/>}/>
       </Routes>
  </BrowserRouter>
</div>
    )}
  
export default App