import React from 'react'
import InputFieldWhiteStyle from './styles.module.css'

const InputFieldWhite= ({placeHolder,Type})=>{
    return (
        <input placeHolder={placeHolder} type={Type} className={InputFieldWhiteStyle.InputWhite}></input>
    )
}

export default InputFieldWhite