import React from 'react';
import { NavLink } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import './navbar.scss';

const Navbar = () => {
    const { t } = useTranslation();

    return (
        <nav className="navbar">
            <div className="container">
                <div className="nav-elements">
                    <ul>
                        <NavItem to="/Home" label={t("home")} />
                        <NavItem to="/Supplier" label={t("supplier")} />
                        <NavItem to="/Materials" label={t("materials")} />
                        <NavItem to="/Stock" label={t("stock")} />
                    </ul>
                </div>
            </div>
        </nav>
    );
};

const NavItem = ({ to, label }) => (
    <li>
        <NavLink to={to}>{label}</NavLink>
    </li>
);

export default Navbar;
