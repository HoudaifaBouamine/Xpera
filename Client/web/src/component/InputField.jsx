import React from 'react'
import './styles.css'

const InputField= ({placeHolder,Type})=>{
    return (
        <input placeHolder={placeHolder} type={Type} className="input"></input>
    )
}

export default InputField