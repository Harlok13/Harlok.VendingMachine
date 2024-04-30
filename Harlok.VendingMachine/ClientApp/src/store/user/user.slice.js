import {createSlice} from "@reduxjs/toolkit";

const initialState = {
    coins: [],
}

export const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        addCoin: (state, action) => {
            state.coins = [...state.coins, action.payload];
        },

        removeMoney: (state, action) => {
            state.coins = state.coins.filter(m => m.id === action.payload.id);
        },

        addCoins: (state, action) => {
            state.coins = [...state.coins, ...action.payload];
        },

        clearCoins: (state, action) => {
            state.coins = [];
        }
    }
});

export const {
    addCoin,
    removeCoin,
    addCoins,
    clearCoins
} = userSlice.actions;

export default userSlice.reducer;