import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

//Type defs
export interface IAuthState {
    authState: boolean,
    userId: string,
    error: string
}

//Init state
const initialState: IAuthState = {
    authState: false,
    userId: '',
    error: ''

}

//Slice
export const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        setAuthState: (state, action: PayloadAction<boolean>) =>{
            state.authState = action.payload;
        },

        setUserId: (state, action: PayloadAction<string>) => {
            state.userId = action.payload;
        },

        setError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        }
    },
})

export const { setAuthState, setUserId, setError } = authSlice.actions;
export const authReducer = authSlice.reducer;
