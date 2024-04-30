import {createSlice} from "@reduxjs/toolkit";

const initialState = {
    name: ""
}

const vendingMachineSlice = createSlice({
    name: "vendingMachine",
    initialState,
    reducers: {
        setName: (state, action) => {
            state.name = action.payload
        }
    }
});

export const {
    setName
} = vendingMachineSlice.actions;

export default vendingMachineSlice.reducer;