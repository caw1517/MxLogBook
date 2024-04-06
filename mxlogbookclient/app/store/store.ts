import { configureStore } from "@reduxjs/toolkit";
import { useDispatch, TypedUseSelectorHook, useSelector } from "react-redux";
import { authReducer } from "@/app/slices/authslice";
import { vehicleReducer } from "../slices/vehicleslice";
import { logReducer } from "../slices/logSlice";
import { companyReducer } from "@/app/slices/companyslice";

export const store = configureStore({
    reducer: {
        auth: authReducer,
        vehicle: vehicleReducer,
        log: logReducer,
        company: companyReducer
    },
});

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch: () => AppDispatch = useDispatch
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector