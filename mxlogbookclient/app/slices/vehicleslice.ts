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
    loading: boolean,
    error: string | null
}

//Init state
const initialState: IVehicleState = {
    vehicles: [],
    loading: false,
    error: null
}

//Slice
export const vehicleSlice = createSlice({
    name: "vehile",
    initialState,
    reducers: {
        setVehicles: (state, action: PayloadAction<Vehicle[]>) =>{
            state.vehicles = action.payload;
        }
    },
})

export const { setVehicles } = vehicleSlice.actions;
export const vehicleReducer = vehicleSlice.reducer;
