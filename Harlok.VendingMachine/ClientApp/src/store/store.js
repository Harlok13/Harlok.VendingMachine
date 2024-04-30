import {configureStore} from "@reduxjs/toolkit";
import vendingMachineReducer from "./vending-machine/vending-machine.slice";
import userReducer from "./user/user.slice";

export const store = configureStore({
    reducer: {
        vendingMachine: vendingMachineReducer,
        user: userReducer
    }
});