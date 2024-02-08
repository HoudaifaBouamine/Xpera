import React from 'react'
import TagStyle from './styles.module.css'


const Tag= ({text}) =>
{
    return (
        <a className={TagStyle.tag}>{text}</a>
    )
}

export default Tag