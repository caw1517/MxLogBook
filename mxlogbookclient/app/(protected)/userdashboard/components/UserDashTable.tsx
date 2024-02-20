'use client';
import Link from 'next/link';
import React, { useEffect } from 'react'
import { useAppSelector, useAppDispatch } from '@/app/store/store';
import { setError, setVehicles } from '@/app/slices/vehicleslice';
import AddNewButton from './AddNewButton';
import { GetUserVehicles } from '@/app/actions/GetUserVehicles';

const UserDashTable = () => {  

    //Redux
    const dispatch = useAppDispatch();
    const vehicleState =  useAppSelector((state) => state.vehicle.vehicles);
    const errorState = useAppSelector((state) => state.vehicle.error);

    //Fetch the vehicles on load or any time they change
    useEffect(() => {
        let vehicles: any = [];
        const getVehicles = async () => {
            vehicles = await GetUserVehicles();
        }

        getVehicles().then(() => {
            dispatch(setVehicles(vehicles));
        }).catch((e) => {
            dispatch(setError(e));
        });
    }, [dispatch])

  return (
    <div className='flex justify-center'>
        <table className='table-fixed w-2/3 border-collapse'> 
            <thead className=" text-left w-full border-b-[1px] table-header-group">
                <tr>
                    <th className='px-5 py-3'>Index</th>
                    <th className='px-5 py-3'>Make</th>
                    <th className='px-5 py-3'>Model</th>
                    <th className='px-5 py-3'>Year</th>
                    <th className='px-5 py-3'>Mileage</th>
                    <th className='px-5 py-3'>Hours</th>
                    <th className='px-5 py-3'>SN</th>
                    <th className='px-5 py-3'>Open Items</th>
                </tr>
            </thead>
            <tbody className='text-left w-full'>
                {vehicleState.map((vehicle, index) => (
                    <tr key={vehicle.id}>
                        <td className="px-5 py-3 text-primary-200">
                            <Link href={{ pathname: `/userdashboard/vehicles/${index + 1}` }}>{`${index + 1}.`}</Link>
                            </td>
                        <td className="px-5 py-3">{vehicle.make}</td>
                        <td className="px-5 py-3">{vehicle.model}</td>
                        <td className="px-5 py-3">{vehicle.year}</td>
                        <td className="px-5 py-3">{vehicle.year}</td>
                        <td className="px-5 py-3">{vehicle.hours ? vehicle.hours : "N/A" }</td>
                        <td className="px-5 py-3">{vehicle.year}</td>
                        <td className="px-5 py-3">{vehicle.logItems.length}</td>
                    </tr>
                ))}
            </tbody>
        </table>

        <AddNewButton />
    </div>
  )
}

export default UserDashTable