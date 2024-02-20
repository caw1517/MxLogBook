'use client'
import { GetVehicleById } from "@/app/actions/Vehicles/GetVehicleById";
import { setError } from "@/app/slices/authslice";
import { setSingleVehicle } from "@/app/slices/vehicleslice";
import { useAppDispatch, useAppSelector } from "@/app/store/store";
import { useEffect } from "react";


type VehicleHeaderTableProps = {
    vehicleId: number;
}

export default function VehicleHeaderTable({vehicleId}: VehicleHeaderTableProps) {

    const dispatch = useAppDispatch();
    const vehicleState = useAppSelector((state) => state.vehicle.singleVehicle);
    

    useEffect(() => {
        let vehicle: any = {};

        const getVehicle = async() => {
            vehicle = await GetVehicleById(vehicleId);
        }

        getVehicle().then(() => {
            dispatch(setSingleVehicle(vehicle));
        }).then(() => console.log(vehicle)).catch((e) => {
            dispatch(setError(e))
        });
    }, [dispatch, vehicleId])

    return(
        <table className="table-fixed">
            <thead>
                <tr>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>Make</th>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>Model</th>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>Year</th>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>Mileage</th>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>Hours</th>
                    <th className='pr-20 text-xl font-bold text-white leading-8'>SN</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td className="text-xl font-light">{vehicleState.make}</td>
                    <td className="text-xl font-light">{vehicleState.model}</td>
                    <td className="text-xl font-light">{vehicleState.year}</td>
                    <td className="text-xl font-light">{vehicleState.mileage}</td>
                    <td className="text-xl font-light">{vehicleState.hours ? vehicleState.hours : "N/A"}</td>
                    <td className="text-xl font-light">TBD</td>
                </tr>
            </tbody>
        </table>
    )
}