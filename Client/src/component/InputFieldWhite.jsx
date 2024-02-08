import React from 'react'
import './styles.css'

const InputFieldWhite= ({placeHolder,Type})=>{
    return (
        <input placeHolder={placeHolder} type={Type} className="Input-White"></input>
    )
}

export default InputFieldWhite