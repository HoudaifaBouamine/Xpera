import React from 'react'
import './styles.module.css'
import InputField from './InputField'
import PasswordField from './PasswordField'

const PasswordFieldLabel= ({labelText})=>{
    return (
        <div className='input-label'>
            <label htmlFor="">{labelText}</label>
            <PasswordField></PasswordField>
        </div>
    )
}

export default PasswordFieldLabel