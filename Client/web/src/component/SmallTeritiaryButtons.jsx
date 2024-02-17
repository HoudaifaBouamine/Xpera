import React from 'react'
import SmallTeritiaryButtonsSTYLE from'./styles.module.css'

const SmallTeritiaryButtons = ({text,onclick}) => {
  return (
      <button className={SmallTeritiaryButtonsSTYLE.SmallTeritiaryButtons} onClick={onclick}>{text}</button>
  )
}

export default SmallTeritiaryButtons