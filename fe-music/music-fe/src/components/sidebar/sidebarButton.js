import React from 'react';
import { Link } from 'react-router-dom';
import { IconContext } from 'react-icons';
import { useLocation } from 'react-router-dom';
import './sidebarButton.css'


export default function SidebarButton(props) {
    let location=useLocation();
    const isActive=location.pathname==props.to
    return (
        <Link to={props.to}>
            <div className={`btn-body ${isActive ? 'active': ''}`}>
                <IconContext.Provider 
                    value={{size: "24px", className: 'btn-icon'}}>
                    {props.icon}
                    <p className='btn-title'>{props.title}</p>
                </IconContext.Provider>
            </div>
        </Link>
    )
}
