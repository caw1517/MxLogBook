'use client'

import Link from 'next/link';
import {useAppDispatch, useAppSelector} from "@/app/store/store";
import {useEffect} from "react";
import {GetUserCompanies} from "@/app/actions/Companies/GetUserCompanies";
import {GetCompanyVehicles} from "@/app/actions/Vehicles/GetCompanyVehicles";
import {setCompanies, setError} from "@/app/slices/companyslice";
import {setCompanyVehicles, vehicleSlice} from "@/app/slices/vehicleslice";

export default function CompanyDashCard() {
    const dispatch = useAppDispatch();
    const companiesState = useAppSelector((state) => state.company.companies);
    const companyVehiclesState = useAppSelector((state) => state.vehicle.companyVehicles);

    useEffect(() => {
        async function fetchData() {
            try {
                const companies = await GetUserCompanies();
                dispatch(setCompanies(companies));
            } catch (e) {
                dispatch(setError((e as Error).message));
            }
            
            try {
                const companyVehicles = await GetCompanyVehicles();
                dispatch(setCompanyVehicles(companyVehicles));
            } catch (e) {
                dispatch(vehicleSlice.actions.setError((e as Error).message));
            }
        }
        
        fetchData();
        
    }, [dispatch]);
    
    return (
        <div className=' w-6/12 ml-4 p-4 h-80 bg-bg-light rounded-xl'>
            <div className='flex justify-between items-center'>
              <h2 className='text-3xl'>Company</h2>
              <Link href="/userdashboard/vehicles" className='text-primary-200'>View More</Link>
            </div>
            <div className='h-full flex justify-center gap-x-32 mt-20'>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>{companiesState.length}</p>
                <p className='text-xl font-thin'>Companies</p>
              </div>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>{companyVehiclesState.length}</p>
                <p className='text-xl font-thin'>Company Vehicles</p>
              </div>
            </div>
          </div>
    )
}