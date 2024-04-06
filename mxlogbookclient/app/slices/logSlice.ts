import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";
import {DateTime} from "@auth/core/providers/kakao";

//Type defs
interface LogItem {
    id: number | null,
    discrepency: string,
    closed: boolean,
    vehicleId: number | null,
    createdOn: any | null,
    closedOn: any | null,
    user: {},
    signOffs: []
}

export interface IVehicleState {
    logItems: LogItem[],
    singleLog: LogItem,
    error: string | null
}

//Init state
const initialState: IVehicleState = {
    logItems: [],
    singleLog: {
        id: null,
        discrepency: '',
        closed: false,
        vehicleId: null,
        createdOn: '',
        closedOn: '',
        user: {},
        signOffs: []
    },
    error: null
}

//Slice
export const logSlice = createSlice({
    name: "log",
    initialState,
    reducers: {
        setLogs: (state, action: PayloadAction<LogItem[]>) =>{
            state.logItems = action.payload;
        },
        setError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        setSingleLog: (state, action: PayloadAction<LogItem>) => {
            state.singleLog = action.payload;
        }
    },
})

export const { setLogs, setError, setSingleLog } = logSlice.actions;
export const logReducer = logSlice.reducer;
