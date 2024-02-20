import VehicleHeaderTable from "../../components/VehiclePage/VehicleHeaderTable";

export default function VehiclePage({ params }: {params:{vehicleId: string}}) {
    
    //const vehicleState = useAppSelector((state) => state.vehicle.vehicles);

    return (
        <div>
            <div className="flex justify-center gap-40">
                <button className=" border-primary-200 h-16 w-16 border-[4px] rounded-lg text-md hover:scale-110 hover:bg-primary-200 transition-all">NEW MCI</button>
                <VehicleHeaderTable vehicleId={params.vehicleId as unknown as number}/>
                <button className=" border-primary-200 h-16 w-16 border-[4px] rounded-lg text-lg hover:scale-110 hover:bg-primary-200 transition-all">More</button>
            </div>
        </div>
    )
}