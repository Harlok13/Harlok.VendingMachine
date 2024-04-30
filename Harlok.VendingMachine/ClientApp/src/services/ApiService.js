import axios from "axios";

class ApiService {

    getAllDrinks = async () => {
        const response = await axios.get("https://localhost:7057/api/vending_machine/get_all_drinks");
        console.log(response.data);
    }

    addCoin = async (coin) => {
        const response = await axios.post("https://localhost:7057/api/user/coin", {
            coin: coin
        }).catch(e => console.error(e.toString()));

        return response.data;
    }

    getCoins = async () => {
        const response = await axios.get("https://localhost:7057/api/user/coins")
            .catch(e => console.error(e.toString()));

        return response.data;
    }

    clearCoins = async () => {
        const response = await axios.delete("https://localhost:7057/api/user/coins")
            .catch(e => console.error(e.toString()));

        return response.data;
    }

    removeCoin = async (coinId) => {
        const response = await axios.delete(`https://localhost:7057/api/user/coin/${coinId}`)
            .catch(e => console.error(e.toString()));

        return response.data;
    }
}

export default new ApiService();