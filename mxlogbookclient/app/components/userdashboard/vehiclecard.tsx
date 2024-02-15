"use client"
import React from 'react'
import { useAppSelector } from '@/app/store/store';
import { GetVehicleById } from '@/app/api/vehicle/GetById/route';

const VehicleCard = () => {

    const fetchVehicle = (e: any) => {
      e.preventDefault();
      
      GetVehicleById(5).then((v) => {
        console.log(v)
      }).catch(e => {
        console.error(e)
      });
    };

  return (
    <div>
        <form>
            <button onClick={fetchVehicle}>Get Vehicles</button>
        </form>
        

    </div>
  )
}

export default VehicleCard