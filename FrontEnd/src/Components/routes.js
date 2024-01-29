import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Home } from "../Screens/Home/home.js";
import Navbar from "./Navbar/navbar.js";
import { Supplier } from "../Screens/Suppliers/suppliers.js";
import { Materials } from "../Screens/Materials/materials.js";
import { Stock } from "../Screens/Stock/stock.js";

export function RoutesSys() {
    return (
        <BrowserRouter basename="/UI">
            <Navbar />
            <Routes>
                <Route exact path="/Home" element={<Home />} />
                <Route exact path="/Supplier" element={<Supplier />} />
                <Route exact path="/Materials" element={<Materials />} />
                <Route exact path="/Stock" element={<Stock />} />
            </Routes>
        </BrowserRouter>
    );
}