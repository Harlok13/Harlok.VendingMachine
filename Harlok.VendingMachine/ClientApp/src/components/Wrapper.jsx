import {Container} from "reactstrap";
import {NavBar} from "../layout/NavBar";

export const Wrapper = ({children}) => {
    return (
        <div>
            <NavBar/>
            <Container>
                {children}
            </Container>
        </div>
    )
}