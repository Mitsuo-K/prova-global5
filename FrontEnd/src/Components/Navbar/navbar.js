import { NavLink } from 'react-router-dom'
import './navbar.scss'

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="container">
                <div className="nav-elements">
                    <ul>
                        <li>
                            <NavLink to="/Home">Home</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Supplier">Supplier</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Materials">Materials</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Stock">Stock</NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default Navbar