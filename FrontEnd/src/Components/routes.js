import { BrowserRouter, Route, Routes } from "react-router-dom";
import { Home } from "../Screens/Home/home.js";
import Navbar from "./Navbar/navbar.js";

export function RoutesSys() {
    return (
        <BrowserRouter basename="/UI">
            <Navbar />
            <Routes>
                <Route exact path="/Home" element={<Home />} />
            </Routes>
        </BrowserRouter>
    );
}