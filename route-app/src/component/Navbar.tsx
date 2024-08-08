import { NavLink } from "react-router-dom";
import "./Navbar.css";

const Navbar = () => {

    return (        
        <div className="topnav">
            <NavLink  className={({ isActive }) => isActive ? 'active' : ''} to="/">Home</NavLink>
            <NavLink  className={({ isActive }) => isActive ? 'active' : ''} to="/about">About</NavLink>
            <NavLink  className={({ isActive }) => isActive ? 'active' : ''} to="/contact/danilo">Contact</NavLink>
        </div>
  );
}

export default Navbar

