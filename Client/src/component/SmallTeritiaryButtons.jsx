import React from 'react'
import SmallTeritiaryButtonsSTYLE from'./styles.module.css'

const SmallTeritiaryButtons = ({text}) => {
  return (
      <button className={SmallTeritiaryButtonsSTYLE.SmallTeritiaryButtons}>{text}</button>
  )
}

export default SmallTeritiaryButtons