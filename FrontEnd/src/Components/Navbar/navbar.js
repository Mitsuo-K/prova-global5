import { NavLink } from 'react-router-dom'
import './navbar.scss'
import { useTranslation } from "react-i18next";

const Navbar = () => {
    const { t } = useTranslation()
    return (
        <nav className="navbar">
            <div className="container">
                <div className="nav-elements">
                    <ul>
                        <li>
                            <NavLink to="/Home">{t("home")}</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Supplier">{t("supplier")}</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Materials">{t("materials")}</NavLink>
                        </li>
                        <li>
                            <NavLink to="/Stock">{t("stock")}</NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}

export default Navbar