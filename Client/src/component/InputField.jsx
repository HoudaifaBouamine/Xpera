import React from 'react'
import './styles.module.css'

const InputField= ({placeHolder,Type})=>{
    return (
        <input placeHolder={placeHolder} type={Type} className="input"></input>
    )
}

export default InputField