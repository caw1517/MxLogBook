import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";

interface Company {
    id: number | null,
    companyName: string,
}

export interface ICompanyState {
    companies: Company[],
    company: Company,
    error: string | null
}

const initialState: ICompanyState = {
    companies: [],
    company: {
        id: null,
        companyName: ''
    },
    error: null
}

export const companySlice = createSlice({
    name: "company",
    initialState,
    reducers: {
        setCompanies: (state, action: PayloadAction<Company[]>) =>{
            state.companies = action.payload;
        },
        setError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        setCompany: (state, action: PayloadAction<Company>) => {
            state.company = action.payload;
        }
    },
})

export const { setCompanies, setError, setCompany } = companySlice.actions;
export const companyReducer = companySlice.reducer;
