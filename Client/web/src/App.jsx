import { useState } from 'react'
import React from 'react'
import { Route,BrowserRouter,Router,Routes } from 'react-router-dom'
import LandingPage from "./LandingPage/LandingPg"
import SingUp from "./singUpPage/singUp"

function App() {
    return (
<div>
<BrowserRouter>
    <Routes>
<Route path="/" element={<LandingPage/>}/>
      <Route path="/SingUp" element={<SingUp/>}/>
       </Routes>
  </BrowserRouter>
</div>
    )}
  
export default App