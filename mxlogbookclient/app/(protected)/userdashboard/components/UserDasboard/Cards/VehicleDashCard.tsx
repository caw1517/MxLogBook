'use client'

import Link from 'next/link';
import {useAppDispatch, useAppSelector} from "@/app/store/store";
import {useEffect} from "react";
import {GetUserVehicles} from "@/app/actions/GetUserVehicles";
import {setError, setVehicles} from "@/app/slices/vehicleslice";
import {GetLogsByUser} from "@/app/actions/Logs/GetLogsByUser";
import {logSlice, setLogs} from "@/app/slices/logSlice";
import {Simulate} from "react-dom/test-utils";
import error = Simulate.error;

export default function VehicleDashCard() {

    //Redux
    const dispatch = useAppDispatch();
    const vehicleState =  useAppSelector((state) => state.vehicle.vehicles);
    const errorState = useAppSelector((state) => state.vehicle.error);
    const logState = useAppSelector((state) => state.log.logItems);

    //Fetch the vehicles on load or any time they change
    useEffect(() => {
        async function fetchData() {
            try {
                const vehicles = await GetUserVehicles();
                dispatch(setVehicles(vehicles));
            } catch (e) {
                dispatch(setError((e as Error).message));
            }

            try {
                const logs = await GetLogsByUser();
                dispatch(setLogs(logs));
            } catch (e) {
                dispatch(setError((e as Error).message));
            }
        }
        
        fetchData();
        
    }, [dispatch])
    
    return (
        <div className=' w-6/12 mr-4 p-4 h-80 bg-bg-light rounded-xl'>
            <div className='flex justify-between items-center'>
              <h2 className='text-3xl'>Vehicles</h2>
              <Link href="/userdashboard/vehicles" className='text-primary-200'>View All</Link>
            </div>
            <div className='h-full flex justify-center gap-x-32 mt-20'>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>{vehicleState.length}</p>
                <p className='text-xl font-thin'>Vehicles</p>
              </div>
              <div className='flex flex-col items-center'>
                <p className='text-5xl'>{logState.length}</p>
                <p className='text-xl font-thin'>Open Items</p>
              </div>
            </div>
          </div>
    )
}