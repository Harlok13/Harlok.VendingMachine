import {useCoinsSelector} from "../../store/user/user.selector";
import {addCoin, addCoins, clearCoins} from "../../store/user/user.slice";
import {useDispatch} from "react-redux";
import ApiService from "../../services/ApiService";
import {v4} from "uuid";
import {useEffect} from "react";
import {Coin} from "../../components/Coin";

export const WelcomePage = () => {
    const coins = useCoinsSelector();
    const dispatch = useDispatch();

    useEffect(() => {

        const getCoins = async() => {
            const response = await ApiService.getCoins();
            dispatch(addCoins(response.result.coins));
        }

        getCoins();
    }, [])

    return (
        <>
            <button onClick={async (e) => {
                e.preventDefault();

                const coin = {
                    id: v4(),
                    denomination: 1
                }
                const response = await ApiService.addCoin(coin)
                if (response.result?.isSuccess) {
                    dispatch(addCoin(response.result.coin));
                }
            }}>Add 1 rub
            </button>
            <button onClick={async (e) => {
                e.preventDefault();

                const coin = {
                    id: v4(),
                    denomination: 2
                }
                const response = await ApiService.addCoin(coin)
                if (response.result?.isSuccess) {
                    dispatch(addCoin(response.result.coin));
                }
            }}>Add 2 rub
            </button>
            <button onClick={async (e) => {
                e.preventDefault();

                const coin = {
                    id: v4(),
                    denomination: 5
                }
                const response = await ApiService.addCoin(coin)
                if (response.result?.isSuccess) {
                    dispatch(addCoin(response.result.coin));
                }
            }}>Add 5 rub
            </button>
            <button onClick={async (e) => {
                e.preventDefault();

                const coin = {
                    id: v4(),
                    denomination: 10
                }
                const response = await ApiService.addCoin(coin)
                if (response.result?.isSuccess) {
                    dispatch(addCoin(response.result.coin));
                }
            }}>Add 10 rub
            </button>
            <button onClick={async (e) => {
                e.preventDefault();

                // const response = await ApiService.removeCoin("123e4567-e89b-12d3-a456-426614174000");
                const response = await ApiService.clearCoins();
                if (response.result?.isSuccess) {
                    dispatch(clearCoins());
                }
            }}>Clear
            </button>

            WelcomePage

            {coins.length ?
                coins.map(coin => (<Coin key={v4()} coinData={coin}/>))
                : null
            }
        </>
    )
}