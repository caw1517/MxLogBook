import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

//Type defs
interface Vehicle {
    id: number,
    make: string,
    model: string,
    year: number
}

export interface IVehicleState {
    vehicles: Vehicle[],
    error: string | null
}

//Init state
const initialState: IVehicleState = {
    vehicles: [],
    error: null
}

//Slice
export const vehicleSlice = createSlice({
    name: "vehile",
    initialState,
    reducers: {
        setVehicles: (state, action: PayloadAction<Vehicle[]>) =>{
            state.vehicles = action.payload;
        },
        setError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        }
    },
})

export const { setVehicles, setError } = vehicleSlice.actions;
export const vehicleReducer = vehicleSlice.reducer;
