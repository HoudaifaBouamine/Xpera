import { useState } from 'react'
import React from 'react'
import NavBar from "./navBar/navBar.jsx"
import CTA_button from './compenenet/CTA_Button.jsx';
import SecondaryButton from './compenenet/SecondaryButton.jsx';
import TeriTiaryButton from './compenenet/TeritiaryButton.jsx';
import BigCTA_Button from './compenenet/BigCTA_Button.jsx';
import InputField from './compenenet/InputField.jsx';
import DivTest from './compenenet/Divtest.jsx';

function App() {
    return (
      <>
      
        <CTA_button text={"Get Started"}></CTA_button>
        <SecondaryButton text={"Learn More"}></SecondaryButton>
        <TeriTiaryButton text={"Learn more"}></TeriTiaryButton>
        <InputField placeHolder={"mohariade17@gmail.com"}></InputField>

      </>
    );
};

export default App

