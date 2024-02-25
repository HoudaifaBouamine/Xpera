import React from 'react'
import Styles from "./styles.module.css"
import Expand_up from "./assets/Expand_up_blue.svg"
import Expand_down from "./assets/Expand_down_blue.svg"
import { useState } from "react"
const selection_Button = ({texte}) => {
    const [isExpandUp, setExpandUp] = useState(false);
    const [Expand,setExpand]=useState(Expand_down);
    const handleButtonClick=()=>{
        if (isExpandUp) {
            setExpand(Expand_down)
        }
        else{
            setExpand(Expand_up)
        }
        setExpandUp(!isExpandUp)
    }

  return (
    <button className={Styles.selection_Button} onClick={handleButtonClick}> 
    <img src={Expand}></img>
      {texte}
    </button>
  )
}

export default selection_Button
