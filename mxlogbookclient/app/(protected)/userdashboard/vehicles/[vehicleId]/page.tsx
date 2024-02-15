export default function VehiclePage({ params }: {params:{vehicleId: string}}) {
    
    return <h1>Hello from {params.vehicleId}</h1>
}