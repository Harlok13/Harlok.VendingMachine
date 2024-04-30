import {Route, Routes} from "react-router-dom";
import {VendingMachinePage} from "../pages/VendingMachinePage/VendingMachinePage";
import {AdminPage} from "../pages/AdminPage/AdminPage";
import {WelcomePage} from "../pages/WelcomePage/WelcomePage";

export const Router = () => {
    return (
        <Routes>
            <Route key="/" path="/" element={<WelcomePage/>}/>
            <Route key="vending_machine" path="vending_machine" element={<VendingMachinePage/>}/>
            <Route key="admin" path="admin" element={<AdminPage/>}/>
        </Routes>
    )
}