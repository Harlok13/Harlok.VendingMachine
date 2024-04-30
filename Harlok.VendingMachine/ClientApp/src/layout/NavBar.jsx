import {Link} from "react-router-dom";
import {NavLink} from "reactstrap";

export const NavBar = () => {

    return (
        <>
            <button>
                <NavLink tag={Link} to={"vending_machine"}>VendingMachine</NavLink>
            </button>

            <button>
                <NavLink tag={Link} to={"admin"}>Admin</NavLink>
            </button>
        </>
    )
}