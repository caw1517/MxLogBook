import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

//Type defs
interface Vehicle {
    id: number | null,
    make: string,
    model: string,
    year: number | null,
    mileage: number | null,
    hours: number | null,
    logItems: []
}

export interface IVehicleState {
    vehicles: Vehicle[],
    singleVehicle: Vehicle,
    error: string | null
}

//Init state
const initialState: IVehicleState = {
    vehicles: [],
    singleVehicle: {
        id: null,
        make: '',
        model: '',
        year: null,
        mileage: null,
        hours: null,
        logItems: [],
    },
    error: null
}

//Slice
export const vehicleSlice = createSlice({
    name: "vehicle",
    initialState,
    reducers: {
        setVehicles: (state, action: PayloadAction<Vehicle[]>) =>{
            state.vehicles = action.payload;
        },
        setError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        setSingleVehicle: (state, action: PayloadAction<Vehicle>) => {
            state.singleVehicle = action.payload;
        }
    },
})

export const { setVehicles, setError, setSingleVehicle } = vehicleSlice.actions;
export const vehicleReducer = vehicleSlice.reducer;
