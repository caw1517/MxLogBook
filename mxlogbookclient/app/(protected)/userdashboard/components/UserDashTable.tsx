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
        const getVehicle = async () => {
            vehicles = await GetUserVehicles();
        }

        getVehicle().then(() => {
            dispatch(setVehicles(vehicles));
        }).catch((e) => {
            dispatch(setError(e));
        });
    }, [dispatch, vehicleState])

  return (
    <div className='flex justify-center'>
        <table className='table-fixed border-collapse'>
            <colgroup>

            </colgroup>
            <thead className=" border-b-[1px]">
                <tr>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Index</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Make</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Model</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Year</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Mileage</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Hours</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>SN</th>
                    <th className='pr-28 text-xl leading-8 font-extralight'>Open Items</th>
                    <th className='text-xl leading-8 font-extralight'>Closed Items</th>
                </tr>
            </thead>
            <tbody>
                {vehicleState.map((vehicle, index) => (
                    <tr key={vehicle.id}>
                        <td className="text-xl leading-8 font-extralight text-primary-200">
                            <Link href={{ pathname: `/userdashboard/vehicles/${index + 1}` }}>{`${index + 1}.`}</Link>
                            </td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.make}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.model}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                        <td className="text-xl leading-8 font-extralight">{vehicle.year}</td>
                    </tr>
                ))}
            </tbody>
        </table>

        <AddNewButton />
    </div>
  )
}

export default UserDashTable