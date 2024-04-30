import {useSelector} from "react-redux";

export const useCoinsSelector = () => {
    return useSelector(state => state.user.coins);
}