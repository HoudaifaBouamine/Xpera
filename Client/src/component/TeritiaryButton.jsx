import React from 'react'
import TeriTiaryButtonStyle from'./styles.module.css'

const TeriTiaryButton = ({text}) =>
{
    return (
        <a className={TeriTiaryButtonStyle.teritiaryButton}>{text}</a>
    )
}

export default TeriTiaryButton